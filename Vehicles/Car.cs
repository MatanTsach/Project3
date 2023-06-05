public class Car : Vehicle
{
    protected string m_Color = "";
    protected int m_Doors;
    private const float c_WheelMaxPressure = 33;
    public Car(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        m_AmountOfWheels = 4;
        CreateWheels(c_WheelMaxPressure);
        r_Tank = new Tank(46, eEnergySource.Gas_Octan95); 
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

    public void FillTank(float i_Amount)
    {
        base.FillTank(i_Amount, eEnergySource.Gas_Octan95);
    }
}