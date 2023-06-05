public class VehicleFactory
{
    private static List<string> s_VehicleTypes = new List<string>{"Car", "Electric Car", "Motorcycle", "Electric Motorcycle", "Truck"};

    public static List<string> VehicleTypes
    {
        get { return s_VehicleTypes; }
    }

    public static Vehicle makeVehicle(string i_LicenseNumber, string i_VehicleType)
    {
        Type type = Type.GetType(i_VehicleType);

        return (Vehicle)Activator.CreateInstance(type, i_LicenseNumber);
    }
}