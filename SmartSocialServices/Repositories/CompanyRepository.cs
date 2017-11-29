using SmartSocial.Data.V2;
using SmartSocialServices.Repositories.Interface;

namespace SmartSocialServices.Repositories
{
    public class CompanyRepository: EntityRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(SmartSocialContext context) : base(context) {  }
        public CompanyRepository() : base() { }
    }
}
