public class ElectricMotorcylce : Car
{

    public ElectricMotorcylce(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        r_Tank = new Tank(2.6f, eEnergySource.Electric); 
    }
    
    public void FillTank(float i_Amount)
    {
        base.FillTank(i_Amount, eEnergySource.Electric);
    }
}