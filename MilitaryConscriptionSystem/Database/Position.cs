using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class Position
{
    public int PositionId { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
