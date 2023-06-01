public class ElectricMotorcycle : Vehicle 
{
    protected eLicenseType m_LicenseType;
    protected int m_EngineVolume;
    protected float m_MaxBatteryHours = 2.6f;
    protected float m_BatteryHoursLeft;

    public ElectricMotorcycle() : base()
    {
        FuelType = eFuelType.Electric;
        Wheels = NewObjects.NewWheelsList(2,31);
        m_BatteryHoursLeft = m_MaxBatteryHours;
        m_VehicleFields.Add("License Type");
        m_VehicleFields.Add("Engine Volume");
        m_VehicleFields.Add("Max Battery Hours");
        m_VehicleFields.Add("Battery Hours Left");
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

    public float MaxBatteryHours
    {
        get { return m_MaxBatteryHours; }
        set { m_MaxBatteryHours = value; }
    }

    public float BatteryHoursLeft
    {
        get { return m_BatteryHoursLeft; }
        set { m_BatteryHoursLeft = value; }
    }

    public bool charge(int i_HoursToCharge)
    {
        bool isCharged = true;
        if((m_BatteryHoursLeft + i_HoursToCharge) > m_MaxBatteryHours)
        {
            isCharged = false;
        }
        else
        {
            m_BatteryHoursLeft += i_HoursToCharge;
        }
        return isCharged;
    }
}