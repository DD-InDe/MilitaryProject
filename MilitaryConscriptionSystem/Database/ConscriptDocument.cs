using System;
using System.Collections.Generic;

namespace MilitaryConscriptionSystem.Database;

public partial class ConscriptDocument
{
    public int ConscriptDocumentId { get; set; }

    public int? ConscriptId { get; set; }

    public byte[]? DocumentFile { get; set; }

    public string? DocumentName { get; set; }

    public string? Description { get; set; }

    public virtual Conscript? Conscript { get; set; }
}
