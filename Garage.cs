public class Garage
{
    private readonly Dictionary<string, VehicleRecord> r_Vehicles = new Dictionary<string, VehicleRecord>();

    public Dictionary<string, VehicleRecord> Vehicles
    {
        get { return r_Vehicles; }
    }

    public bool ContainsVehicle(string i_LicenseNumber)
    {
        return r_Vehicles.Keys.Contains(i_LicenseNumber);
    }

    public void ChangeMode(string i_LicenseNumber, eVehicleMode i_Mode)
    {
        r_Vehicles[i_LicenseNumber].VehicleMode = i_Mode;
    }

    public void AddVehicle(Vehicle i_Vehicle)
    {
        r_Vehicles[i_Vehicle.LicenseNumber] = new VehicleRecord(i_Vehicle, eVehicleMode.Repair);
    }

    public List<string> GetLicensesByMode(eVehicleMode i_Mode)
    {
        List<string> licensesList = new List<string>();

        foreach (string licenseNumber in r_Vehicles.Keys)
        {
            if (r_Vehicles[licenseNumber].VehicleMode == i_Mode)
            {
                licensesList.Add(licenseNumber);
            }
        }

        return licensesList;
    }
}