using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class Result
{
    public int ResultId { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<MilitaryDraftNotice> MilitaryDraftNotices { get; set; } = new List<MilitaryDraftNotice>();
}
