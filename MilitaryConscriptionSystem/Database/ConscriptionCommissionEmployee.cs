using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class ConscriptionCommissionEmployee
{
    public int ConscriptionCommissionEmployeeId { get; set; }

    public int? ConscriptionCommission { get; set; }

    public int? EmployeeId { get; set; }

    public virtual ConscriptionCommission? ConscriptionCommissionNavigation { get; set; }

    public virtual Employee? Employee { get; set; }
}
