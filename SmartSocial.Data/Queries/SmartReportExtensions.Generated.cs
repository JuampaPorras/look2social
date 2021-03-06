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
    /// The query extension class for SmartReport.
    /// </summary>
    public static partial class SmartReportExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SmartSocial.Data.SmartReport GetByKey(this IQueryable<SmartSocial.Data.SmartReport> queryable, int idSmartReport)
        {
            var entity = queryable as System.Data.Linq.Table<SmartSocial.Data.SmartReport>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((SmartSocial.Data.SmartSocialdbDataContext)entity.Context, idSmartReport);

            return queryable.FirstOrDefault(s => s.IdSmartReport == idSmartReport);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static int Delete(this System.Data.Linq.Table<SmartSocial.Data.SmartReport> table, int idSmartReport)
        {
            return table.Delete(s => s.IdSmartReport == idSmartReport);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdSmartReport"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSmartReport">IdSmartReport to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdSmartReport(this IQueryable<SmartSocial.Data.SmartReport> queryable, int idSmartReport)
        {
            return queryable.Where(s => s.IdSmartReport == idSmartReport);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdSmartReport"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSmartReport">IdSmartReport to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdSmartReport(this IQueryable<SmartSocial.Data.SmartReport> queryable, ComparisonOperator comparisonOperator, int idSmartReport)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.IdSmartReport > idSmartReport);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.IdSmartReport >= idSmartReport);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.IdSmartReport < idSmartReport);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.IdSmartReport <= idSmartReport);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(s => s.IdSmartReport != idSmartReport);
                default:
                    return queryable.Where(s => s.IdSmartReport == idSmartReport);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdSmartReport"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSmartReport">IdSmartReport to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdSmartReport(this IQueryable<SmartSocial.Data.SmartReport> queryable, int idSmartReport, params int[] additionalValues)
        {
            var idSmartReportList = new List<int> { idSmartReport };

            if (additionalValues != null)
                idSmartReportList.AddRange(additionalValues);

            if (idSmartReportList.Count == 1)
                return queryable.ByIdSmartReport(idSmartReportList[0]);

            return queryable.ByIdSmartReport(idSmartReportList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdSmartReport"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdSmartReport(this IQueryable<SmartSocial.Data.SmartReport> queryable, IEnumerable<int> values)
        {
            return queryable.Where(s => values.Contains(s.IdSmartReport));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdServiceDelivery"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idServiceDelivery">IdServiceDelivery to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdServiceDelivery(this IQueryable<SmartSocial.Data.SmartReport> queryable, int? idServiceDelivery)
        {
            // support nulls
            return idServiceDelivery == null 
                ? queryable.Where(s => s.IdServiceDelivery == null) 
                : queryable.Where(s => s.IdServiceDelivery == idServiceDelivery);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdServiceDelivery"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idServiceDelivery">IdServiceDelivery to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdServiceDelivery(this IQueryable<SmartSocial.Data.SmartReport> queryable, ComparisonOperator comparisonOperator, int? idServiceDelivery)
        {
            if (idServiceDelivery == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("idServiceDelivery", "Parameter 'idServiceDelivery' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.IdServiceDelivery > idServiceDelivery);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.IdServiceDelivery >= idServiceDelivery);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.IdServiceDelivery < idServiceDelivery);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.IdServiceDelivery <= idServiceDelivery);
                case ComparisonOperator.NotEquals:
                    return idServiceDelivery == null 
                        ? queryable.Where(s => s.IdServiceDelivery != null) 
                        : queryable.Where(s => s.IdServiceDelivery != idServiceDelivery);
                default:
                    return idServiceDelivery == null 
                        ? queryable.Where(s => s.IdServiceDelivery == null) 
                        : queryable.Where(s => s.IdServiceDelivery == idServiceDelivery);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdServiceDelivery"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idServiceDelivery">IdServiceDelivery to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdServiceDelivery(this IQueryable<SmartSocial.Data.SmartReport> queryable, int? idServiceDelivery, params int?[] additionalValues)
        {
            var idServiceDeliveryList = new List<int?> { idServiceDelivery };

            if (additionalValues != null)
                idServiceDeliveryList.AddRange(additionalValues);
            else
                idServiceDeliveryList.Add(null);

            if (idServiceDeliveryList.Count == 1)
                return queryable.ByIdServiceDelivery(idServiceDeliveryList[0]);

            return queryable.ByIdServiceDelivery(idServiceDeliveryList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IdServiceDelivery"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIdServiceDelivery(this IQueryable<SmartSocial.Data.SmartReport> queryable, IEnumerable<int?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SmartReport, bool>("IdServiceDelivery", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.ReportName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="reportName">ReportName to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByReportName(this IQueryable<SmartSocial.Data.SmartReport> queryable, string reportName)
        {
            // support nulls
            return reportName == null 
                ? queryable.Where(s => s.ReportName == null) 
                : queryable.Where(s => s.ReportName == reportName);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.ReportName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="reportName">ReportName to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByReportName(this IQueryable<SmartSocial.Data.SmartReport> queryable, ContainmentOperator containmentOperator, string reportName)
        {
            if (reportName == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("reportName", "Parameter 'reportName' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(s => s.ReportName.Contains(reportName));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(s => s.ReportName.StartsWith(reportName));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(s => s.ReportName.EndsWith(reportName));
                case ContainmentOperator.NotContains:
                    return queryable.Where(s => s.ReportName.Contains(reportName) == false);
                case ContainmentOperator.NotEquals:
                    return reportName == null 
                        ? queryable.Where(s => s.ReportName != null) 
                        : queryable.Where(s => s.ReportName != reportName);
                default:
                    return reportName == null 
                        ? queryable.Where(s => s.ReportName == null) 
                        : queryable.Where(s => s.ReportName == reportName);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.ReportName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="reportName">ReportName to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByReportName(this IQueryable<SmartSocial.Data.SmartReport> queryable, string reportName, params string[] additionalValues)
        {
            var reportNameList = new List<string> { reportName };

            if (additionalValues != null)
                reportNameList.AddRange(additionalValues);
            else
                reportNameList.Add(null);

            if (reportNameList.Count == 1)
                return queryable.ByReportName(reportNameList[0]);

            return queryable.ByReportName(reportNameList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.ReportName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByReportName(this IQueryable<SmartSocial.Data.SmartReport> queryable, IEnumerable<string> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SmartReport, bool>("ReportName", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.Insights"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="insights">Insights to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByInsights(this IQueryable<SmartSocial.Data.SmartReport> queryable, string insights)
        {
            // support nulls
            return insights == null 
                ? queryable.Where(s => s.Insights == null) 
                : queryable.Where(s => s.Insights == insights);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.Insights"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="insights">Insights to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByInsights(this IQueryable<SmartSocial.Data.SmartReport> queryable, ContainmentOperator containmentOperator, string insights)
        {
            if (insights == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("insights", "Parameter 'insights' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(s => s.Insights.Contains(insights));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(s => s.Insights.StartsWith(insights));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(s => s.Insights.EndsWith(insights));
                case ContainmentOperator.NotContains:
                    return queryable.Where(s => s.Insights.Contains(insights) == false);
                case ContainmentOperator.NotEquals:
                    return insights == null 
                        ? queryable.Where(s => s.Insights != null) 
                        : queryable.Where(s => s.Insights != insights);
                default:
                    return insights == null 
                        ? queryable.Where(s => s.Insights == null) 
                        : queryable.Where(s => s.Insights == insights);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.Insights"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="insights">Insights to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByInsights(this IQueryable<SmartSocial.Data.SmartReport> queryable, string insights, params string[] additionalValues)
        {
            var insightsList = new List<string> { insights };

            if (additionalValues != null)
                insightsList.AddRange(additionalValues);
            else
                insightsList.Add(null);

            if (insightsList.Count == 1)
                return queryable.ByInsights(insightsList[0]);

            return queryable.ByInsights(insightsList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.Insights"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByInsights(this IQueryable<SmartSocial.Data.SmartReport> queryable, IEnumerable<string> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SmartReport, bool>("Insights", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="dateCreated">DateCreated to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByDateCreated(this IQueryable<SmartSocial.Data.SmartReport> queryable, System.DateTime? dateCreated)
        {
            // support nulls
            return dateCreated == null 
                ? queryable.Where(s => s.DateCreated == null) 
                : queryable.Where(s => s.DateCreated == dateCreated);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="dateCreated">DateCreated to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByDateCreated(this IQueryable<SmartSocial.Data.SmartReport> queryable, ComparisonOperator comparisonOperator, System.DateTime? dateCreated)
        {
            if (dateCreated == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("dateCreated", "Parameter 'dateCreated' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.DateCreated > dateCreated);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.DateCreated >= dateCreated);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.DateCreated < dateCreated);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.DateCreated <= dateCreated);
                case ComparisonOperator.NotEquals:
                    return dateCreated == null 
                        ? queryable.Where(s => s.DateCreated != null) 
                        : queryable.Where(s => s.DateCreated != dateCreated);
                default:
                    return dateCreated == null 
                        ? queryable.Where(s => s.DateCreated == null) 
                        : queryable.Where(s => s.DateCreated == dateCreated);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="dateCreated">DateCreated to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByDateCreated(this IQueryable<SmartSocial.Data.SmartReport> queryable, System.DateTime? dateCreated, params System.DateTime?[] additionalValues)
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
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.DateCreated"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByDateCreated(this IQueryable<SmartSocial.Data.SmartReport> queryable, IEnumerable<System.DateTime?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SmartReport, bool>("DateCreated", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IsTemplate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="isTemplate">IsTemplate to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIsTemplate(this IQueryable<SmartSocial.Data.SmartReport> queryable, bool? isTemplate)
        {
            // support nulls
            return isTemplate == null 
                ? queryable.Where(s => s.IsTemplate == null) 
                : queryable.Where(s => s.IsTemplate == isTemplate);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IsTemplate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="isTemplate">IsTemplate to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIsTemplate(this IQueryable<SmartSocial.Data.SmartReport> queryable, ComparisonOperator comparisonOperator, bool? isTemplate)
        {
            if (isTemplate == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("isTemplate", "Parameter 'isTemplate' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                case ComparisonOperator.GreaterThanOrEquals:
                case ComparisonOperator.LessThan:
                case ComparisonOperator.LessThanOrEquals:
                    throw new ArgumentException("Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support bool? type.", "comparisonOperator");
                case ComparisonOperator.NotEquals:
                    return isTemplate == null 
                        ? queryable.Where(s => s.IsTemplate != null) 
                        : queryable.Where(s => s.IsTemplate != isTemplate);
                default:
                    return isTemplate == null 
                        ? queryable.Where(s => s.IsTemplate == null) 
                        : queryable.Where(s => s.IsTemplate == isTemplate);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IsTemplate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="isTemplate">IsTemplate to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIsTemplate(this IQueryable<SmartSocial.Data.SmartReport> queryable, bool? isTemplate, params bool?[] additionalValues)
        {
            var isTemplateList = new List<bool?> { isTemplate };

            if (additionalValues != null)
                isTemplateList.AddRange(additionalValues);
            else
                isTemplateList.Add(null);

            if (isTemplateList.Count == 1)
                return queryable.ByIsTemplate(isTemplateList[0]);

            return queryable.ByIsTemplate(isTemplateList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SmartReport.IsTemplate"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SmartReport> ByIsTemplate(this IQueryable<SmartSocial.Data.SmartReport> queryable, IEnumerable<bool?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SmartReport, bool>("IsTemplate", values);
            return queryable.Where(expression);
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
            internal static readonly Func<SmartSocial.Data.SmartSocialdbDataContext, int, SmartSocial.Data.SmartReport> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (SmartSocial.Data.SmartSocialdbDataContext db, int idSmartReport) =>
                        db.SmartReport.FirstOrDefault(s => s.IdSmartReport == idSmartReport));

        }
        #endregion
    }
}
#pragma warning restore 1591
