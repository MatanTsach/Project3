public class ElectricCar : Car
{

    public ElectricCar(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        r_Tank = new Tank(312, eEnergySource.Electric); //5.2 hours = 312 min
    }
    
    public void FillTank(float i_Amount)
    {
        base.FillTank(i_Amount, eEnergySource.Electric);
    }
}