public class Commands
{
    private readonly Garage r_Garage;
    public Commands(Garage i_Garage)
    {
        r_Garage = i_Garage;
    }

    public void GarageEntry()
    {
        string licenseNumber;

        Console.Write("> Please enter license number: ");
        licenseNumber = Console.ReadLine();
        if(r_Garage.ContainsVehicle(licenseNumber))
        {   
            Console.WriteLine("Vehicle exists in garage registry, moving to 'repair' mode.");
            r_Garage.ChangeMode(licenseNumber, eVehicleMode.Repair);
        }
        else
        {
            
            VehicleFactory.eVehicleType vehicleType = requestVehicleType();

            
            Vehicle newVehicle = VehicleFactory.createVehicle(licenseNumber, vehicleType);
            requestWheelsData(newVehicle);
            List<string> fields = newVehicle.Fields;

            foreach(string field in fields)
            {
                while(true)
                {
                    try
                    {
                        Console.Write($"Please enter {property}: ");
                        newVehicle.GetType().GetProperty(property).SetValue(property, Console.ReadLine());
                    } catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }
            }

            r_Garage.AddVehicle(newVehicle);
            Console.WriteLine($"Vehicle {licenseNumber} sucessfully added to the garage!");
        }
    }

    private VehicleFactory.eVehicleType requestVehicleType()
    {
        string vehicleSelection = string.Join(",", Enum.GetNames(typeof(VehicleFactory.eVehicleType))).Replace("_", " ");
        Console.WriteLine($"Please enter vehicle type. Available types: {vehicleSelection}");
        string selection = Console.ReadLine();



    }    

    private void requestWheelsData(Vehicle i_Vehicle)
    {
        Console.WriteLine("Would you like to insert wheels data for all wheels? type Y for Yes and any other key for No");
        string input = Console.ReadLine();
        if (input == "Y")
        {
            i_Vehicle.UpdateAllWheels(getWheelInfo());
        }
        else
        {
            for (int i = 0; i < i_Vehicle.Wheels.Count; i++)
            {
                Console.WriteLine($"Insert data for wheel {i}");
                i_Vehicle.UpdateWheel(i, getWheelInfo());
            }
        }
    }

    private (string, int) getWheelInfo()
    {
        string wheelModelType;
        int wheelMaxPressure;

        Console.Write("> Insert model type: ");
        wheelModelType = Console.ReadLine();
        Console.Write("> Insert max pressure: ");
        wheelMaxPressure = int.Parse(Console.ReadLine()); // will throws Format exception in case of non integer.
        
        return (wheelModelType, wheelMaxPressure);
    }
}