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
    /// The query extension class for Company.
    /// </summary>
    public static partial class CompanyExtensions
    {

        /// <summary>
        /// Gets an instance by the primary key.
        /// </summary>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static SmartSocial.Data.Company GetByKey(this IQueryable<SmartSocial.Data.Company> queryable, int idCompany)
        {
            var entity = queryable as System.Data.Linq.Table<SmartSocial.Data.Company>;
            if (entity != null && entity.Context.LoadOptions == null)
                return Query.GetByKey.Invoke((SmartSocial.Data.SmartSocialdbDataContext)entity.Context, idCompany);

            return queryable.FirstOrDefault(c => c.IdCompany == idCompany);
        }

        /// <summary>
        /// Immediately deletes the entity by the primary key from the underlying data source with a single delete command.
        /// </summary>
        /// <param name="table">Represents a table for a particular type in the underlying database containing rows are to be deleted.</param>
        /// <returns>The number of rows deleted from the database.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static int Delete(this System.Data.Linq.Table<SmartSocial.Data.Company> table, int idCompany)
        {
            return table.Delete(c => c.IdCompany == idCompany);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.IdCompany"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idCompany">IdCompany to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByIdCompany(this IQueryable<SmartSocial.Data.Company> queryable, int idCompany)
        {
            return queryable.Where(c => c.IdCompany == idCompany);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.IdCompany"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idCompany">IdCompany to search for. This is on the right side of the operator.</param>
        /// <param name="comparisonOperator">The comparison operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByIdCompany(this IQueryable<SmartSocial.Data.Company> queryable, ComparisonOperator comparisonOperator, int idCompany)
        {
            switch (comparisonOperator)
            {
                case ComparisonOperator.GreaterThan:
                    return queryable.Where(c => c.IdCompany > idCompany);
                case ComparisonOperator.GreaterThanOrEquals:
                    return queryable.Where(c => c.IdCompany >= idCompany);
                case ComparisonOperator.LessThan:
                    return queryable.Where(c => c.IdCompany < idCompany);
                case ComparisonOperator.LessThanOrEquals:
                    return queryable.Where(c => c.IdCompany <= idCompany);
                case ComparisonOperator.NotEquals:
                    return queryable.Where(c => c.IdCompany != idCompany);
                default:
                    return queryable.Where(c => c.IdCompany == idCompany);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.IdCompany"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="idCompany">IdCompany to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByIdCompany(this IQueryable<SmartSocial.Data.Company> queryable, int idCompany, params int[] additionalValues)
        {
            var idCompanyList = new List<int> { idCompany };

            if (additionalValues != null)
                idCompanyList.AddRange(additionalValues);

            if (idCompanyList.Count == 1)
                return queryable.ByIdCompany(idCompanyList[0]);

            return queryable.ByIdCompany(idCompanyList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.IdCompany"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByIdCompany(this IQueryable<SmartSocial.Data.Company> queryable, IEnumerable<int> values)
        {
            return queryable.Where(c => values.Contains(c.IdCompany));
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.CompanyName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="companyName">CompanyName to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByCompanyName(this IQueryable<SmartSocial.Data.Company> queryable, string companyName)
        {
            // support nulls
            return companyName == null 
                ? queryable.Where(c => c.CompanyName == null) 
                : queryable.Where(c => c.CompanyName == companyName);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.CompanyName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="companyName">CompanyName to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByCompanyName(this IQueryable<SmartSocial.Data.Company> queryable, ContainmentOperator containmentOperator, string companyName)
        {
            if (companyName == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("companyName", "Parameter 'companyName' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(c => c.CompanyName.Contains(companyName));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(c => c.CompanyName.StartsWith(companyName));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(c => c.CompanyName.EndsWith(companyName));
                case ContainmentOperator.NotContains:
                    return queryable.Where(c => c.CompanyName.Contains(companyName) == false);
                case ContainmentOperator.NotEquals:
                    return companyName == null 
                        ? queryable.Where(c => c.CompanyName != null) 
                        : queryable.Where(c => c.CompanyName != companyName);
                default:
                    return companyName == null 
                        ? queryable.Where(c => c.CompanyName == null) 
                        : queryable.Where(c => c.CompanyName == companyName);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.CompanyName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="companyName">CompanyName to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByCompanyName(this IQueryable<SmartSocial.Data.Company> queryable, string companyName, params string[] additionalValues)
        {
            var companyNameList = new List<string> { companyName };

            if (additionalValues != null)
                companyNameList.AddRange(additionalValues);
            else
                companyNameList.Add(null);

            if (companyNameList.Count == 1)
                return queryable.ByCompanyName(companyNameList[0]);

            return queryable.ByCompanyName(companyNameList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.CompanyName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByCompanyName(this IQueryable<SmartSocial.Data.Company> queryable, IEnumerable<string> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.Company, bool>("CompanyName", values);
            return queryable.Where(expression);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.LogoFileName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="logoFileName">LogoFileName to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByLogoFileName(this IQueryable<SmartSocial.Data.Company> queryable, string logoFileName)
        {
            // support nulls
            return logoFileName == null 
                ? queryable.Where(c => c.LogoFileName == null) 
                : queryable.Where(c => c.LogoFileName == logoFileName);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.LogoFileName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="logoFileName">LogoFileName to search for.</param>
        /// <param name="containmentOperator">The containment operator.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByLogoFileName(this IQueryable<SmartSocial.Data.Company> queryable, ContainmentOperator containmentOperator, string logoFileName)
        {
            if (logoFileName == null && containmentOperator != ContainmentOperator.Equals && containmentOperator != ContainmentOperator.NotEquals)
                throw new ArgumentNullException("logoFileName", "Parameter 'logoFileName' cannot be null with the specified ContainmentOperator.  Parameter 'containmentOperator' must be ContainmentOperator.Equals or ContainmentOperator.NotEquals to support null.");

            switch (containmentOperator)
            {
                case ContainmentOperator.Contains:
                    return queryable.Where(c => c.LogoFileName.Contains(logoFileName));
                case ContainmentOperator.StartsWith:
                    return queryable.Where(c => c.LogoFileName.StartsWith(logoFileName));
                case ContainmentOperator.EndsWith:
                    return queryable.Where(c => c.LogoFileName.EndsWith(logoFileName));
                case ContainmentOperator.NotContains:
                    return queryable.Where(c => c.LogoFileName.Contains(logoFileName) == false);
                case ContainmentOperator.NotEquals:
                    return logoFileName == null 
                        ? queryable.Where(c => c.LogoFileName != null) 
                        : queryable.Where(c => c.LogoFileName != logoFileName);
                default:
                    return logoFileName == null 
                        ? queryable.Where(c => c.LogoFileName == null) 
                        : queryable.Where(c => c.LogoFileName == logoFileName);
            }
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.LogoFileName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="logoFileName">LogoFileName to search for.</param>
        /// <param name="additionalValues">Additional values to search for.</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByLogoFileName(this IQueryable<SmartSocial.Data.Company> queryable, string logoFileName, params string[] additionalValues)
        {
            var logoFileNameList = new List<string> { logoFileName };

            if (additionalValues != null)
                logoFileNameList.AddRange(additionalValues);
            else
                logoFileNameList.Add(null);

            if (logoFileNameList.Count == 1)
                return queryable.ByLogoFileName(logoFileNameList[0]);

            return queryable.ByLogoFileName(logoFileNameList);
        }

        /// <summary>
        /// Gets a query for <see cref="SmartSocial.Data.Company.LogoFileName"/>.
        /// </summary>
        /// <param name="queryable">Query to append where clause.</param>
        /// <param name="values">The values to search for..</param>
        /// <returns><see cref="IQueryable"/> with additional where clause.</returns>
        [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
        public static IQueryable<SmartSocial.Data.Company> ByLogoFileName(this IQueryable<SmartSocial.Data.Company> queryable, IEnumerable<string> values)
        {
            // creating dynamic expression to support nulls
            var expression = DynamicExpression.BuildExpression<SmartSocial.Data.Company, bool>("LogoFileName", values);
            return queryable.Where(expression);
        }

        #region Query
        /// <summary>
        /// A private class for lazy loading static compiled queries.
        /// </summary>
        private static partial class Query
        {

            [System.CodeDom.Compiler.GeneratedCode("CodeSmith", "6.0.0.0")]
            internal static readonly Func<SmartSocial.Data.SmartSocialdbDataContext, int, SmartSocial.Data.Company> GetByKey =
                System.Data.Linq.CompiledQuery.Compile(
                    (SmartSocial.Data.SmartSocialdbDataContext db, int idCompany) =>
                        db.Company.FirstOrDefault(c => c.IdCompany == idCompany));

        }
        #endregion
    }
}
#pragma warning restore 1591
