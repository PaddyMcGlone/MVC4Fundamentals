using eManager.Domain;
using System.Data.Entity;
using System.Linq;

namespace eManager.Web.Infrastructure
{
    public class DepartmentDB : DbContext, IDepartmentDataSource
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        IQueryable<Employee> IDepartmentDataSource.Employees => Employees;
        IQueryable<Department> IDepartmentDataSource.Departments => Departments;
    }
}