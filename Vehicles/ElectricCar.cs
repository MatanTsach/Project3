public class ElectricCar : Car
{
    public ElectricCar(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        r_Tank = new ElectricTank(5.2f);
    }
}