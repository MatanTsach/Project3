public class Car : Vehicle
{
    protected string m_CarColor = "";
    protected int m_DoorsAmount;

    public Car() : base()
    {
        m_VehicleFields.Add("Color");
    }
}