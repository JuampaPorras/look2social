using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;


namespace SmartSocialServices.Repositories
{
    public class LeadRepository: EntityRepository<Lead>, ILeadRepository
    {
        public LeadRepository(SmartSocialContext context) : base(context) {  }
        public LeadRepository() : base() { }
    }
}
