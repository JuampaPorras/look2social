using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class ServiceDeliveryRepository: EntityRepository<ServiceDelivery>, IServiceDeliveryRepository
    {
        public ServiceDeliveryRepository(SmartSocialContext context) : base(context) {  }
        public ServiceDeliveryRepository() : base() { }
    }
}
