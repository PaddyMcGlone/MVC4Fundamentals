using eManager.Domain;
using System.Data.Entity;
using System.Linq;

namespace eManager.Web.Infrastructure
{
    public class DepartmentDb : DbContext, IDepartmentDataSource
    {
        #region Constructor


        // Cant figure out how to properly load the connection string added to web.config
        //public DepartmentDb() : base("DefaultConnection")
        //{

        //}

        #endregion

        #region Properties

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        
        IQueryable<Employee> IDepartmentDataSource.Employees => Employees;
        IQueryable<Department> IDepartmentDataSource.Departments => Departments;
        void IDepartmentDataSource.Save() => SaveChanges();

        #endregion
    }
}