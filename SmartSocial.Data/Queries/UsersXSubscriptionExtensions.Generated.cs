﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using CodeSmith.Data.Linq;
using CodeSmith.Data.Linq.Dynamic;

namespace SmartSocial.Data
{
    /// <summary>
    /// The query extension class for UsersXSubscription.
    /// </summary>
    public static partial class UsersXSubscriptionExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SmartSocial.Data.UsersXSubscription GetByKey(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, int idSubscription, string idUser)
        {
            var entity = queryable as System.Data.Linq.Table<SmartSocial.Data.UsersXSubscription>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((SmartSocial.Data.SmartSocialdbDataContext)entity.Context, idSubscription, idUser);

            return queryable.FirstOrDefault(u => u.IdSubscription == idSubscription 
					&& u.IdUser == idUser);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static int Delete(this System.Data.Linq.Table<SmartSocial.Data.UsersXSubscription> table, int idSubscription, string idUser)
        {
            return table.Delete(u => u.IdSubscription == idSubscription 
					&& u.IdUser == idUser);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSubscription">IdSubscription to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdSubscription(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, int idSubscription)
        {
            return queryable.Where(u => u.IdSubscription == idSubscription);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSubscription">IdSubscription to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdSubscription(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, ComparisonOperator comparisonOperator, int idSubscription)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(u => u.IdSubscription > idSubscription);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(u => u.IdSubscription >= idSubscription);
                case ComparisonOperator.LessThan:
                    return queryable.Where(u => u.IdSubscription < idSubscription);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(u => u.IdSubscription <= idSubscription);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(u => u.IdSubscription != idSubscription);
                default:
                    return queryable.Where(u => u.IdSubscription == idSubscription);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSubscription">IdSubscription to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdSubscription(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, int idSubscription, params int[] additionalValues)
        {
            var idSubscriptionList = new List<int> { idSubscription };

            if (additionalValues != null)
                idSubscriptionList.AddRange(additionalValues);

            if (idSubscriptionList.Count == 1)
                return queryable.ByIdSubscription(idSubscriptionList[0]);

            return queryable.ByIdSubscription(idSubscriptionList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdSubscription(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, IEnumerable<int> values)
        {
            return queryable.Where(u => values.Contains(u.IdSubscription));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdUser"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idUser">IdUser to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdUser(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, string idUser)
        {
            return queryable.Where(u => u.IdUser == idUser);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdUser"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idUser">IdUser to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdUser(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, ContainmentOperator containmentOperator, string idUser)
        {
            if (idUser == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("idUser", "Parameter 'idUser' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(u => u.IdUser.Contains(idUser));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(u => u.IdUser.StartsWith(idUser));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(u => u.IdUser.EndsWith(idUser));
                case ContainmentOperator.NotContains:
                    return queryable.Where(u => u.IdUser.Contains(idUser) == false);
                case ContainmentOperator.NotEquals:
                    return queryable.Where(u => u.IdUser != idUser);
                default:
                    return queryable.Where(u => u.IdUser == idUser);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdUser"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idUser">IdUser to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdUser(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, string idUser, params string[] additionalValues)
        {
            var idUserList = new List<string> { idUser };

            if (additionalValues != null)
                idUserList.AddRange(additionalValues);

            if (idUserList.Count == 1)
                return queryable.ByIdUser(idUserList[0]);

            return queryable.ByIdUser(idUserList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.IdUser"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByIdUser(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, IEnumerable<string> values)
        {
            return queryable.Where(u => values.Contains(u.IdUser));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="dateCreated">DateCreated to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByDateCreated(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, System.DateTime? dateCreated)
        {
            // support nulls
            return dateCreated == null 
                ? queryable.Where(u => u.DateCreated == null) 
                : queryable.Where(u => u.DateCreated == dateCreated);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="dateCreated">DateCreated to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByDateCreated(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, ComparisonOperator comparisonOperator, System.DateTime? dateCreated)
        {
            if (dateCreated == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("dateCreated", "Parameter 'dateCreated' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(u => u.DateCreated > dateCreated);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(u => u.DateCreated >= dateCreated);
                case ComparisonOperator.LessThan:
                    return queryable.Where(u => u.DateCreated < dateCreated);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(u => u.DateCreated <= dateCreated);
                case ComparisonOperator.NotEquals:
                    return dateCreated == null 
                        ? queryable.Where(u => u.DateCreated != null) 
                        : queryable.Where(u => u.DateCreated != dateCreated);
                default:
                    return dateCreated == null 
                        ? queryable.Where(u => u.DateCreated == null) 
                        : queryable.Where(u => u.DateCreated == dateCreated);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="dateCreated">DateCreated to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByDateCreated(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, System.DateTime? dateCreated, params System.DateTime?[] additionalValues)
        {
            var dateCreatedList = new List<System.DateTime?> { dateCreated };

            if (additionalValues != null)
                dateCreatedList.AddRange(additionalValues);
            else
                dateCreatedList.Add(null);

            if (dateCreatedList.Count == 1)
                return queryable.ByDateCreated(dateCreatedList[0]);

            return queryable.ByDateCreated(dateCreatedList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.UsersXSubscription.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.UsersXSubscription> ByDateCreated(this IQueryable<SmartSocial.Data.UsersXSubscription> queryable, IEnumerable<System.DateTime?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.UsersXSubscription, bool>("DateCreated", values);
            return queryable.Where(expression);
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
            internal static readonly Func<SmartSocial.Data.SmartSocialdbDataContext, int, string, SmartSocial.Data.UsersXSubscription> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (SmartSocial.Data.SmartSocialdbDataContext db, int idSubscription, string idUser) =>
                        db.UsersXSubscription.FirstOrDefault(u => u.IdSubscription == idSubscription 
							&& u.IdUser == idUser));

        }
        #endregion
    }
}
#pragma warning restore 1591
