using MegaMindsTask.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MegaMindsTask.Repository;

namespace MegaMindsTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeService  _employee;

        public HomeController(ILogger<HomeController> logger,IEmployeeService employeeService)
        {
            _logger = logger;
            _employee=employeeService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAll()
        {
            var emp=_employee.GetAllEmployee();
            return PartialView(emp);
        }
        public IActionResult Edit(int Id)
        {
            var emplist=_employee.GetById(Id);
            return PartialView(emplist);
        }
        public IActionResult Delete(int Id)
        {
            int i = _employee.Delete(Id);
            return Json(i);
        }
        public IActionResult Save(Employee emp)
        {
            int i=_employee.Add(emp);
            return Json(i);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
