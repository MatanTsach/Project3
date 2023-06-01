public class GasMotorcycle : Vehicle 
{
    protected eLicenseType m_LicenseType;
    protected int m_EngineVolume;
    protected float m_MaxTankLiters = 6.4f;
    protected float m_TankLitersLeft;


    public GasMotorcycle() : base()
    {
        FuelType = eFuelType.Octan98;
        Wheels = NewObjects.NewWheelsList(2);
        m_VehicleFields.Add("License Type");
        m_VehicleFields.Add("Engine Volume");
        m_VehicleFields.Add("Max Tank Liters");
        m_VehicleFields.Add("Tank Liters Left");
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
    public float MaxTankLiters
    {
        get { return m_MaxTankLiters; }
        set { m_MaxTankLiters = value; }
    }

    public float TankLitersLeft
    {
        get { return m_TankLitersLeft; }
        set { m_TankLitersLeft = value; }
    }

    public bool addFual(float i_LitersToAdd, eFuelType i_FualType)
    {
        bool isFualed = true;
        if(i_FualType != eFuelType.Octan98)
        {
            isFualed = false;
        }
        else
        {
            if((i_LitersToAdd + m_TankLitersLeft)> m_MaxTankLiters)
            {
                isFualed = false;
            }
            else
            {
                m_TankLitersLeft += i_LitersToAdd;
            }
        }
    return isFualed;
    }

}