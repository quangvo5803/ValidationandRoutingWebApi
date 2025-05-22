using Repositories.DataContext;
using Repositories.Interface;

namespace Repositories.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _db;
        private ICompanyRepository _companyRepository;
        private IEmployeeRepository _employeeRepository;

        public RepositoryManager(ApplicationDbContext db)
        {
            _db = db;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (_companyRepository == null)
                {
                    _companyRepository = new CompanyRepository(_db);
                }
                return _companyRepository;
            }
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employeeRepository == null)
                {
                    _employeeRepository = new EmployeeRepository(_db);
                }
                return _employeeRepository;
            }
        }

        public void Save() => _db.SaveChanges();
    }
}
