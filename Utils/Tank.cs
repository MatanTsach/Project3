public class Tank
{
    protected float m_CurrentCapacity = 0;
    protected readonly float r_MaxCapacity;
    protected readonly eEnergySource r_EnergySource;

    public Tank(float i_MaxCapacity, eEnergySource i_EnergySource)
    {
        r_MaxCapacity = i_MaxCapacity;
        r_EnergySource = i_EnergySource;
    }

    public float MaxCapacity
    {
        get { return r_MaxCapacity; }
    }

    public float CurrentCapacity
    {
        get { return m_CurrentCapacity; }
    }

    public eEnergySource EnergySource
    {
        get { return r_EnergySource; }
    }

    public void Fill(float i_Amount)
    {
        if ((m_CurrentCapacity + i_Amount) <= r_MaxCapacity)
        {
            m_CurrentCapacity += i_Amount;
        }
        else
        {
            throw new ValueOutOfRangeException("Maximum tank capacity exceeded.");
        }
    }
}