using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crud_Using_Ajax.Models;

namespace Crud_Using_Ajax.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpRepo _empRepo;

        public HomeController(EmpRepo empRepo)
        {
            _empRepo = empRepo;
        }
        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
         var allemp =   _empRepo.GetAllEmployee();
            return Json(allemp);
        }
        public IActionResult Add(EmployeeModel emp)
        {
            var addEmp = _empRepo.AddEmployee(emp);
            return Json(addEmp);
        }
        public JsonResult GetbyID(int ID)
        {
            var Employee = _empRepo.GetEmployee(ID);
            return Json(Employee);
        }
        public JsonResult Update(EmployeeModel emp)
        {
            var UpdateEmp = _empRepo.UpdateEmployee(emp);
            return Json(UpdateEmp);
        }
        public JsonResult Delete(int ID)
        {
            var deleteEmp = _empRepo.DeleteEmployee(ID);
            return Json(deleteEmp);
        }
    }
}
