using System;
using System.Collections.Generic;

namespace NGO_DB_Project.Models;

public partial class Expense
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public decimal? Amount { get; set; }

    public DateOnly? Date { get; set; }

    public int? ProjectId { get; set; }

    public virtual Project? Project { get; set; }
}
