using System;
using System.Collections.Generic;

namespace Database_School_Project_.NET23_SQL.Models;

public partial class Worker
{
    public int WorkerNumber { get; set; }

    public string WorkerBirthDate { get; set; } = null!;

    public string WorkerFirstName { get; set; } = null!;

    public string WorkerLastName { get; set; } = null!;

    public string WorkerProfession { get; set; } = null!;

    public DateOnly? WorkerStartDate { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Department> Departments { get; set; } = new List<Department>();
}
