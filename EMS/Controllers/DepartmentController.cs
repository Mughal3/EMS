﻿using EMS.Domains;
using EMS.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentServices dpt = new DepartmentServices();
        // GET: Department
        public ActionResult Dpt()
        {
            var result = dpt.ShowAllDpt();
            return View(result);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var result = dpt.GetDptById(id);
            return View(result);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        public ActionResult Create(DepartmentDomain obj)
        {
            try
            {
                var result = dpt.AddDepartment(obj);

                return RedirectToAction("Dpt");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var result = dpt.GetDptById(id);
            return View(result);
        }

        // POST: Department/Edit/5
        [HttpPost]
        public ActionResult Edit(DepartmentDomain obj)
        {
            try
            {
                dpt.Edit(obj.DID, obj);

                return RedirectToAction("Dpt");
            }
            catch
            {
                return View();
            }
        }

        // GET: Department/Delete/5
  
        public ActionResult Delete(int id)
        {
            var result = dpt.DeleteDepartment(id);
            if (result)
            {
                ViewBag.Del = "Record Deleted Successful";
                return RedirectToAction("Dpt");
            }
            return View("Dpt");
            
        }

        
        
    }
}
