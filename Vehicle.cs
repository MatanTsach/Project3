public abstract class Vehicle
{
    protected readonly string r_ModelName;
    protected readonly string r_LicenseNumber;
    protected float m_EnergyPercentage;

    protected List<Wheel> r_Wheels = new List<Wheel>();
}