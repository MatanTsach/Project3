public class Vehicle
{
    protected string r_ModelName = "";
    protected string r_LicenseNumber = "";
    protected float m_EnergyPercentage;
    protected List<Wheel> r_Wheels; 
    protected int m_AmountOfWheels;
    protected Tank r_Tank;
    protected Dictionary<string, string> m_VehicleProperties;

    public Vehicle(string i_LicenseNumber)
    {
        r_LicenseNumber = i_LicenseNumber;
        m_EnergyPercentage = 0;
        r_Wheels = new List<Wheel>();
        m_VehicleProperties = new Dictionary<string, string>();
        m_VehicleProperties["ModelName"] = "Model Name";
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

    public List<Wheel> Wheels
    {
        get { return r_Wheels; }
        set { r_Wheels = value; }
    }

    public Dictionary<string, string> VehicleProperties
    {
        get { return m_VehicleProperties; }
    }

    protected void CreateWheels(float i_MaxAirPressure)
    {
        for (int i = 0; i < m_AmountOfWheels; i++)
        {
            r_Wheels.Add(new Wheel(i_MaxAirPressure));
        }
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

    public void FillTank(float i_Amount, eEnergySource i_EnergySource)
    {
        if (!(i_EnergySource == r_Tank.EnergySource))
        {
            throw new ArgumentException("Incorrect gas type.");
        }

        r_Tank.Fill(i_Amount);
        m_EnergyPercentage = r_Tank.CurrentCapacity / r_Tank.MaxCapacity;
    }
}