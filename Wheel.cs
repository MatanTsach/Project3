public class Wheel 
{
    private string m_ManufacturerName = "";
    private float m_AirPressure;
    private float m_MaxAirPressure;
    
    public Wheel(float i_MaxAirPressure)
    {
        m_MaxAirPressure = i_MaxAirPressure;
        m_AirPressure = 0;
    }

    public string ManufacturerName
    {
        get { return m_ManufacturerName; }
        set { m_ManufacturerName = value; }
    }

    public float AirPressure
    {
        get { return m_AirPressure; }
    }

    public float MaxAirPressure
    {
        get { return m_MaxAirPressure; }
    }
    
    public void Inflate(float i_AirToAdd)
    {
        if ((m_AirPressure + i_AirToAdd) > m_MaxAirPressure)
        {
            throw new ValueOutOfRangeException($"Cannot inflate higher than {m_MaxAirPressure}");
        }
        else
        {
            m_AirPressure += m_MaxAirPressure;
        }
    }
}