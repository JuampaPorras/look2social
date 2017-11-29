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
    /// The query extension class for ServiceSubscription.
    /// </summary>
    public static partial class ServiceSubscriptionExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SmartSocial.Data.ServiceSubscription GetByKey(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, int idServiceSubscription)
        {
            var entity = queryable as System.Data.Linq.Table<SmartSocial.Data.ServiceSubscription>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((SmartSocial.Data.SmartSocialdbDataContext)entity.Context, idServiceSubscription);

            return queryable.FirstOrDefault(s => s.IdServiceSubscription == idServiceSubscription);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static int Delete(this System.Data.Linq.Table<SmartSocial.Data.ServiceSubscription> table, int idServiceSubscription)
        {
            return table.Delete(s => s.IdServiceSubscription == idServiceSubscription);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IdServiceSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idServiceSubscription">IdServiceSubscription to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIdServiceSubscription(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, int idServiceSubscription)
        {
            return queryable.Where(s => s.IdServiceSubscription == idServiceSubscription);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IdServiceSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idServiceSubscription">IdServiceSubscription to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIdServiceSubscription(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, ComparisonOperator comparisonOperator, int idServiceSubscription)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.IdServiceSubscription > idServiceSubscription);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.IdServiceSubscription >= idServiceSubscription);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.IdServiceSubscription < idServiceSubscription);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.IdServiceSubscription <= idServiceSubscription);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(s => s.IdServiceSubscription != idServiceSubscription);
                default:
                    return queryable.Where(s => s.IdServiceSubscription == idServiceSubscription);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IdServiceSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idServiceSubscription">IdServiceSubscription to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIdServiceSubscription(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, int idServiceSubscription, params int[] additionalValues)
        {
            var idServiceSubscriptionList = new List<int> { idServiceSubscription };

            if (additionalValues != null)
                idServiceSubscriptionList.AddRange(additionalValues);

            if (idServiceSubscriptionList.Count == 1)
                return queryable.ByIdServiceSubscription(idServiceSubscriptionList[0]);

            return queryable.ByIdServiceSubscription(idServiceSubscriptionList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IdServiceSubscription"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIdServiceSubscription(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, IEnumerable<int> values)
        {
            return queryable.Where(s => values.Contains(s.IdServiceSubscription));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.SubscriptionName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="subscriptionName">SubscriptionName to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> BySubscriptionName(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, string subscriptionName)
        {
            // support nulls
            return subscriptionName == null 
                ? queryable.Where(s => s.SubscriptionName == null) 
                : queryable.Where(s => s.SubscriptionName == subscriptionName);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.SubscriptionName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="subscriptionName">SubscriptionName to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> BySubscriptionName(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, ContainmentOperator containmentOperator, string subscriptionName)
        {
            if (subscriptionName == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("subscriptionName", "Parameter 'subscriptionName' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(s => s.SubscriptionName.Contains(subscriptionName));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(s => s.SubscriptionName.StartsWith(subscriptionName));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(s => s.SubscriptionName.EndsWith(subscriptionName));
                case ContainmentOperator.NotContains:
                    return queryable.Where(s => s.SubscriptionName.Contains(subscriptionName) == false);
                case ContainmentOperator.NotEquals:
                    return subscriptionName == null 
                        ? queryable.Where(s => s.SubscriptionName != null) 
                        : queryable.Where(s => s.SubscriptionName != subscriptionName);
                default:
                    return subscriptionName == null 
                        ? queryable.Where(s => s.SubscriptionName == null) 
                        : queryable.Where(s => s.SubscriptionName == subscriptionName);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.SubscriptionName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="subscriptionName">SubscriptionName to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> BySubscriptionName(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, string subscriptionName, params string[] additionalValues)
        {
            var subscriptionNameList = new List<string> { subscriptionName };

            if (additionalValues != null)
                subscriptionNameList.AddRange(additionalValues);
            else
                subscriptionNameList.Add(null);

            if (subscriptionNameList.Count == 1)
                return queryable.BySubscriptionName(subscriptionNameList[0]);

            return queryable.BySubscriptionName(subscriptionNameList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.SubscriptionName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> BySubscriptionName(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, IEnumerable<string> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.ServiceSubscription, bool>("SubscriptionName", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.StartDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="startDate">StartDate to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByStartDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, System.DateTime? startDate)
        {
            // support nulls
            return startDate == null 
                ? queryable.Where(s => s.StartDate == null) 
                : queryable.Where(s => s.StartDate == startDate);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.StartDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="startDate">StartDate to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByStartDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, ComparisonOperator comparisonOperator, System.DateTime? startDate)
        {
            if (startDate == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("startDate", "Parameter 'startDate' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.StartDate > startDate);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.StartDate >= startDate);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.StartDate < startDate);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.StartDate <= startDate);
                case ComparisonOperator.NotEquals:
                    return startDate == null 
                        ? queryable.Where(s => s.StartDate != null) 
                        : queryable.Where(s => s.StartDate != startDate);
                default:
                    return startDate == null 
                        ? queryable.Where(s => s.StartDate == null) 
                        : queryable.Where(s => s.StartDate == startDate);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.StartDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="startDate">StartDate to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByStartDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, System.DateTime? startDate, params System.DateTime?[] additionalValues)
        {
            var startDateList = new List<System.DateTime?> { startDate };

            if (additionalValues != null)
                startDateList.AddRange(additionalValues);
            else
                startDateList.Add(null);

            if (startDateList.Count == 1)
                return queryable.ByStartDate(startDateList[0]);

            return queryable.ByStartDate(startDateList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.StartDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByStartDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, IEnumerable<System.DateTime?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.ServiceSubscription, bool>("StartDate", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.EndDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="endDate">EndDate to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByEndDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, System.DateTime? endDate)
        {
            // support nulls
            return endDate == null 
                ? queryable.Where(s => s.EndDate == null) 
                : queryable.Where(s => s.EndDate == endDate);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.EndDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="endDate">EndDate to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByEndDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, ComparisonOperator comparisonOperator, System.DateTime? endDate)
        {
            if (endDate == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("endDate", "Parameter 'endDate' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.EndDate > endDate);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.EndDate >= endDate);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.EndDate < endDate);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.EndDate <= endDate);
                case ComparisonOperator.NotEquals:
                    return endDate == null 
                        ? queryable.Where(s => s.EndDate != null) 
                        : queryable.Where(s => s.EndDate != endDate);
                default:
                    return endDate == null 
                        ? queryable.Where(s => s.EndDate == null) 
                        : queryable.Where(s => s.EndDate == endDate);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.EndDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="endDate">EndDate to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByEndDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, System.DateTime? endDate, params System.DateTime?[] additionalValues)
        {
            var endDateList = new List<System.DateTime?> { endDate };

            if (additionalValues != null)
                endDateList.AddRange(additionalValues);
            else
                endDateList.Add(null);

            if (endDateList.Count == 1)
                return queryable.ByEndDate(endDateList[0]);

            return queryable.ByEndDate(endDateList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.EndDate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByEndDate(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, IEnumerable<System.DateTime?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.ServiceSubscription, bool>("EndDate", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IsActive"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="isActive">IsActive to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIsActive(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, bool? isActive)
        {
            // support nulls
            return isActive == null 
                ? queryable.Where(s => s.IsActive == null) 
                : queryable.Where(s => s.IsActive == isActive);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IsActive"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="isActive">IsActive to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIsActive(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, ComparisonOperator comparisonOperator, bool? isActive)
        {
            if (isActive == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("isActive", "Parameter 'isActive' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                case ComparisonOperator.GreaterThanOrEquals:
                case ComparisonOperator.LessThan:
                case ComparisonOperator.LessThanOrEquals:
                    throw new ArgumentException("Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support bool? type.", "comparisonOperator");
                case ComparisonOperator.NotEquals:
                    return isActive == null 
                        ? queryable.Where(s => s.IsActive != null) 
                        : queryable.Where(s => s.IsActive != isActive);
                default:
                    return isActive == null 
                        ? queryable.Where(s => s.IsActive == null) 
                        : queryable.Where(s => s.IsActive == isActive);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IsActive"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="isActive">IsActive to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIsActive(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, bool? isActive, params bool?[] additionalValues)
        {
            var isActiveList = new List<bool?> { isActive };

            if (additionalValues != null)
                isActiveList.AddRange(additionalValues);
            else
                isActiveList.Add(null);

            if (isActiveList.Count == 1)
                return queryable.ByIsActive(isActiveList[0]);

            return queryable.ByIsActive(isActiveList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.ServiceSubscription.IsActive"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.ServiceSubscription> ByIsActive(this IQueryable<SmartSocial.Data.ServiceSubscription> queryable, IEnumerable<bool?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.ServiceSubscription, bool>("IsActive", values);
            return queryable.Where(expression);
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
            internal static readonly Func<SmartSocial.Data.SmartSocialdbDataContext, int, SmartSocial.Data.ServiceSubscription> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (SmartSocial.Data.SmartSocialdbDataContext db, int idServiceSubscription) =>
                        db.ServiceSubscription.FirstOrDefault(s => s.IdServiceSubscription == idServiceSubscription));

        }
        #endregion
    }
}
#pragma warning restore 1591
