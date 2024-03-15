﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NGO_DB_Project.Models;

public partial class ProjectType
{
    public int Id { get; set; }
	[MaxLength(100)]
	[Required]
	public string? TypeName { get; set; }

    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
