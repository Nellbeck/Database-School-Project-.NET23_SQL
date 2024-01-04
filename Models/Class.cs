using System;
using System.Collections.Generic;

namespace Database_School_Project_.NET23_SQL.Models;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassName { get; set; }

    public int? FkStudenNumber { get; set; }

    public int? FkWorkerNumber { get; set; }

    public virtual Student? FkStudenNumberNavigation { get; set; }

    public virtual Worker? FkWorkerNumberNavigation { get; set; }
}
