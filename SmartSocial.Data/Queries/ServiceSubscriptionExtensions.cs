using System;
using System.Linq;
using CodeSmith.Data.Linq;

namespace SmartSocial.Data
{
    public static partial class ServiceSubscriptionExtensions
    {
        // Place custom query extensions here.
        public static IQueryable<ServiceSubscription> ByUserIdAndActive(this IQueryable<ServiceSubscription> queryable, String userId)
        {
            //TODO
            SmartSocialdbDataContext dbContext = (SmartSocialdbDataContext)queryable.GetDataContext();

            var queryByUser =  dbContext.UsersXSubscription.ByIdUser(userId);

            var queryFinal = queryable.
                            ByIsActive(true).
                            ByStartDate(ComparisonOperator.LessThanOrEquals,DateTime.Now).
                            ByEndDate(ComparisonOperator.GreaterThanOrEquals, DateTime.Now);

            return queryFinal;          
           
        }

        #region Query
        // A private class for lazy loading static compiled queries.
        private static partial class Query
        {
            // Place custom compiled queries here. 
        } 
        #endregion
    }
}