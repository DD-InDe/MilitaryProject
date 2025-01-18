namespace MilitaryConscriptionSystem.Database;

public class EmployeeCheck(Employee employee)
{
    public Employee Employee { get; set; } = employee;
    public bool IsChecked { get; set; } = false;
}