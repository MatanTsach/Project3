public class Vehicle
{
    protected string r_ModelName = "";
    protected string r_LicenseNumber = "";
    protected float m_EnergyPercentage;
    protected eEnergySource m_FuelType;
    protected List<Wheel> r_Wheels;
    protected VehicleFactory.eVehicleType vehicleType;
    protected List<string> m_VehicleFields;

    public Vehicle()
    {
        r_Wheels = new List<Wheel>();
        m_VehicleFields = new List<string>();
        m_VehicleFields.Add("Model Name");
    }

    public string ModelName
    {
        get { return r_ModelName; }
        set { r_ModelName = value; }
    }

    public string LicenseNumber
    {
        get { return r_LicenseNumber; }
        set { r_LicenseNumber = value; }
    }

    public float EnergyPercentage
    {
        get { return m_EnergyPercentage; }
        set { m_EnergyPercentage = value; }
    }

    public eEnergySource FuelType
    {
        get { return m_FuelType; }
        set { m_FuelType = value; }
    }

    public List<Wheel> Wheels
    {
        get { return r_Wheels; }
        set { r_Wheels = value; }
    }

    public List<string> Fields
    {
        get { return m_VehicleFields; }
    }

    public 
}