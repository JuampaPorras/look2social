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
    /// The query extension class for WebpagesUsersInRoles.
    /// </summary>
    public static partial class WebpagesUsersInRolesExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SmartSocial.Data.WebpagesUsersInRoles GetByKey(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, int userId, int roleId)
        {
            var entity = queryable as System.Data.Linq.Table<SmartSocial.Data.WebpagesUsersInRoles>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((SmartSocial.Data.SmartSocialdbDataContext)entity.Context, userId, roleId);

            return queryable.FirstOrDefault(w => w.UserId == userId 
					&& w.RoleId == roleId);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static int Delete(this System.Data.Linq.Table<SmartSocial.Data.WebpagesUsersInRoles> table, int userId, int roleId)
        {
            return table.Delete(w => w.UserId == userId 
					&& w.RoleId == roleId);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.UserId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="userId">UserId to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByUserId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, int userId)
        {
            return queryable.Where(w => w.UserId == userId);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.UserId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="userId">UserId to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByUserId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, ComparisonOperator comparisonOperator, int userId)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(w => w.UserId > userId);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(w => w.UserId >= userId);
                case ComparisonOperator.LessThan:
                    return queryable.Where(w => w.UserId < userId);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(w => w.UserId <= userId);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(w => w.UserId != userId);
                default:
                    return queryable.Where(w => w.UserId == userId);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.UserId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="userId">UserId to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByUserId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, int userId, params int[] additionalValues)
        {
            var userIdList = new List<int> { userId };

            if (additionalValues != null)
                userIdList.AddRange(additionalValues);

            if (userIdList.Count == 1)
                return queryable.ByUserId(userIdList[0]);

            return queryable.ByUserId(userIdList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.UserId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByUserId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, IEnumerable<int> values)
        {
            return queryable.Where(w => values.Contains(w.UserId));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.RoleId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="roleId">RoleId to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByRoleId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, int roleId)
        {
            return queryable.Where(w => w.RoleId == roleId);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.RoleId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="roleId">RoleId to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByRoleId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, ComparisonOperator comparisonOperator, int roleId)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(w => w.RoleId > roleId);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(w => w.RoleId >= roleId);
                case ComparisonOperator.LessThan:
                    return queryable.Where(w => w.RoleId < roleId);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(w => w.RoleId <= roleId);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(w => w.RoleId != roleId);
                default:
                    return queryable.Where(w => w.RoleId == roleId);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.RoleId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="roleId">RoleId to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByRoleId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, int roleId, params int[] additionalValues)
        {
            var roleIdList = new List<int> { roleId };

            if (additionalValues != null)
                roleIdList.AddRange(additionalValues);

            if (roleIdList.Count == 1)
                return queryable.ByRoleId(roleIdList[0]);

            return queryable.ByRoleId(roleIdList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.WebpagesUsersInRoles.RoleId"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.WebpagesUsersInRoles> ByRoleId(this IQueryable<SmartSocial.Data.WebpagesUsersInRoles> queryable, IEnumerable<int> values)
        {
            return queryable.Where(w => values.Contains(w.RoleId));
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
            internal static readonly Func<SmartSocial.Data.SmartSocialdbDataContext, int, int, SmartSocial.Data.WebpagesUsersInRoles> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (SmartSocial.Data.SmartSocialdbDataContext db, int userId, int roleId) =>
                        db.WebpagesUsersInRoles.FirstOrDefault(w => w.UserId == userId 
							&& w.RoleId == roleId));

        }
        #endregion
    }
}
#pragma warning restore 1591
