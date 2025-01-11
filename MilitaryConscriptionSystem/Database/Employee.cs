using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class Employee
{
    public int PassportId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public int? PositionId { get; set; }

    public string? Login { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ConscriptionCommissionEmployee> ConscriptionCommissionEmployees { get; set; } = new List<ConscriptionCommissionEmployee>();

    public virtual Passport Passport { get; set; } = null!;

    public virtual Position? Position { get; set; }
}
