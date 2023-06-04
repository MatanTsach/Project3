public class Car : Vehicle
{
    protected string m_CarColor = "";
    protected int m_Doors;
    protected Tank m_Tank = new Tank(6.4f);
    public Car() : base()
    {
        m_VehicleFields.Add("Color");
        m_VehicleFields.Add("Number Of Doors");
        FuelType = eEnergySource.Gas_Octan95;
        Wheels = NewObjects.NewWheelsList(5,33);
        m_VehicleFields.Add("Max Tank Liters");
        m_VehicleFields.Add("Tank Liters Left");
        EnergyPercentage = Tank.CurrentCapacity / Tank.MaxCapacity;
    }

    public string Color
    {
        get { return m_CarColor; }
        set { m_CarColor = value; }
    }

    public int Doors
    {
        get { return m_Doors; }
        set { m_Doors = value; }
    }

    public Tank Tank
    {
        get { return m_Tank; }
        set { m_Tank = value; }
    }

    public bool Fual(float i_EnergyToAdd, eEnergySource i_FualTypeToAdd){
        bool isFualed = false;
        if(i_FualTypeToAdd == FuelType)
        {
            isFualed = Tank.AddToEnergyResource(i_EnergyToAdd);
        }
        EnergyPercentage = Tank.CurrentCapacity / Tank.MaxCapacity;
        
        return isFualed;
    }
}