using EMS.Domains;
using EMS.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace EMS.Repo
{
    public class DepartmentServices
    {
        public int AddDepartment(DepartmentDomain obj)
        {
            using (var context = new EMSEntities())
            {
                Department dpt = new Department()
                {
                    DID = obj.DID,
                    Name = obj.Name
                };
                context.Department.Add(dpt);
                context.SaveChanges();

                return dpt.DID;

            }

        }

        public List<DepartmentDomain> ShowAllDpt()
        {
            using ( var context = new EMSEntities())
            {
                var result = context.Department.Select(x=> new DepartmentDomain()
                {
                    DID = x.DID,
                    Name = x.Name
                }).ToList();

                return result;
            }
            
        }

        public DepartmentDomain GetDptById(int id)
        {
            using (var context = new EMSEntities())
            {
                var result = context.Department
                    .Where(x => x.DID == id)
                    .Select(x => new DepartmentDomain()
                    {
                        DID = x.DID,
                        Name = x.Name
                    }).FirstOrDefault();

                return result;
            }
        }

        public bool Edit (int id , DepartmentDomain obj)
        {
            using ( var context = new EMSEntities())
            {
                var result = context.Department.FirstOrDefault(x => x.DID == id);
                if (result != null)
                {
                    result.DID = obj.DID;
                    result.Name = obj.Name;

                }
                context.SaveChanges();
                return true;
                    
            }
        }

        public bool DeleteDepartment(int id)
        {
            using ( var context = new EMSEntities())
            {
                var result = context.Department.FirstOrDefault(x=>x.DID == id);
                if (result != null)
                {
                    context.Department.Remove(result);
                    context.SaveChanges();
                    return true;
                }
                
                return false;
            }
        }


    }
}