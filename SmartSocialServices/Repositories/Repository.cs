using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using SmartSocial.Data.V2;
using SmartSocialServices.DataTransferObjects;

public class EntityRepository<TEntity> : IRepository<TEntity>, IDisposable
    where TEntity : EntityObject, new()
{
    private string _KeyProperty = "Id";

    public string KeyProperty
    {
        get
        {
            return _KeyProperty;
        }
        set
        {
            _KeyProperty = value;
        }
    }

    public EntityRepository()
        : this(new SmartSocialContext())
    {

    }

    public EntityRepository(SmartSocialContext context)
    {
        this.ObjectContext = context;
        this.FetchEntitySetName();
    }

    protected SmartSocialContext ObjectContext { get; private set; }
    protected string EntitySetName { get; private set; }

    //looks for an IQueryable<TEntity> property in the ObjectContext
    //and gets its name to be used in other methods
    private void FetchEntitySetName()
    {
        var entitySetProperty =
           this.ObjectContext.GetType().GetProperties()
               .Single(p => p.PropertyType.IsGenericType && typeof(IQueryable<>)
               .MakeGenericType(typeof(TEntity)).IsAssignableFrom(p.PropertyType));

        this.EntitySetName = entitySetProperty.Name;
    }

    //to be implemented by derived classes if needed
    protected virtual IQueryable<TEntity> BuildQuery(ObjectQuery<TEntity> query)
    {
        return query;
    }

    public virtual IQueryable<TEntity> Query(RepositoryRequesterInfo requestor = null)
    {
        var entitySet = String.Format("[{0}]", this.EntitySetName);
        var baseQuery = this.ObjectContext.CreateQuery<TEntity>(entitySet);
        return this.BuildQuery(baseQuery);
    }

    public virtual IQueryable<TEntity> Paging(Expression<Func<TEntity, bool>> predicate, string orderByColumn, int rowsPerPage, int pageNumber)
    {
        var entitySet = String.Format("[{0}]", this.EntitySetName);
        var baseQuery = this.ObjectContext.CreateQuery<TEntity>(entitySet);
        var parameter = Expression.Parameter(typeof(TEntity), "x");
        IQueryable<TEntity> query;
        // Check if the Entity has the column to order by
        PropertyInfo propetyInfo = typeof(TEntity).GetProperty(orderByColumn);
        if (propetyInfo == null)
        {
            query = this.BuildQuery(baseQuery).OrderBy(predicate).Skip(rowsPerPage * (pageNumber - 1)).Take(rowsPerPage).Where(predicate);
        }
        else
        {
            // Todo: Find a better way to construct a lambda expresion by reflection
            switch (propetyInfo.PropertyType.ToString())
            {
                case "System.Int32":
                    Expression<Func<TEntity, int>> lambdaInt32 = Expression.Lambda<Func<TEntity, Int32>>(Expression.Convert(Expression.Property(parameter, orderByColumn), propetyInfo.PropertyType), parameter);
                    query = this.BuildQuery(baseQuery).Where(predicate).OrderByDescending(lambdaInt32).Skip(rowsPerPage * (--pageNumber)).Take(rowsPerPage);
                    break;
                case "System.Nullable`1[System.DateTime]":
                    //Expression<Func<TEntity, DateTime?>> lambdaDateTime = Expression.Lambda<Func<TEntity, DateTime?>>(Expression.Convert(Expression.Property(parameter, orderByColumn), propetyInfo.PropertyType), parameter);
                    //query = this.BuildQuery(baseQuery).Where(predicate).OrderByDescending(lambdaDateTime).Skip(rowsPerPage * (--pageNumber)).Take(rowsPerPage);

                    var sortExpression = Expression.Lambda<Func<TEntity, DateTime>>(Expression.Convert(Expression.Property(parameter, orderByColumn), typeof(DateTime)), parameter);
                    query = this.BuildQuery(baseQuery).Where(predicate).OrderByDescending(sortExpression).Skip(rowsPerPage * (--pageNumber)).Take(rowsPerPage);
                    break;
                default:
                    query = this.BuildQuery(baseQuery).Where(predicate).OrderBy(predicate).Skip(rowsPerPage * (--pageNumber)).Take(rowsPerPage);
                    break;
            }
        }
        return query;
    }

    public virtual void Add(TEntity entity)
    {
        this.ObjectContext.AddObject(this.EntitySetName, entity);
    }

    public virtual void Attach(IEntityWithKey entity)
    {
        this.ObjectContext.Attach(entity);
    }
    public virtual void AttachTo(object entity)
    {
        this.ObjectContext.AttachTo(this.EntitySetName, entity);

    }

    public virtual void Detach(object entity)
    {
        this.ObjectContext.Detach(entity);
    }

    public virtual void Delete(TEntity entity)
    {
        if (entity.EntityState == EntityState.Detached)
            this.ObjectContext.AttachTo(this.EntitySetName, entity);

        this.ObjectContext.DeleteObject(entity);
    }

    public virtual void SaveChanges(RepositoryRequesterInfo requestor = null)
    {
        this.ObjectContext.SaveChanges();
    }

    public IList<TEntity> SelectAll(Expression<Func<TEntity, bool>> EvalPredicate)
    {
        return Query().Where(EvalPredicate).ToList();
    }

    public ObjectQuery<TEntity> DoQuery(Expression<Func<TEntity, bool>> EvalPredicate)
    {
        var Query = (ObjectQuery<TEntity>)ObjectContext.CreateQuery<TEntity>("[ + typeof(TEntity).Name + ]")
        .Where(EvalPredicate);
        return Query;
    }



    /// <summary>
    /// Get Entity By Primary key
    /// </summary>
    /// <typeparam name="E">Entity Type</typeparam>
    /// <param name="key">Primary key Value</param>
    /// <returns>return entity</returns>
    public TEntity GetByKey(int key)
    {
        // First we define the parameter that we are going to use the clause. 
        var xParam = Expression.Parameter(typeof(TEntity), typeof(TEntity).Name);
        MemberExpression leftExpr = MemberExpression.Property(xParam, this._KeyProperty);
        Expression rightExpr = Expression.Constant(key);
        BinaryExpression binaryExpr = MemberExpression.Equal(leftExpr, rightExpr);
        //Create Lambda Expression for the selection 
        Expression<Func<TEntity, bool>> lambdaExpr =
        Expression.Lambda<Func<TEntity, bool>>(binaryExpr,
        new ParameterExpression[] { xParam });
        //Searching ....
        IList<TEntity> resultCollection = ((IRepository<TEntity>)this).SelectAll(lambdaExpr);
        if (null != resultCollection && resultCollection.Count() > 0)
        {
            //return valid single result
            return resultCollection.First<TEntity>();
        }//end if 
        return null;
    }


    #region IDisposable Members

    public void Dispose()
    {
        if (null != ObjectContext)
        {
            ObjectContext.Connection.Dispose();
            ObjectContext.Dispose();
        }
    }

    #endregion

}