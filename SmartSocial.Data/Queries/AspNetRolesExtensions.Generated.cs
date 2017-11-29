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
    /// The query extension class for AspNetRoles.
    /// </summary>
    public static partial class AspNetRolesExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SmartSocial.Data.AspNetRoles GetByKey(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, string id)
        {
            var entity = queryable as System.Data.Linq.Table<SmartSocial.Data.AspNetRoles>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((SmartSocial.Data.SmartSocialdbDataContext)entity.Context, id);

            return queryable.FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static int Delete(this System.Data.Linq.Table<SmartSocial.Data.AspNetRoles> table, string id)
        {
            return table.Delete(a => a.Id == id);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Id"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="id">Id to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ById(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, string id)
        {
            return queryable.Where(a => a.Id == id);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Id"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="id">Id to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ById(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, ContainmentOperator containmentOperator, string id)
        {
            if (id == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("id", "Parameter 'id' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(a => a.Id.Contains(id));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(a => a.Id.StartsWith(id));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(a => a.Id.EndsWith(id));
                case ContainmentOperator.NotContains:
                    return queryable.Where(a => a.Id.Contains(id) == false);
                case ContainmentOperator.NotEquals:
                    return queryable.Where(a => a.Id != id);
                default:
                    return queryable.Where(a => a.Id == id);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Id"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="id">Id to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ById(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, string id, params string[] additionalValues)
        {
            var idList = new List<string> { id };

            if (additionalValues != null)
                idList.AddRange(additionalValues);

            if (idList.Count == 1)
                return queryable.ById(idList[0]);

            return queryable.ById(idList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Id"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ById(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, IEnumerable<string> values)
        {
            return queryable.Where(a => values.Contains(a.Id));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Name"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="name">Name to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ByName(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, string name)
        {
            return queryable.Where(a => a.Name == name);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Name"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="name">Name to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ByName(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, ContainmentOperator containmentOperator, string name)
        {
            if (name == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("name", "Parameter 'name' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(a => a.Name.Contains(name));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(a => a.Name.StartsWith(name));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(a => a.Name.EndsWith(name));
                case ContainmentOperator.NotContains:
                    return queryable.Where(a => a.Name.Contains(name) == false);
                case ContainmentOperator.NotEquals:
                    return queryable.Where(a => a.Name != name);
                default:
                    return queryable.Where(a => a.Name == name);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Name"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="name">Name to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ByName(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, string name, params string[] additionalValues)
        {
            var nameList = new List<string> { name };

            if (additionalValues != null)
                nameList.AddRange(additionalValues);

            if (nameList.Count == 1)
                return queryable.ByName(nameList[0]);

            return queryable.ByName(nameList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.AspNetRoles.Name"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.AspNetRoles> ByName(this IQueryable<SmartSocial.Data.AspNetRoles> queryable, IEnumerable<string> values)
        {
            return queryable.Where(a => values.Contains(a.Name));
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
            internal static readonly Func<SmartSocial.Data.SmartSocialdbDataContext, string, SmartSocial.Data.AspNetRoles> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (SmartSocial.Data.SmartSocialdbDataContext db, string id) =>
                        db.AspNetRoles.FirstOrDefault(a => a.Id == id));

        }
        #endregion
    }
}
#pragma warning restore 1591