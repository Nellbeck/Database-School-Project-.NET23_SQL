using Database_School_Project_.NET23_SQL.Class;
using Database_School_Project_.NET23_SQL.Models;
using Microsoft.Data.SqlClient;

namespace Database_School_Project_.NET23_SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Connection string.
            string connectionString = "Data Source=DESKTOP-FPHO4OK;Initial Catalog=School;Integrated Security=True;TrustServerCertificate=true";
            SqlConnection connection = null;
            SqlCommand command = null;

            // Do-while loop with a switch case in it.
            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to school 'Trolla med Troll' " +
                    "\n\nMake a choice. " +
                    "\n1. List of Workers. " +
                    "\n2. List of Students. " +
                    "\n3. List of Classes." +
                    " \n4. Get last months grades " +
                    "\n5. Get grades from courses. " +
                    "\n6. Add student. " +
                    "\n7. Add worker. " +
                    "\n8. Get all courses. " +
                    "\n9. Department info. " +
                    "\n10. Set Grade. (transaction) " +
                    "\n11. Show how many workers in department." +
                    "\n12. Use Stored Procedure 'GetStudent'" + 
                    "\n0. Exit program.");

                int.TryParse(Console.ReadLine(), out int userInput);

                //If the user puts in '(null)' or '0' the program will stop.
                if (userInput == 0)
                {
                    Environment.Exit(0);
                }
                switch (userInput)
                {
                    
                    case 1:
                        {
                            do
                            {
                                Console.Clear();
                                try
                                    //Lets the user to see all the workers or just only teachers.
                                {
                                    Console.WriteLine("1. Show only Teachers. \n2. Show all Workers.");

                                    string input = "";

                                    int.TryParse(Console.ReadLine(), out int userChoice);

                                    if (userChoice == 1)
                                    {
                                        input = "WHERE WorkerProfession = 'Teacher'";
                                    }

                                    connection = new SqlConnection(connectionString);
                                    connection.Open();

                                    SqlDataReader reader = null;
                                    command = new SqlCommand($"SELECT WorkerProfession, WorkerFirstName, WorkerLastName FROM Workers {input} ORDER BY WorkerLastName", connection);
                                    reader = command.ExecuteReader();

                                    while (reader.Read())
                                    {
                                        Console.WriteLine($"Name: {reader["WorkerLastName"]} {reader["WorkerFirstName"]} - {reader["WorkerProfession"]}\n");
                                    }

                                    connection.Close();
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                finally
                                {
                                    if (connection != null)
                                        connection.Dispose();
                                    if (command != null)
                                        command.Dispose();
                                }
                                break;
                            } while (true);
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            StudentVS.GetAllInfoStudents();
                        }
                        break;
                    case 3:
                        {
                            Console.Clear();
                            ClassVS.GetStudentsInClass();
                        }
                        break;
                    case 4:
                        {
                            Console.Clear();
                            CourseVS.GetAllGradesLastMonth();
                        }
                        break;
                    case 5:
                        {
                            Console.Clear();
                            CourseVS.GetAllGrades();
                        }
                        break;
                    case 6:
                        {
                            Console.Clear();
                            StudentVS.AddStudent();
                        }
                        break;
                    case 7:
                        {
                            Console.Clear();
                            WorkerVS.AddWorker();
                        }
                        break;
                    case 8: 
                        {
                            Console.Clear();
                            CourseVS.GetActiveCourses();
                        }
                        break;
                    case 9: 
                        {
                            Console.Clear();
                            DepartmentVS.GetDepartmentInfo();
                        }
                        break;
                    case 10:
                        {
                            Console.Clear();
                            CourseVS.SetGradeTransaction();
                        }
                        break;
                    case 11:
                        {
                            Console.Clear();
                            DepartmentVS.GetWorkerCountInDepartment();
                        }
                        break;
                    case 12: 
                        {
                            StudentVS.SPGetStudent();
                        }
                        break;
                }
                Console.ReadLine();
            } while (true);
        }
    }

}
