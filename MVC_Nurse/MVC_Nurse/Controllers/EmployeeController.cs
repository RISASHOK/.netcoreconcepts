using Microsoft.AspNetCore.Mvc;
using MVC_Nurse.Models;

namespace MVC_Nurse.Controllers
{
    public class EmployeeController : Controller
    {
        private Employee _employee = new Employee();
        [HttpGet]
        public IActionResult Index()
        {
            Employee employee = _employee.GetEmp();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Index(Employee employee)
        {
            //Employee employee = _employee.GetEmp();
            return View();
        }
    }
}
