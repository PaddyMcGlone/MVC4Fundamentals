using System.Web.Security;
using eManager.Domain;

namespace eManager.Web.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<eManager.Web.Infrastructure.DepartmentDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(eManager.Web.Infrastructure.DepartmentDb context)
        {
            context.Departments.AddOrUpdate(d => d.Name,
                new Department{Name = "Sales"},
                new Department{Name = "Development"},
                new Department{Name = "HR"});

            if (!Roles.RoleExists("Admin"))
            {
                Roles.CreateRole("Admin");
            }

            if (Membership.GetUser("pmcglone") == null)
            {
                Membership.CreateUser("pmcglone", "password");
                Roles.AddUserToRole("pmcglone", "Admin");
            }
        }
    }
}
