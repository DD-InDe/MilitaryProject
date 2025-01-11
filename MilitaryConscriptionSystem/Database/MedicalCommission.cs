using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class MedicalCommission
{
    public int MilitaryDraftNoticeId { get; set; }

    public string? HealthComplaints { get; set; }

    public string? Diagnoses { get; set; }

    public string? Note { get; set; }

    public string? CategoryKey { get; set; }

    public bool? Confirmed { get; set; }

    public virtual Category? CategoryKeyNavigation { get; set; }

    public virtual MilitaryDraftNotice MilitaryDraftNotice { get; set; } = null!;
}
