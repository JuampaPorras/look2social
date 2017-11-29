using System.Data.Entity.Core.Objects;
using Ninject.Modules;
using SmartSocial.Data.V2;
using SmartSocialServices.Repositories;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Modules
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ObjectContext>().To<SmartSocialContext>();
            Bind<SmartSocialContext>().ToMethod(context => new SmartSocialContext());

            Bind<IChartCommentRepository>().To<ChartCommentRepository>();
        }

    }
}
