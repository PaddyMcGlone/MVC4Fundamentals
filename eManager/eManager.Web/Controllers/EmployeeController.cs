using eManager.Web.Models;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult Create(int departmentId)
        {
            var viewModel = new CreateEmployeeViewModel {DepartmentId = departmentId};
            return View(viewModel);
        }
    }
}