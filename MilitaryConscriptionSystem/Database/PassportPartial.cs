using System.ComponentModel.DataAnnotations.Schema;

namespace MilitaryConscriptionSystem.Database;

public partial class Passport
{
    [NotMapped]
    public DateTime IssuedDateTime
    {
        get => Convert.ToDateTime(IssuedDate.ToString());
        set => IssuedDate = DateOnly.FromDateTime(value);
    }
}