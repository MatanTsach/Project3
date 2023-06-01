public abstract class Vehicle
{
    protected readonly string r_ModelName;
    protected readonly string r_LicenseNumber;
    protected readonly List<Wheel> r_Wheels = new List<Wheel>();
    protected float m_EnergyPercentage;

    public abstract List<string> AdditionalInfo();
}