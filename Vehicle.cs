public abstract class Vehicle
{
    protected string r_ModelName;
    protected string r_LicenseNumber;
    protected List<Wheel> r_Wheels = new List<Wheel>();
    protected float m_EnergyPercentage;
    protected eFuelType m_FuelType;

    public abstract List<string> AdditionalFields();

    public string ModelName
    {
        get { return r_ModelName; }
        set { r_ModelName = value; }
    }

    public string Licensenumber
    {
        get { return r_LicenseNumber; }
        set { r_LicenseNumber = value; }
    }

    public float EnergyPercentage
    {
        get { return m_EnergyPercentage; }
        set { m_EnergyPercentage = value; }
    }

    public eFuelType FuelType
    {
        get { return m_FuelType; }
        set { m_FuelType = value; }
    }
}