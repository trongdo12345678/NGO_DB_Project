using System;
using System.Collections.Generic;

namespace NGO_DB_Project.Models;

public partial class Role
{
    public int Id { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();
}
