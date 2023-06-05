public class Garage
{
    private readonly Dictionary<string, eVehicleMode> r_VehicleModes =  new Dictionary<string, eVehicleMode>();
    private readonly Dictionary<string, Vehicle> r_Vehicles = new Dictionary<string, Vehicle>();


    public bool ContainsVehicle(string i_LicenseNumber)
    {
        return r_Vehicles.Keys.Contains(i_LicenseNumber);
    }

    public void ChangeMode(string i_LicenseNumber, eVehicleMode i_Mode)
    {
        r_VehicleModes[i_LicenseNumber] = i_Mode;
    }

    public void AddVehicle(Vehicle i_Vehicle)
    {
        r_Vehicles[i_Vehicle.LicenseNumber] = i_Vehicle;
        r_VehicleModes[i_Vehicle.LicenseNumber] = eVehicleMode.Repair;
    }
    
}