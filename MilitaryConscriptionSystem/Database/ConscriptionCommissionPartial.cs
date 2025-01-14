namespace MilitaryConscriptionSystem.Database;

public partial class ConscriptionCommission
{
    public string Name => $"{CreateDate} - {WorksUntilDate}";
    public string ContainsProtocol => Protocol != null ? "Есть" : "Нет";
}