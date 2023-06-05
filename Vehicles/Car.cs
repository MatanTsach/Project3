public class Car : Vehicle
{
    protected string m_Color = "";
    protected int m_Doors;
    private const float c_WheelMaxPressure = 32;
    public Car(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        m_AmountOfWheels = 4;
        CreateWheels(32);
        m_VehicleProperties["Color"] = "Color";
        m_VehicleProperties["Doors"] = "Amount of doors";
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
}