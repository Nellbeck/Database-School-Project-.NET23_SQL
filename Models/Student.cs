using System;
using System.Collections.Generic;

namespace Database_School_Project_.NET23_SQL.Models;

public partial class Student
{
    public int StudentNumber { get; set; }

    public string StudentBirthDate { get; set; } = null!;

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;

    public int? StudentAge { get; set; }

    public string? StudentGender { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
