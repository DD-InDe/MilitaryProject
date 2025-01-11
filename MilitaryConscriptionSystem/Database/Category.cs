using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class Category
{
    public string CategoryKey { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<MedicalCommission> MedicalCommissions { get; set; } = new List<MedicalCommission>();
}
