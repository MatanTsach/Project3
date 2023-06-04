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

        Console.WriteLine("> Please enter license number: ");
        licenseNumber = Console.ReadLine();
        if(r_Garage.ContainsVehicle(licenseNumber))
        {   
            Console.WriteLine("Vehicle exists in garage registry, moving to Repair mode.");
            r_Garage.ChangeMode(licenseNumber, eVehicleMode.Repair);
        }
        else
        {
            Vehicle newVehicle;

            while (true)
            {
                try
                {
                    VehicleFactory.eVehicleType vehicleType = requestVehicleType();
                    newVehicle = VehicleFactory.makeVehicle(licenseNumber, vehicleType);
                    requestWheelsData(newVehicle);
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            
            foreach (string property in newVehicle.VehicleProperties)
            {
                while(true)
                {
                    try
                    {
                        Console.Write($"Please enter {property}: ");
                        newVehicle.GetType().GetProperty(property).SetValue(property, Console.ReadLine());
                        break;
                    } catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
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

        VehicleFactory.eVehicleType vehicleType;
        if(Enum.TryParse(selection.Replace(" ", "_"), out vehicleType))
        {
            return vehicleType;
        }

        throw new ArgumentException("Vehicle type does not exist.");
    }    

    private void requestWheelsData(Vehicle i_Vehicle)
    {
        string wheelModel;
        float wheelPressure;
        Console.WriteLine("Would you like to insert wheels data for all wheels? type Y for Yes and any other key for No");
        string input = Console.ReadLine();
        if (input == "Y")
        {
            (wheelModel, wheelPressure) = getWheelInfo();
            i_Vehicle.UpdateAllWheels(wheelModel, wheelPressure);
        }
        else
        {
            
            for (int i = 0; i < i_Vehicle.Wheels.Count; i++)
            {
                Console.WriteLine($"Insert data for wheel {i}");
                (wheelModel, wheelPressure) = getWheelInfo();
                i_Vehicle.UpdateWheel(i, wheelModel, wheelPressure);
            }
        }
    }

    private (string, float) getWheelInfo()
    {
        string wheelModelType;
        float wheelPressure;

        Console.WriteLine("> Insert model type: ");
        wheelModelType = Console.ReadLine();
        Console.WriteLine("> Insert pressure: ");
        if(float.TryParse(Console.ReadLine(), out wheelPressure))
        {
            return (wheelModelType, wheelPressure);
        }
        
        throw new FormatException("Incorrect pressure format.");
    }
}