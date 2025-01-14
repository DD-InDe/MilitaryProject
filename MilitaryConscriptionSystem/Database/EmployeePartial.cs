using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryConscriptionSystem.Database;

public partial class Employee
{
    [NotMapped]
    public DateTime BirthDateTime
    {
        get => Convert.ToDateTime(BirthDate.ToString());
        set => BirthDate = DateOnly.FromDateTime(value);
    }

    public string ComboBoxField => $"{LastName} {FirstName} ({Position?.Name ?? String.Empty})";
}