public class PermanentEmployee : IEmployee, ICalculable
{
    private string name;
    private int income;

    public PermanentEmployee(string name, int income)
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

    public int calculateBonification()
    {
        // Lógica para calcular bonificación para empleados permanentes
        return income * 10 / 100;
    }
}
