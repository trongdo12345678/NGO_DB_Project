using System;
using System.Collections.Generic;

namespace NGO_DB_Project.Models;

public partial class ProjectType
{
    public int Id { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
