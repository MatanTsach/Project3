public class Tank
{
    protected float m_MaxCapacity;
    protected float m_CurrentCapacity = 0;

    public Tank(float i_MaxCapacity)
    {
        m_MaxCapacity = i_MaxCapacity;
    }

    public float MaxCapacity
    {
        get { return m_MaxCapacity; }
        set { m_MaxCapacity = value; }
    }

    public float CurrentCapacity
    {
        get { return m_CurrentCapacity; }
        set { m_CurrentCapacity = value; }
    }

    public bool AddToEnergyResource(float i_EnergyToAdd)
        {
            bool isFualed = false;
            if(i_EnergyToAdd + CurrentCapacity <= MaxCapacity)
            {
                this.CurrentCapacity += i_EnergyToAdd;
                isFualed = true;
            }
            
            return isFualed;
        }
}