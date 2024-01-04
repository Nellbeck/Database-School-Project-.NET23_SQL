using Database_School_Project_.NET23_SQL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_School_Project_.NET23_SQL.Class
{
    internal class CourseVS
    {
        //Sets a grade on a student with transaction. If something unexpected happends it won't execute.
        public static void SetGradeTransaction() 
        {
            Console.Clear();
            StudentVS.GetAllInfoStudents();

            using var db = new SchoolContext();

            using var transaction = db.Database.BeginTransaction();

            Console.WriteLine("Which student would you want to grade? Write the ID number of the student.");
            int.TryParse(Console.ReadLine(), out int userInputStudentId);

            Console.WriteLine("Which teacher set the grade? Write the ID number of the teacher.");
            int.TryParse(Console.ReadLine(), out int userInputTeacherId);

            Console.WriteLine("Name of the course?");
            string userInputName = Console.ReadLine();

            Console.WriteLine("Set grade.");
            string userInputGrade = Console.ReadLine();
            try
            {
                db.Courses.Add(new Course()
                {
                    FkWorkerNumber = userInputTeacherId,
                    FkStudenNumber = userInputStudentId,
                    CourseName = userInputName,
                    CourseGradeSet = userInputGrade,
                    CourseGradeSetDate = DateTime.Today.ToString("yyyy-mm-dd")
                }) ;
                db.SaveChanges();

                transaction.Commit();

                Console.WriteLine("Task succesful.");
            }
            catch (Exception) 
            {
                transaction.Rollback();
                Console.WriteLine("Task unsuccesful.");
            }
        }
        //See all active courses.
        public static void GetActiveCourses() 
        {
            using (var db = new SchoolContext()) 
            {
                var courses = db.Courses.GroupBy(x => x.CourseName).ToList();
                foreach (var i in courses)
                {
                    Console.WriteLine(i.Key);
                }
            }
        }
        // See all grades set the past month.
        public static void GetAllGradesLastMonth()
        {

            var date = DateTime.Today.AddMonths(-1);

            using (var db = new SchoolContext())
            {
                var student = db.Students.ToList();
                var gradeName = db.Courses.OrderBy(x => x.CourseName).ToList();
                foreach (var grade in gradeName)
                {
                    var gradeDate = DateTime.Parse(grade.CourseGradeSetDate);
                    foreach (var students in student)
                    {
                        if (date <= gradeDate)
                        {
                            if (grade.FkStudenNumber == students.StudentNumber)
                            {
                                Console.WriteLine($"Name: {students.StudentFirstName} {students.StudentLastName} - Course Name: {grade.CourseName} - Grade: {grade.CourseGradeSet}");
                            }
                        }
                    }
                }
            }
        }
        // Shows average grade for every course and both highest/lowest grade set in that course.
        // Not exactly the best way to write the code but I did this before I got comfy with lambda expresions.
        public static void GetAllGrades()
        {
            using (var db = new SchoolContext())
            {
                var course = db.Courses.GroupBy(x => x.CourseName);
                var courseGradeSorted = db.Courses.GroupBy(x => x.CourseGradeSet);
                var courseGrade = db.Courses.ToList();
                int sumGradeMath = 0;
                int sumGradeEnglish = 0;
                int subMath = 0;
                int subEnglish = 0;
                string highestMathGrade = "G";
                string lowestMathGrade = "G";
                string highestEnglishGrade = "G";
                string lowestEnglishGrade = "G";
                foreach (var coursesGrade in courseGrade)
                {

                    if (coursesGrade.CourseName == "Math")
                    {
                        subMath = subMath + 1;
                        if (coursesGrade.CourseGradeSet.Contains("MVG"))
                        {
                            sumGradeMath = sumGradeMath + 4;

                            if (highestMathGrade == "G" || highestMathGrade == "VG" || highestMathGrade == "IG")
                            {
                                highestMathGrade = coursesGrade.CourseGradeSet;
                            }
                            if (lowestMathGrade == "MVG")
                            {
                                lowestMathGrade = coursesGrade.CourseGradeSet;
                            }

                        }
                        else if (coursesGrade.CourseGradeSet.Contains("VG"))
                        {
                            sumGradeMath = sumGradeMath + 3;

                            if (highestMathGrade == "G" || highestMathGrade == "IG")
                            {
                                highestMathGrade = coursesGrade.CourseGradeSet;
                            }

                            if (lowestMathGrade == "MVG")
                            {
                                lowestMathGrade = coursesGrade.CourseGradeSet;
                            }
                        }

                        else if (coursesGrade.CourseGradeSet.Contains("IG"))
                        {
                            sumGradeMath = sumGradeMath + 1;

                            if (highestMathGrade == "IG")
                            {
                                highestMathGrade = coursesGrade.CourseGradeSet;
                            }

                            if (lowestMathGrade == "G" || lowestMathGrade == "VG" || lowestMathGrade == "MVG")
                            {
                                lowestMathGrade = coursesGrade.CourseGradeSet;
                            }
                        }

                        else if (coursesGrade.CourseGradeSet.Contains("G"))
                        {
                            sumGradeMath = sumGradeMath + 2;

                            if (highestMathGrade == "IG")
                            {
                                highestMathGrade = coursesGrade.CourseGradeSet;
                            }

                            if (lowestMathGrade == "VG" || lowestMathGrade == "MVG")
                            {
                                lowestMathGrade = coursesGrade.CourseGradeSet;
                            }
                        }

                    }
                    else if (coursesGrade.CourseName == "English")
                    {
                        subEnglish = subEnglish + 1;
                        if (coursesGrade.CourseGradeSet.Contains("MVG"))
                        {
                            sumGradeEnglish = sumGradeEnglish + 4;
                            if (highestEnglishGrade == "G" || highestEnglishGrade == "VG" || highestEnglishGrade == "IG")
                            {
                                highestEnglishGrade = coursesGrade.CourseGradeSet;
                            }
                            if (lowestEnglishGrade == "MVG")
                            {
                                lowestEnglishGrade = coursesGrade.CourseGradeSet;
                            }
                        }

                        else if (coursesGrade.CourseGradeSet.Contains("VG"))
                        {
                            sumGradeEnglish = sumGradeEnglish + 3;

                            if (highestEnglishGrade == "G" || highestEnglishGrade == "IG")
                            {
                                highestEnglishGrade = coursesGrade.CourseGradeSet;
                            }

                            if (lowestEnglishGrade == "MVG")
                            {
                                lowestEnglishGrade = coursesGrade.CourseGradeSet;
                            }

                        }

                        else if (coursesGrade.CourseGradeSet.Contains("IG"))
                        {
                            sumGradeEnglish = sumGradeEnglish + 1;

                            if (highestEnglishGrade == "IG")
                            {
                                highestEnglishGrade = coursesGrade.CourseGradeSet;
                            }

                            if (lowestEnglishGrade == "G" || lowestEnglishGrade == "VG" || lowestEnglishGrade == "MVG")
                            {
                                lowestEnglishGrade = coursesGrade.CourseGradeSet;
                            }
                        }

                        else if (coursesGrade.CourseGradeSet.Contains("G"))
                        {
                            sumGradeEnglish = sumGradeEnglish + 2;

                            if (highestEnglishGrade == "IG")
                            {
                                highestEnglishGrade = coursesGrade.CourseGradeSet;

                                if (lowestEnglishGrade == "VG" || lowestEnglishGrade == "MVG")
                                {
                                    lowestEnglishGrade = coursesGrade.CourseGradeSet;
                                }

                            }
                        }
                    }
                }
                sumGradeEnglish = sumGradeEnglish / subEnglish;
                sumGradeMath = sumGradeMath / subMath;
                string gradeMath;
                string gradeEnglish;
                if (sumGradeMath == 2)
                {
                    gradeMath = "G";
                }
                else if (sumGradeMath == 3)
                {
                    gradeMath = "VG";
                }
                else if (sumGradeMath == 4)
                {
                    gradeMath = "MVG";
                }
                else
                {
                    gradeMath = "IG";
                }

                if (sumGradeEnglish == 2)
                {
                    gradeEnglish = "G";
                }
                else if (sumGradeEnglish == 3)
                {
                    gradeEnglish = "VG";
                }
                else if (sumGradeEnglish == 4)
                {
                    gradeEnglish = "MVG";
                }
                else
                {
                    gradeEnglish = "IG";
                }

                Console.Clear();
                foreach (var courses in course)
                {
                    if (courses.Key == "Math")
                        Console.WriteLine($"Course Name: {courses.Key} - Avg Grade: {gradeMath} - Highest grade: {highestMathGrade} - Lowest grade: {lowestMathGrade}");

                    else if (courses.Key == "English")
                    {
                        Console.WriteLine($"Course Name: {courses.Key} - Avg Grade: {gradeEnglish} - Highest grade: {highestEnglishGrade} - Lowest grade: {lowestEnglishGrade}");
                    }
                }

            }
        }
    }
}
