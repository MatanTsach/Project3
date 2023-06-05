/*
public class Motorcycle : Vehicle 
{
    protected eLicenseType m_LicenseType;
    protected int m_EngineVolume;
    protected Tank m_Tank = new Tank(6.4f);

    public Motorcycle() : base()
    {
        FuelType = eEnergySource.Gas_Octan98;
        Wheels = NewObjects.NewWheelsList(2,31);
        m_VehicleFields.Add("License Type");
        m_VehicleFields.Add("Engine Volume");
        m_VehicleFields.Add("Max Tank Liters");
        m_VehicleFields.Add("Tank Liters Left");
        EnergyPercentage = Tank.CurrentCapacity / Tank.MaxCapacity;
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

    public Tank Tank
    {
        get { return m_Tank; }
        set { m_Tank = value; }
    }

    public bool Charge(float i_EnergyToAdd) {
        bool isFualed = Tank.AddToEnergyResource(i_EnergyToAdd);
        EnergyPercentage = Tank.CurrentCapacity / Tank.MaxCapacity;

        return isFualed;
    }
}
*/