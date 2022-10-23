using EMS.Domains;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;

namespace EMS.Repo
{
    public class EmployeeServices
    {
       
        public int AddEmployee(EmployeeDomain obj)
        {
            using (var context = new EMSEntities())
            {
                Employee emp = new Employee()
                {
                    Name = obj.Name,
                    Email = obj.Email,
                    Phone = obj.Phone,
                    Salary = obj.Salary,
                    DetID = obj.DetID
                };


                context.Employee.Add(emp);
                context.SaveChanges();
                return emp.EID;
            }

        }

        public List<EmployeeDomain> ShowAllEmp()
        {
            using (var context = new EMSEntities())
            {
                var result = context.Employee.Select(x => new EmployeeDomain()
                {
                    EID = x.EID,
                    Name = x.Name,
                    Email = x.Email,
                    Phone = x.Phone,
                    Salary = x.Salary,
                    DepartmentName = x.Department.Name
                }).ToList();

                return result;
            }

        }

        public EmployeeDomain GetEmpById(int id)
        {
            using (var context = new EMSEntities())
            {
                var result = context.Employee
                    .Where(x => x.EID == id)
                    .Select(x => new EmployeeDomain()
                    {
                        EID = x.EID,
                        Name = x.Name,
                        Email = x.Email,
                        Phone = x.Phone,
                        Salary = x.Salary,
                        DetID = x.DetID,
                        DepartmentName = x.Department.Name
                    }).FirstOrDefault();

                return result;
            }
        }

        public EmployeeDomain GetEmployeebyEmail(string email)
        {
            using (var context = new EMSEntities())
            {
                var result = context.Employee
                    .Where(x => x.Email == email)
                    .Select(x => new EmployeeDomain()
                    {
                        EID = x.EID,
                        Name = x.Name,
                        Email = x.Email,
                        Phone = x.Phone,
                        Salary = x.Salary,
                        DetID = x.DetID,
                        DepartmentName = x.Department.Name
                    }).FirstOrDefault();

                return result;
            }
        }

        public bool Edit(int id, EmployeeDomain obj)
        {
            using (var context = new EMSEntities())
            {
                var result = context.Employee.FirstOrDefault(x => x.EID == id);
                if (result != null)
                {
                    result.EID = obj.EID;
                    result.Name = obj.Name;
                    result.Email = obj.Email;
                    result.Phone = obj.Phone;
                    result.Salary = obj.Salary;
                    result.DetID = obj.DetID;

                }
                context.SaveChanges();
                return true;

            }
        }

        public bool DeleteEmployee(int id)
        {
            using (var context = new EMSEntities())
            {
                var result = context.Employee.FirstOrDefault(x => x.EID == id);
                if (result != null)
                {
                    context.Employee.Remove(result);
                    context.SaveChanges();
                    return true;
                }

                return false;
            }
        }
    }
}