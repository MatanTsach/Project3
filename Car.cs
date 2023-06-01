public class Car : Vehicle
{
    protected string m_CarColor = "";
    protected int m_Doors;

    public Car() : base()
    {
        m_VehicleFields.Add("Color");
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
}