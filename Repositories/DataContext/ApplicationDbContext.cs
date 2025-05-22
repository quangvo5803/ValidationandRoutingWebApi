using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Company>()
                .HasData(
                    new Company
                    {
                        Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                        Name = "Company A",
                        Address = "123 Main St, City A",
                        Country = "Vietnam",
                    },
                    new Company
                    {
                        Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                        Name = "Company B",
                        Address = "456 Second St, City B",
                        Country = "USA",
                    },
                    new Company
                    {
                        Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                        Name = "Company C",
                        Address = "789 Third St, City C",
                        Country = "Japan",
                    }
                );

            modelBuilder
                .Entity<Employee>()
                .HasData(
                    // Employees of Company A
                    new Employee
                    {
                        Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                        Name = "John Doe",
                        Age = 30,
                        Position = "Developer",
                        CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    },
                    new Employee
                    {
                        Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                        Name = "Jane Smith",
                        Age = 28,
                        Position = "Designer",
                        CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    },
                    new Employee
                    {
                        Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                        Name = "Bob Johnson",
                        Age = 35,
                        Position = "Manager",
                        CompanyId = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                    },
                    // Employees of Company B
                    new Employee
                    {
                        Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                        Name = "Alice Brown",
                        Age = 26,
                        Position = "Developer",
                        CompanyId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    },
                    new Employee
                    {
                        Id = Guid.Parse("eeeeeeee-eeee-eeee-eeee-eeeeeeeeeeee"),
                        Name = "Tom White",
                        Age = 32,
                        Position = "Tester",
                        CompanyId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    },
                    new Employee
                    {
                        Id = Guid.Parse("ffffffff-ffff-ffff-ffff-ffffffffffff"),
                        Name = "Sara Black",
                        Age = 29,
                        Position = "Manager",
                        CompanyId = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                    },
                    // Employees of Company C
                    new Employee
                    {
                        Id = Guid.Parse("12345678-1234-1234-1234-123456789abc"),
                        Name = "Ken Tanaka",
                        Age = 40,
                        Position = "Developer",
                        CompanyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    },
                    new Employee
                    {
                        Id = Guid.Parse("87654321-4321-4321-4321-cba987654321"),
                        Name = "Yuki Saito",
                        Age = 27,
                        Position = "Designer",
                        CompanyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    },
                    new Employee
                    {
                        Id = Guid.Parse("11223344-5566-7788-99aa-bbccddeeff00"),
                        Name = "Hiroshi Yamamoto",
                        Age = 45,
                        Position = "Manager",
                        CompanyId = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                    }
                );
        }
    }
}
