using Data.Entities;
using Repositories.DataContext;
using Repositories.Interface;

namespace Repositories.Repositories
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext db)
            : base(db) { }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
            FindAll(trackChanges).OrderBy(e => e.Name).ToList();

        public Employee GetEmployee(Guid employeeId, bool trackChanges) =>
            FindByCondition(e => e.Id.Equals(employeeId), trackChanges).SingleOrDefault();

        public void CreateEmployee(Employee employee) => Create(employee);

        public void UpdateEmployee(Employee employee) => Update(employee);

        public void DeleteEmployee(Employee employee) => Delete(employee);

        public IEnumerable<Employee> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
            FindByCondition(e => ids.Contains(e.Id), trackChanges).ToList();

        public void CreateEmployeeForCompany(Guid companyId, Employee employee)
        {
            employee.CompanyId = companyId;
            Create(employee);
        }
    }
}
