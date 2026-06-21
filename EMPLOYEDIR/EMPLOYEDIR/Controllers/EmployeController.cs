using EMPLOYEDIR.Models;
using Microsoft.AspNetCore.Mvc;

namespace EMPLOYEDIR.Controllers
{
    public class EmployeController : Controller
    {
        public EmployeController()
        { }

        [HttpGet]
        public IActionResult Index()
        {
            //Employe employe = new Employe();

            //var emp = employe.GetEmploye(Convert.ToInt32(empId));

            return View();
        }

        [HttpPost]
        public IActionResult Index(Employe employe)
        {
            //Employe employe = new Employe();

            var emp = employe.GetEmploye(Convert.ToInt32(employe.EMPID));

            return View(emp);
        }
    }
}
