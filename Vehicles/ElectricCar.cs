public class ElectricCar : Car
{

    public ElectricCar(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        
    }
    
    public void FillTank(float i_Amount)
    {
        base.FillTank(i_Amount, eEnergySource.Electric);
    }
}