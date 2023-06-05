using System.Reflection;

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

        Console.Write("Please enter license number: ");
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
                    string vehicleType = requestVehicleType();
                    newVehicle = VehicleFactory.makeVehicle(licenseNumber, vehicleType.Replace(" ", ""));
                    requestWheelsData(newVehicle);
                    break;
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            
            foreach (string property in newVehicle.VehicleProperties.Keys)
            {
                while(true)
                {
                    try
                    {
                        Console.Write($"Please enter {newVehicle.VehicleProperties[property]}: ");
                        string input = Console.ReadLine();

                        PropertyInfo propertyInfo = newVehicle.GetType().GetProperty(property);
                        propertyInfo.SetValue(newVehicle, Convert.ChangeType(input, propertyInfo.PropertyType));
                        break;
                    } catch (Exception)
                    {
                        Console.WriteLine("Invalid input for field, try again.");
                    }
                }
            }

            r_Garage.AddVehicle(newVehicle);
            Console.WriteLine($"Vehicle {licenseNumber} sucessfully added to the garage!");
        }
    }

    private string requestVehicleType()
    {
        string vehicleSelection = string.Join(", ", VehicleFactory.VehicleTypes);
        Console.Write($"Please enter vehicle type (Available types: {vehicleSelection}): ");
        string selection = Console.ReadLine();

        if (VehicleFactory.VehicleTypes.Contains(selection))
        {
            return selection;
        }

        throw new ArgumentException("Vehicle type does not exist.");
    }    

    private void requestWheelsData(Vehicle i_Vehicle)
    {
        string wheelModel;
        float wheelPressure;
        Console.Write("Would you like to insert wheels data for all wheels(Y/N)? ");
        string input = Console.ReadLine();
        if (input == "Y")
        {
            (wheelModel, wheelPressure) = getWheelInfo();
            i_Vehicle.UpdateAllWheels(wheelModel, wheelPressure);
        }
        else if (input == "N")
        {
            for (int i = 0; i < i_Vehicle.Wheels.Count; i++)
            {
                Console.WriteLine($"Insert data for wheel {i+1}");
                (wheelModel, wheelPressure) = getWheelInfo();
                i_Vehicle.UpdateWheel(i, wheelModel, wheelPressure);
            }
        }
        else
        {
            throw new ArgumentException("Please enter Y or N.");
        }
    }

    private (string, float) getWheelInfo()
    {
        string wheelModelType;
        float wheelPressure;

        Console.Write("Insert model type: ");
        wheelModelType = Console.ReadLine();
        Console.Write("Insert pressure: ");
        if(float.TryParse(Console.ReadLine(), out wheelPressure))
        {
            return (wheelModelType, wheelPressure);
        }
        
        throw new FormatException("Incorrect pressure format.");
    }
}