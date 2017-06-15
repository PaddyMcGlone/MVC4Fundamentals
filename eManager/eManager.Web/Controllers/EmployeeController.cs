using eManager.Domain;
using eManager.Web.Models;
using System.Linq;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public EmployeeController (IDepartmentDataSource db)
        {
            _db = db;
        }

        [HttpGet]
        public ActionResult Create(int departmentId)
        {
            var viewModel = new CreateEmployeeViewModel {DepartmentId = departmentId};
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(CreateEmployeeViewModel viewModel)
        {
            if (ModelState.IsValid) return View(viewModel);

            var department = _db.Departments.SingleOrDefault(d => d.Id == viewModel.DepartmentId);

            department?.Employees.Add(new Employee
            {
                Name = viewModel.Name,
                HireDate = viewModel.HireDate,
            });

            _db.Save();

            return RedirectToAction("details", "Department", new{ id = viewModel.DepartmentId});

        }
    }
}