using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class MilitaryDraftNotice
{
    public int MilitaryDraftNoticeId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Address { get; set; }

    public int? ConscriptId { get; set; }

    public int? ConscriptCommissionId { get; set; }

    public TimeOnly? Time { get; set; }

    public virtual Conscript? Conscript { get; set; }

    public virtual ConscriptionCommission? ConscriptCommission { get; set; }

    public virtual MedicalCommission? MedicalCommission { get; set; }
}
