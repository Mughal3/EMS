using EMS.Domains;
using EMS.Models;
using EMS.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeServices emp = new EmployeeServices();
        DepartmentServices dpt = new DepartmentServices();
        // GET: Department
        public ActionResult Emp()
        {
            var result = emp.ShowAllEmp();
            return View(result);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var result = emp.GetEmpById(id);
            return View(result);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            var result = dpt.ShowAllDpt();
            ViewBag.Department = new SelectList(result, "DID", "Name");
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(EmployeeDomain obj)
        {
            try
            { 
                var result = emp.AddEmployee(obj);

                return RedirectToAction("Emp");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var result = emp.GetEmpById(id);
            return View(result);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(EmployeeDomain obj)
        {
            try
            {
                emp.Edit(obj.EID, obj);

                return RedirectToAction("Emp");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5

        public ActionResult Delete(int id)
        {
            var result = emp.DeleteEmployee(id);
            if (result)
            {
                ViewBag.Del = "Record Deleted Successful";
                return RedirectToAction("Emp");
            }
            return View("Emp");

        }



    }
}
