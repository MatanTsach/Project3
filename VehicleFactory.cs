public class VehicleFactory
{
    public enum eVehicleType
    {
        Gas_Car,
        Electric_Car,
        Gas_Motorcycle,
        Electric_Motorcyle,
        Truck
    }

    public static T makeVehicle<T>(string i_LicenseNumber, string i_ModelType)
    {
        return Activator.CreateInstance(Type.GetType())
    }
}