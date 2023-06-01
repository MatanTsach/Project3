public class Vehicle
{
    protected string r_ModelName = "";
    protected string r_LicenseNumber = "";
    protected float m_EnergyPercentage;
    protected eFuelType m_FuelType;
    protected List<Wheel> r_Wheels = new List<Wheel>();

    protected List<string> m_VehicleFields;

    public Vehicle()
    {
        m_VehicleFields = new List<string>();
        m_VehicleFields.Add("Model Name");
        m_VehicleFields.Add("License Number");
    }

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

    public List<string> Fields
    {
        get { return m_VehicleFields; }
    }
}