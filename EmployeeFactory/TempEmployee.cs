public class TempEmployee : IEmployee
{
    private string name;
    private int income;

    public TempEmployee(string name, int income)
    {
        this.name = name;
        this.income = income;
    }

    public string GetName()
    {
        return name;
    }

    public int GetIncome()
    {
        return income;
    }


}
