using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class ConscriptionCommission
{
    public int ConscriptionCommissionId { get; set; }

    public DateOnly? CreateDate { get; set; }

    public DateOnly? WorksUntilDate { get; set; }

    public byte[]? Protocol { get; set; }

    public virtual ICollection<ConscriptionCommissionEmployee> ConscriptionCommissionEmployees { get; set; } = new List<ConscriptionCommissionEmployee>();

    public virtual ICollection<MilitaryDraftNotice> MilitaryDraftNotices { get; set; } = new List<MilitaryDraftNotice>();
}
