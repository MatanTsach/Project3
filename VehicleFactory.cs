public class VehicleFactory
{

    public enum eVehicleType
    {
        Car,
        ElectricCar,
        Motorcycle,
        ElectricMotorcycle,
        Truck
    }

    public static Vehicle makeVehicle(string i_LicenseNumber, string i_VehicleType)
    {
        Type type = Type.GetType(i_VehicleType);

        return (Vehicle)Activator.CreateInstance(type, i_LicenseNumber);
    }
}