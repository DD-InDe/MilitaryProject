namespace MilitaryConscriptionSystem.Database;

public class ConscriptCheck(Conscript conscript)
{
    public Conscript Conscript { get; set; } = conscript;
    public bool IsChecked { get; set; } = false;
}