using System;
using System.Collections.Generic;

namespace Database_School_Project_.NET23_SQL.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? DeparmentName { get; set; }

    public int? DepartmentSalary { get; set; }

    public int? FkWorkerNumber { get; set; }

    public virtual Worker? FkWorkerNumberNavigation { get; set; }
}
