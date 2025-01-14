using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class MedicalCommission
{
    public int MilitaryDraftNoticeId { get; set; }

    public string? HealthComplaints { get; set; }

    public string? Diagnoses { get; set; }

    public string? Note { get; set; }

    public bool? Confirmed { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual MilitaryDraftNotice MilitaryDraftNotice { get; set; } = null!;
}
