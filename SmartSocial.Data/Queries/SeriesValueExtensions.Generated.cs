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
    /// The query extension class for SeriesValue.
    /// </summary>
    public static partial class SeriesValueExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SmartSocial.Data.SeriesValue GetByKey(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int idSeriesValue)
        {
            var entity = queryable as System.Data.Linq.Table<SmartSocial.Data.SeriesValue>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((SmartSocial.Data.SmartSocialdbDataContext)entity.Context, idSeriesValue);

            return queryable.FirstOrDefault(s => s.IdSeriesValue == idSeriesValue);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static int Delete(this System.Data.Linq.Table<SmartSocial.Data.SeriesValue> table, int idSeriesValue)
        {
            return table.Delete(s => s.IdSeriesValue == idSeriesValue);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdSeriesValue"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSeriesValue">IdSeriesValue to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdSeriesValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int idSeriesValue)
        {
            return queryable.Where(s => s.IdSeriesValue == idSeriesValue);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdSeriesValue"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSeriesValue">IdSeriesValue to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdSeriesValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, ComparisonOperator comparisonOperator, int idSeriesValue)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.IdSeriesValue > idSeriesValue);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.IdSeriesValue >= idSeriesValue);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.IdSeriesValue < idSeriesValue);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.IdSeriesValue <= idSeriesValue);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(s => s.IdSeriesValue != idSeriesValue);
                default:
                    return queryable.Where(s => s.IdSeriesValue == idSeriesValue);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdSeriesValue"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idSeriesValue">IdSeriesValue to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdSeriesValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int idSeriesValue, params int[] additionalValues)
        {
            var idSeriesValueList = new List<int> { idSeriesValue };

            if (additionalValues != null)
                idSeriesValueList.AddRange(additionalValues);

            if (idSeriesValueList.Count == 1)
                return queryable.ByIdSeriesValue(idSeriesValueList[0]);

            return queryable.ByIdSeriesValue(idSeriesValueList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdSeriesValue"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdSeriesValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, IEnumerable<int> values)
        {
            return queryable.Where(s => values.Contains(s.IdSeriesValue));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdChartSeries"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idChartSeries">IdChartSeries to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdChartSeries(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int? idChartSeries)
        {
            // support nulls
            return idChartSeries == null 
                ? queryable.Where(s => s.IdChartSeries == null) 
                : queryable.Where(s => s.IdChartSeries == idChartSeries);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdChartSeries"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idChartSeries">IdChartSeries to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdChartSeries(this IQueryable<SmartSocial.Data.SeriesValue> queryable, ComparisonOperator comparisonOperator, int? idChartSeries)
        {
            if (idChartSeries == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("idChartSeries", "Parameter 'idChartSeries' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.IdChartSeries > idChartSeries);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.IdChartSeries >= idChartSeries);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.IdChartSeries < idChartSeries);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.IdChartSeries <= idChartSeries);
                case ComparisonOperator.NotEquals:
                    return idChartSeries == null 
                        ? queryable.Where(s => s.IdChartSeries != null) 
                        : queryable.Where(s => s.IdChartSeries != idChartSeries);
                default:
                    return idChartSeries == null 
                        ? queryable.Where(s => s.IdChartSeries == null) 
                        : queryable.Where(s => s.IdChartSeries == idChartSeries);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdChartSeries"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idChartSeries">IdChartSeries to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdChartSeries(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int? idChartSeries, params int?[] additionalValues)
        {
            var idChartSeriesList = new List<int?> { idChartSeries };

            if (additionalValues != null)
                idChartSeriesList.AddRange(additionalValues);
            else
                idChartSeriesList.Add(null);

            if (idChartSeriesList.Count == 1)
                return queryable.ByIdChartSeries(idChartSeriesList[0]);

            return queryable.ByIdChartSeries(idChartSeriesList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdChartSeries"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdChartSeries(this IQueryable<SmartSocial.Data.SeriesValue> queryable, IEnumerable<int?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SeriesValue, bool>("IdChartSeries", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdDataType"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idDataType">IdDataType to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdDataType(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int? idDataType)
        {
            // support nulls
            return idDataType == null 
                ? queryable.Where(s => s.IdDataType == null) 
                : queryable.Where(s => s.IdDataType == idDataType);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdDataType"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idDataType">IdDataType to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdDataType(this IQueryable<SmartSocial.Data.SeriesValue> queryable, ComparisonOperator comparisonOperator, int? idDataType)
        {
            if (idDataType == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("idDataType", "Parameter 'idDataType' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.IdDataType > idDataType);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.IdDataType >= idDataType);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.IdDataType < idDataType);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.IdDataType <= idDataType);
                case ComparisonOperator.NotEquals:
                    return idDataType == null 
                        ? queryable.Where(s => s.IdDataType != null) 
                        : queryable.Where(s => s.IdDataType != idDataType);
                default:
                    return idDataType == null 
                        ? queryable.Where(s => s.IdDataType == null) 
                        : queryable.Where(s => s.IdDataType == idDataType);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdDataType"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idDataType">IdDataType to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdDataType(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int? idDataType, params int?[] additionalValues)
        {
            var idDataTypeList = new List<int?> { idDataType };

            if (additionalValues != null)
                idDataTypeList.AddRange(additionalValues);
            else
                idDataTypeList.Add(null);

            if (idDataTypeList.Count == 1)
                return queryable.ByIdDataType(idDataTypeList[0]);

            return queryable.ByIdDataType(idDataTypeList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.IdDataType"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByIdDataType(this IQueryable<SmartSocial.Data.SeriesValue> queryable, IEnumerable<int?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SeriesValue, bool>("IdDataType", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.Value"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="value">Value to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, string value)
        {
            // support nulls
            return value == null 
                ? queryable.Where(s => s.Value == null) 
                : queryable.Where(s => s.Value == value);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.Value"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="value">Value to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, ContainmentOperator containmentOperator, string value)
        {
            if (value == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("value", "Parameter 'value' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(s => s.Value.Contains(value));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(s => s.Value.StartsWith(value));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(s => s.Value.EndsWith(value));
                case ContainmentOperator.NotContains:
                    return queryable.Where(s => s.Value.Contains(value) == false);
                case ContainmentOperator.NotEquals:
                    return value == null 
                        ? queryable.Where(s => s.Value != null) 
                        : queryable.Where(s => s.Value != value);
                default:
                    return value == null 
                        ? queryable.Where(s => s.Value == null) 
                        : queryable.Where(s => s.Value == value);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.Value"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="value">Value to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, string value, params string[] additionalValues)
        {
            var valueList = new List<string> { value };

            if (additionalValues != null)
                valueList.AddRange(additionalValues);
            else
                valueList.Add(null);

            if (valueList.Count == 1)
                return queryable.ByValue(valueList[0]);

            return queryable.ByValue(valueList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.Value"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByValue(this IQueryable<SmartSocial.Data.SeriesValue> queryable, IEnumerable<string> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SeriesValue, bool>("Value", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.RowPosition"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="rowPosition">RowPosition to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByRowPosition(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int? rowPosition)
        {
            // support nulls
            return rowPosition == null 
                ? queryable.Where(s => s.RowPosition == null) 
                : queryable.Where(s => s.RowPosition == rowPosition);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.RowPosition"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="rowPosition">RowPosition to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByRowPosition(this IQueryable<SmartSocial.Data.SeriesValue> queryable, ComparisonOperator comparisonOperator, int? rowPosition)
        {
            if (rowPosition == null && comparisonOperator != ComparisonOperator.Equals && comparisonOperator != ComparisonOperator.NotEquals)
                throw new ArgumentNullException("rowPosition", "Parameter 'rowPosition' cannot be null with the specified ComparisonOperator.  Parameter 'comparisonOperator' must be ComparisonOperator.Equals or ComparisonOperator.NotEquals to support null.");

            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(s => s.RowPosition > rowPosition);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(s => s.RowPosition >= rowPosition);
                case ComparisonOperator.LessThan:
                    return queryable.Where(s => s.RowPosition < rowPosition);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(s => s.RowPosition <= rowPosition);
                case ComparisonOperator.NotEquals:
                    return rowPosition == null 
                        ? queryable.Where(s => s.RowPosition != null) 
                        : queryable.Where(s => s.RowPosition != rowPosition);
                default:
                    return rowPosition == null 
                        ? queryable.Where(s => s.RowPosition == null) 
                        : queryable.Where(s => s.RowPosition == rowPosition);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.RowPosition"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="rowPosition">RowPosition to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByRowPosition(this IQueryable<SmartSocial.Data.SeriesValue> queryable, int? rowPosition, params int?[] additionalValues)
        {
            var rowPositionList = new List<int?> { rowPosition };

            if (additionalValues != null)
                rowPositionList.AddRange(additionalValues);
            else
                rowPositionList.Add(null);

            if (rowPositionList.Count == 1)
                return queryable.ByRowPosition(rowPositionList[0]);

            return queryable.ByRowPosition(rowPositionList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.SeriesValue.RowPosition"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.SeriesValue> ByRowPosition(this IQueryable<SmartSocial.Data.SeriesValue> queryable, IEnumerable<int?> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.SeriesValue, bool>("RowPosition", values);
            return queryable.Where(expression);
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
            internal static readonly Func<SmartSocial.Data.SmartSocialdbDataContext, int, SmartSocial.Data.SeriesValue> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (SmartSocial.Data.SmartSocialdbDataContext db, int idSeriesValue) =>
                        db.SeriesValue.FirstOrDefault(s => s.IdSeriesValue == idSeriesValue));

        }
        #endregion
    }
}
#pragma warning restore 1591