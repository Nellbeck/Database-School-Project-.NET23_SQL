using Database_School_Project_.NET23_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_School_Project_.NET23_SQL.Class
{
    internal class DepartmentVS
    {
        //shows the name of every department with average salary and total salary cost.
        public static void GetDepartmentInfo() 
        {
            using (var db = new SchoolContext()) 
            {
                var dep = db.Departments.ToList();
                var groupDep = dep.GroupBy(n => new {Name = n.DeparmentName }).Select(s=> new { Average = s.Average(p=>p.DepartmentSalary), Total = s.Sum(t=>t.DepartmentSalary), Name = s.Key.Name});
                foreach (var i in groupDep) 
                {
                    Console.WriteLine($"Department Name: {i.Name} - Total Salary: {i.Total} - Average Salary: {i.Average}");
                }
            }
        }

        // shows how many workers there in each department.
        public static void GetWorkerCountInDepartment() 
        {
            using (var db = new SchoolContext())
            {
                var departments = db.Departments.ToList();
                var teachers = departments.GroupBy(n => new {Name = n.DeparmentName}).Select(s => new { Count = s.Count(), Name = s.Key.Name});
                foreach (var item in teachers)
                {
                    Console.WriteLine($"Department Name: {item.Name} - Total workers: {item.Count}");
                } 
            }
        }
    }
}
