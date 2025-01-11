using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class Conscript
{
    public int PassportId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? MiddleName { get; set; }

    public DateOnly? BirthDate { get; set; }

    public DateOnly? RegistrationDate { get; set; }

    public virtual ICollection<ConscriptDocument> ConscriptDocuments { get; set; } = new List<ConscriptDocument>();

    public virtual ICollection<MilitaryDraftNotice> MilitaryDraftNotices { get; set; } = new List<MilitaryDraftNotice>();

    public virtual Passport Passport { get; set; } = null!;
}
