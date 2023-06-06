public class ElectricTank : Tank
{
    public ElectricTank(float i_MaxCapacity) : base(i_MaxCapacity, eEnergySource.Electric)
    {}

    public void Fill(float i_Amount)
    {
        base.Fill(i_Amount, eEnergySource.Electric);
    }
}