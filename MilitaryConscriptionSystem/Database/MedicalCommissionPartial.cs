namespace MilitaryConscriptionSystem.Database;

public partial class MedicalCommission
{
    public string DiagnosesApproved
    {
        get
        {
            if (Confirmed is true)
            {
                return "(подтверждено)";
            }

            if (Confirmed == null)
                return "(подтверждение не требуется)";

            return "(не подтверждено)";
        }
    }
}