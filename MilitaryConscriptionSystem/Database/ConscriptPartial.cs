using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryConscriptionSystem.Database;

public partial class Conscript
{
    [NotMapped]
    public DateTime BirthDateTime
    {
        get { return Convert.ToDateTime(BirthDate.ToString()); }
        set { BirthDate = DateOnly.FromDateTime(value); }
    }

    [NotMapped]
    public DateTime RegistrationDateTime
    {
        get { return Convert.ToDateTime(RegistrationDate.ToString()); }
        set { RegistrationDate = DateOnly.FromDateTime(value); }
    }

    public string FullName => $"{LastName} {FirstName} {MiddleName}";
}