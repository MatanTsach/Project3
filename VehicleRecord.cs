public class VehicleRecord
{
    private readonly Vehicle r_Vehicle;
    private eVehicleMode m_VehicleMode;

    public VehicleRecord(Vehicle i_Vehicle, eVehicleMode i_VehicleMode)
    {
        r_Vehicle = i_Vehicle;
        m_VehicleMode = i_VehicleMode;
    }

    public Vehicle Vehicle
    {
        get { return r_Vehicle; }
    }

    public eVehicleMode VehicleMode
    {
        get { return m_VehicleMode; }
        set { m_VehicleMode = value; }
    }
}