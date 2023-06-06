public class Car : Vehicle
{
    private string m_Color = "";
    private int m_Doors;
    private readonly List<string> r_AvailableColors = new List<string>{"White", "Black", "Yellow", "Red"};
    private readonly List<int> r_AvailableDoorAmounts = new List<int>{2, 3, 4, 5};
    public Car(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        m_AmountOfWheels = 5;
        m_MaxAirPressure = 33;
        CreateWheels();
        r_Tank = new Tank(46, eEnergySource.Octan95); 
        m_VehicleProperties["Color"] = "Color";
        m_VehicleProperties["Doors"] = "Amount of doors";
    }

    public string Color
    {
        get { return m_Color; }
        set
        {
            if (r_AvailableColors.Contains(value))
            {
                m_Color = value;
            }
            else
            {
                throw new ArgumentException(string.Format("Color is not valid. Available colors: {0}", 
                                                            string.Join(", ", r_AvailableColors)));
            }
        }
    }

    public int Doors
    {
        get { return m_Doors; }
        set
        {
            if (r_AvailableDoorAmounts.Contains(value))
            {
                m_Doors = value;
            }
            else
            {
                throw new ArgumentException(string.Format("Door amount is not valid. Available door amounts: {0}", 
                                                            string.Join(", ", r_AvailableDoorAmounts)));
            } 
        }
    }
}