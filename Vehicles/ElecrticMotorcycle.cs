public class ElectricMotorcylce : Motorcycle
{

    public ElectricMotorcylce(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        r_Tank = new ElectricTank(2.6f);
    }
}