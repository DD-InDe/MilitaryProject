using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class Passport
{
    public int PassportId { get; set; }

    public int? Serial { get; set; }

    public int? Number { get; set; }

    public string? IssuedBy { get; set; }

    public DateOnly? IssuedDate { get; set; }

    public virtual Conscript? Conscript { get; set; }

    public virtual Employee? Employee { get; set; }
}
