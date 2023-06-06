public class Motorcycle : Vehicle
{
    private string m_LicenseType = "";
    private readonly List<string> r_AvailableLicenses = new List<string>{"A1", "A2", "AA", "B1"};

    public Motorcycle(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        m_AmountOfWheels = 2;
        m_MaxAirPressure = 31;
        CreateWheels();
        r_Tank = new Tank(6.4f, eEnergySource.Octan98); 
        m_VehicleProperties["LicenseType"] = "License Type";
    }

    public string LicenseType
    {
        get { return m_LicenseType; }
        set
        {
            if (r_AvailableLicenses.Contains(value))
            {
                m_LicenseType = value;
            }
            else
            {
                m_LicenseType = "";
                throw new ArgumentException(string.Format("License is not valid. Available License: {0}", 
                                                            string.Join(", ", r_AvailableLicenses)));
            }
        }
    }
}