using EmployeeCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace EmployeeCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult AddEmployee()
        {
            return View();
        }



        // POST: Employee
        [HttpPost]
        public ActionResult AddEmployee(EmpModel emp)
        {
           
                EmpDb Emp = new EmpDb();
                Emp.AddEmp(emp);




            return View();
        }


        //showdata
        public ActionResult Show()
        {

            EmpDb Emp = new EmpDb();
            return View(Emp.GetAllEmployees());
        }

          
        public ActionResult EditEmpDetails(int id)
        {
            EmpDb Emp1 = new EmpDb();
            var row=Emp1.GetAllEmployees().Find(Emp => Emp.id == id);
            return View(row);

        }

        // POST:Update the details into database      
        [HttpPost]
        public ActionResult EditEmpDetails(int id, EmpModel obj)
        {
            EmpDb Emp = new EmpDb();

            Emp.UpdateEmployee(obj);
            return RedirectToAction("Show");

        }

        //delete data
        public ActionResult DeleteEmpDetails(int id)
        {
            EmpDb emp= new EmpDb();
            if (emp.DeleteEmployee(id))
            {
                ViewBag.AlertMsg = "Employee details deleted successfully";
            }
            return RedirectToAction("show");
        }


    }
    }
