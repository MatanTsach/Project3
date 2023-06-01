public class Wheel 
{
    private string m_ManufactureName;
    private float m_AirPressure;
    private float m_MaxAirPressure;
    
    public Wheel(string i_ManufactureName, float i_MaxAirPressure)
    {
        m_ManufactureName = i_ManufactureName;
        m_MaxAirPressure = i_MaxAirPressure;
        m_AirPressure = 0;
    }
    
    public bool Inflate(float i_AirToAdd)
    {
        bool inflatedWheel = true;

        if ((m_AirPressure + i_AirToAdd) > m_MaxAirPressure)
        {
            inflatedWheel = false;
        }
        else
        {
            m_AirPressure += m_MaxAirPressure;
        }

        return inflatedWheel;
    }
}