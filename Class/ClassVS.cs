using Database_School_Project_.NET23_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Database_School_Project_.NET23_SQL.Class
{ 
    internal class ClassVS
    {
        //Shows all the classes so you can pick whatever class you want to see all the students in.
        public static void GetStudentsInClass()
        {
            using (var db = new SchoolContext())
            {
                var studentClassGroup = db.Classes.GroupBy(x => x.ClassName);
                var studentsInClass = db.Classes.ToList();
                var students = db.Students.ToList();
                foreach (var group in studentClassGroup)
                {
                    Console.WriteLine($"{group.Key}");
                }
                Console.WriteLine("\nChoose a class to see all students in that class.");
                string userInput = Console.ReadLine().ToUpper();

                foreach (var std in studentsInClass)
                {
                    foreach (var id in students)
                    {
                        if (std.ClassName == userInput)
                        {
                            if (std.FkStudenNumber == id.StudentNumber)
                            {
                                Console.WriteLine($"{id.StudentFirstName} {id.StudentLastName}");
                            }
                        }
                    }
                }
            }
        }
    }
}
