﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NGO_DB_Project.Models;

public partial class Project
{
    public int Id { get; set; }
	[MaxLength(250)]
	[Required]
	public string? Name { get; set; }
	[Required]
	public string? Description { get; set; }

    public string? Img { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }
	[Required]
	public decimal? TargetAmount { get; set; }

    public int? ProjectTypeId { get; set; }

    public virtual ICollection<Donation> Donations { get; set; } = new List<Donation>();

    public virtual ICollection<Expense> Expenses { get; set; } = new List<Expense>();

    public virtual ProjectType? ProjectType { get; set; }
}
