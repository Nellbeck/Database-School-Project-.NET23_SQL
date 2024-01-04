using Database_School_Project_.NET23_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_School_Project_.NET23_SQL.Class
{
    internal class WorkerVS
    {
        // Adds a worker to the database.
        public static void AddWorker()
        {
            Console.WriteLine("First name: ");
            string userInputFirstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            string userInputLastName = Console.ReadLine();

            Console.WriteLine("Birth date (YYYYMMDDNNNN): ");
            string userInputBirthDate = Console.ReadLine();

            Console.WriteLine("Profession: ");
            string userInputProfesssion = Console.ReadLine();

            using (var db = new SchoolContext())
            {
                var worker = new Worker()
                {
                    WorkerFirstName = userInputFirstName,
                    WorkerLastName = userInputLastName,
                    WorkerBirthDate = userInputBirthDate,
                    WorkerProfession = userInputProfesssion,
                    WorkerStartDate = DateOnly.FromDateTime(DateTime.Now)
                };
                db.Workers.Add(worker);
                db.SaveChanges();
                Console.WriteLine("Task Succesful.");
            }
        }
    }
}
