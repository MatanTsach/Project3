public class Motorcycle : Vehicle
{
    protected eLicenseType m_LicenseType;
    protected int m_EngineVolume;
    private const float c_WheelMaxPressure = 31;
    public Motorcycle(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        m_AmountOfWheels = 2;
        CreateWheels(c_WheelMaxPressure);
        r_Tank = new Tank(6.4f, eEnergySource.Gas_Octan98); 
        m_VehicleProperties["LicenseType"] = "License Type";
        m_VehicleProperties["EngineVolume"] = "Engine Volume";
    }

    public eLicenseType LicenseType
    {
        get { return m_LicenseType; }
        set { m_LicenseType = value; }
    }

    public int EngineVolume
    {
        get { return m_EngineVolume; }
        set { m_EngineVolume = value; }
    }

    public void FillTank(float i_Amount)
    {
        base.FillTank(i_Amount, eEnergySource.Gas_Octan98);
    }
}