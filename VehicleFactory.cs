public class VehicleFactory
{
    public enum eVehicleType
    {
        Gas_Car,
        Electric_Car,
        Gas_Motorcycle,
        Electric_Motorcycle,
        Truck
    }

    public static Vehicle makeVehicle(string i_LicenseNumber, eVehicleType i_VehicleType)
    {
        Type type = Type.GetType(i_VehicleType.ToString().Replace("_",""));
        
        return (Vehicle)Activator.CreateInstance(type, i_LicenseNumber);
    }
}