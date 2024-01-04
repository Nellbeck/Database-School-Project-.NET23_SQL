using Database_School_Project_.NET23_SQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Database_School_Project_.NET23_SQL.Class
{
    internal class StudentVS
    {
        public static async void SPGetStudent() 
        {
            Console.WriteLine("Typ in the ID number of the student.");
            int.TryParse(Console.ReadLine(), out int userInput);

            using (var db = new SchoolContext()) 
            {
                var student = await db.Students.FromSqlInterpolated($"EXECUTE dbo.GetStudents {userInput}").ToArrayAsync();
                foreach (var s in student) 
                {
                    Console.WriteLine(s);
                }
            } 
        }
        // List of students orderd by first name with the option to have a descending order or not.
        public static void GetStudentsFirstName()
        {
            Console.WriteLine("Do you want descending list? yes or no");
            string userInput = Console.ReadLine().ToLower();
            if (userInput == "yes")
            {
                using (var db = new SchoolContext())
                {
                    var students = db.Students.OrderByDescending(x => x.StudentFirstName).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.StudentFirstName} {student.StudentLastName}");
                    }
                }
            }
            else
            {
                using (var db = new SchoolContext())
                {
                    var students = db.Students.OrderBy(x => x.StudentFirstName).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.StudentFirstName} {student.StudentLastName}");
                    }
                }
            }
        }
        // List of students orderd by last name with the option to have a descending order or not.

        public static void GetStudentsLastName()
        {
            Console.WriteLine("1. Descending list. \n2. Ascending list.");
            int.TryParse(Console.ReadLine(), out int userInput);
            if (userInput == 1)
            {
                using (var db = new SchoolContext())
                {
                    var students = db.Students.OrderByDescending(x => x.StudentLastName).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.StudentLastName} {student.StudentFirstName}");
                    }
                }
            }
            else if (userInput == 2)
            {
                using (var db = new SchoolContext())
                {
                    var students = db.Students.OrderBy(x => x.StudentLastName).ToList();
                    foreach (var student in students)
                    {
                        Console.WriteLine($"{student.StudentLastName} {student.StudentFirstName}");
                    }
                }
            }
        }
        //Adds a student to the database.
        public static void AddStudent()
        {
            Console.WriteLine("First name: ");
            string userInputFirstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            string userInputLastName = Console.ReadLine();

            Console.WriteLine("Birth date (YYYYMMDDNNNN): ");
            string userInputBirthDate = Console.ReadLine();

            using (var db = new SchoolContext())
            {
                var student = new Student()
                {
                    StudentFirstName = userInputFirstName,
                    StudentLastName = userInputLastName,
                    StudentBirthDate = userInputBirthDate

                };
                db.Students.Add(student);
                db.SaveChanges();
                Console.WriteLine("Task Succesful.");
            }
        }
        //Shows info about every student.
        public static void GetAllInfoStudents()
        {
            using (var db = new SchoolContext())
            {
                var allClasses = db.Classes.Join(db.Students, a => a.FkStudenNumber, s=>s.StudentNumber, (a,s) => new { StudentId = s.StudentNumber,StudentName = s.StudentFirstName, StudentLName = s.StudentLastName, CName = a.ClassName, StudentBirthD = s.StudentBirthDate});
                var allStudents = db.Students.Join(db.Classes, a => a.StudentNumber, c => c.FkStudenNumber, (a, c) => new { ClassName = c.ClassName });

                foreach (var s in allClasses)
                {
                    Console.WriteLine($"Student Id:{s.StudentId} - Name: {s.StudentLName} {s.StudentName} - Birthdate: {s.StudentBirthD} - Class: {s.CName}");
                }
            }
        }
    }
}
