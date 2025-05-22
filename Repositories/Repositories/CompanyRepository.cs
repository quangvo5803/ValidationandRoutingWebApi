using Data.Entities;
using Repositories.DataContext;
using Repositories.Interface;

namespace Repositories.Repositories
{
    public class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
        }
        public IEnumerable<Company> GetAllCompanies(bool trackChanges) =>
            FindAll(trackChanges).OrderBy(c => c.Name).ToList();
        public Company GetCompany(Guid companyId, bool trackChanges) =>
            FindByCondition(c => c.Id.Equals(companyId), trackChanges).SingleOrDefault();
        public void CreateCompany(Company company) => Create(company);
        public void UpdateCompany(Company company) => Update(company);
        public void DeleteCompany(Company company) => Delete(company);
        public IEnumerable<Company> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(c => ids.Contains(c.Id), trackChanges).ToList();
    }
    {
    }
}
