using System;
using System.Collections.Generic;

namespace Database_School_Project_.NET23_SQL.Models;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseName { get; set; }

    public string? CourseGradeSet { get; set; }

    public string? CourseGradeSetDate { get; set; }

    public int? FkWorkerNumber { get; set; }

    public int? FkStudenNumber { get; set; }

    public virtual Student? FkStudenNumberNavigation { get; set; }

    public virtual Worker? FkWorkerNumberNavigation { get; set; }
}
