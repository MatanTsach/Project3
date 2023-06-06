public class Truck : Vehicle
{
    protected bool m_DangerousMaterials;
    protected float m_CargoVolume;

    public Truck(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        m_AmountOfWheels = 14;
        m_MaxAirPressure = 26;
        CreateWheels();
        r_Tank = new Tank(135, eEnergySource.Soler); 
        m_VehicleProperties["DangerousMaterials"] = "Dangerous Materials(true/false)";
        m_VehicleProperties["CargoVolume"] = "Cargo Volume";
    }

    public bool DangerousMaterials
    {
        get { return m_DangerousMaterials; }
        set { m_DangerousMaterials = value; }
    }

    public float CargoVolume
    {
        get { return m_CargoVolume; }
        set { m_CargoVolume = value; }
    }
}