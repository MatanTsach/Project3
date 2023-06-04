public class Car : Vehicle
{
    protected string m_Color = "";
    protected int m_Doors;
    protected readonly Tank m_Tank;
    public Car() : base()
    {
        m_Tank = new Tank(6.4f);
        FuelType = eEnergySource.Gas_Octan95;
        EnergyPercentage = m_Tank.CurrentCapacity / m_Tank.MaxCapacity;
        m_VehicleProperties.Add("Color");
        m_VehicleProperties.Add("Doors");
    }

    public string Color
    {
        get { return m_Color; }
        set { m_Color = value; }
    }

    public int Doors
    {
        get { return m_Doors; }
        set { m_Doors = value; }
    }

    public bool Fuel(float i_EnergyToAdd, eEnergySource i_FualTypeToAdd){
        bool isFueled = false;
        if(i_FualTypeToAdd == FuelType)
        {
            isFueled = m_Tank.AddToEnergyResource(i_EnergyToAdd);
        }
        EnergyPercentage = m_Tank.CurrentCapacity / m_Tank.MaxCapacity;
        
        return isFueled;
    }
}