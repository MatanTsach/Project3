public class Vehicle
{
    protected string r_ModelName = "";
    protected string r_LicenseNumber = "";
    protected float m_EnergyPercentage;
    protected eEnergySource m_FuelType;
    protected List<Wheel> r_Wheels;
    protected readonly Tank r_Tank;
    protected List<string> m_VehicleProperties;

    public Vehicle()
    {
        r_Wheels = new List<Wheel>();
        m_VehicleProperties = new List<string>();
        m_VehicleProperties.Add("Model Name");
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

    public List<string> VehicleProperties
    {
        get { return m_VehicleProperties; }
    }

    public void UpdateAllWheels(string i_ManufacturerName, float i_AirPressure)
    {
        for (int i = 0; i < r_Wheels.Count; i++)
        {
            UpdateWheel(i, i_ManufacturerName, i_AirPressure);
        }
    }

    public void UpdateWheel(int i_WheelIndex, string i_ManufacturerName, float i_AirPressure)
    {
        r_Wheels.ElementAt(i_WheelIndex).ManufacturerName = i_ManufacturerName;
        r_Wheels.ElementAt(i_WheelIndex).Inflate(i_AirPressure);
    }
}