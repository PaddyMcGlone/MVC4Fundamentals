using eManager.Domain;
using System.Linq;
using System.Web.Mvc;

namespace eManager.Web.Controllers
{
    public class departmentController : Controller
    {
        private readonly IDepartmentDataSource _db;

        public departmentController(IDepartmentDataSource db)
        {
            _db = db;
        }

        public ActionResult Details(int id)
        {
            var model = _db.Departments.SingleOrDefault(d => d.Id == id);
            return View(model);
        }
    }
}