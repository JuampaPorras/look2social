using Ninject;
using Ninject.Modules;
using SmartSocialServices.Modules;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices
{
    public class ServiceLocator
    {
        private static readonly IKernel _kernel = new StandardKernel(new INinjectModule[] { new RepositoryModule() });
        #region Kernel Repository Module  Get

        public static IChartCommentRepository CreateChartCommentRepository()
        {
            return _kernel.Get<IChartCommentRepository>();
        }

        public static IServiceSubscriptionRepository CreateServiceSubscriptionRepository()
        {
            return _kernel.Get<IServiceSubscriptionRepository>();
        }

        public static IServiceDeliveryRepository CreateServiceDeliveryRepository()
        {
            return _kernel.Get<IServiceDeliveryRepository>();
        }

        public static IUsersXSubscriptionRepository CreateUsersXSubscriptionRepository()
        {
            return _kernel.Get<IUsersXSubscriptionRepository>();
        }

        public static ISmartReportRepository CreateSmartReportRepository()
        {
            return _kernel.Get<ISmartReportRepository>();
        }

        public static ISmartChartRepository CreateSmartChartRepository()
        {
            return _kernel.Get<ISmartChartRepository>();
        }

        public static ICompanyRepository CreateCompanyRepository()
        {
            return _kernel.Get<ICompanyRepository>();
        }

        public static ISharedReportRepository CreateSharedReportRepository()
        {
            return _kernel.Get<ISharedReportRepository>();
        }

        public static ILeadRepository CreateLeadRepository()
        {
            return _kernel.Get<ILeadRepository>();
        }

        public static IWebMembershipRepository CreateWebMembershipRepository()
        {
            return _kernel.Get<IWebMembershipRepository>();
        }

        public static INotificationRepository CreateNotificationRepository()
        {
            return _kernel.Get<INotificationRepository>();
        }


        #endregion
    }
}
