using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Linq.Expressions;
using SmartSocialServices.DataTransferObjects;

public interface IRepository<TEntity> : IDisposable
{
    IQueryable<TEntity> Query(RepositoryRequesterInfo requestor = null);
    void Add(TEntity entity);
    void Attach(IEntityWithKey entity);
    void AttachTo(object entity);
    void Delete(TEntity entity);
    void Detach(object entity);
    void SaveChanges(RepositoryRequesterInfo requestor = null);
    TEntity GetByKey(int key);
    IList<TEntity> SelectAll(Expression<Func<TEntity, bool>> EvalPredicate);
}