using EMS.Domains;
using EMS.Models;
using EMS.Repo;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNetCore.Identity;

namespace EMS.Controllers
{
    
    public class EmployeeController : Controller
    {
        EmployeeServices emp = new EmployeeServices();
        DepartmentServices dpt = new DepartmentServices();
        // GET: Department

        [Authorize(Roles = "Admin")]
        public ActionResult Emp()
        {
            var result = emp.ShowAllEmp();
            return View(result);
        }

        // GET: Department/Details/5
        [Authorize(Roles = "Admin")]

        public ActionResult Details(int id)
        {
            var result = emp.GetEmpById(id);
            return View(result);
        }

        // GET: Department/Create
        [Authorize(Roles = "Admin")]

        public ActionResult Create()
        {
            var result = dpt.ShowAllDpt();
            ViewBag.Department = new SelectList(result, "DID", "Name");
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]

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
        [Authorize(Roles = "Admin")]

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
        [Authorize]
        public ActionResult EmployeOnly()
        {
            var id = User.Identity.GetUserId();
            var context = new EMSEntities();
            var mail = context.AspNetUsers.FirstOrDefault(x => x.Id == id);
            var email = mail.Email;
            var result = context.Employee.Select( x => new EmployeeDomain 
            {
                EID = x.EID,
                Name = x.Name,
                Email = x.Email,
                Phone = x.Phone,
                Salary = x.Salary,
                DetID = x.DetID,
                DepartmentName = x.Department.Name
            }).FirstOrDefault(x => x.Email == email);
            return View(result);
        }


    }
}
