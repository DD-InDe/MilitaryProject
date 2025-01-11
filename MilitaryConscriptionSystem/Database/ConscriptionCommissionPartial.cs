namespace MilitaryConscriptionSystem.Database;

public partial class ConscriptionCommission
{
    public string Name => $"{CreateDate} - {WorksUntilDate}";
}