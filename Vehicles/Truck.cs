public class Truck : Vehicle
{
    protected bool m_DangerousMaterials;
    protected int m_CargoVolume;
    private const float c_WheelMaxPressure = 26;
    public Truck(string i_LicenseNumber) : base(i_LicenseNumber)
    {
        m_AmountOfWheels = 14;
        CreateWheels(c_WheelMaxPressure);
        r_Tank = new Tank(135, eEnergySource.Gas_Soler); 
        m_VehicleProperties["DangerousMaterials"] = "Dangerous Materials";
        m_VehicleProperties["CargoVolume"] = "Cargo Volume";
    }

    public bool DangerousMaterials
    {
        get { return m_DangerousMaterials; }
        set { m_DangerousMaterials = value; }
    }

    public int CargoVolume
    {
        get { return m_CargoVolume; }
        set { m_CargoVolume = value; }
    }

    public void FillTank(float i_Amount)
    {
        base.FillTank(i_Amount, eEnergySource.Gas_Soler);
    }
}