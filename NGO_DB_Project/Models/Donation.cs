using System;
using System.Collections.Generic;

namespace NGO_DB_Project.Models;

public partial class Donation
{
    public int Id { get; set; }

    public string? Description { get; set; }

    public DateOnly? DonationDate { get; set; }

    public decimal? Amount { get; set; }

    public int? MemberId { get; set; }

    public int? ProjectId { get; set; }

    public virtual Member? Member { get; set; }

    public virtual Project? Project { get; set; }
}
