using System.Reflection;
using System.Text;

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
    public void DisplayVehicles()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Which vehicles would you like to display ?\n");
        sb.Append("Please insert mode:\n");
        sb.Append("1. All vehicles\n");

        int index = 2;
        int choice;
        eVehicleMode[] modes = (eVehicleMode[])Enum.GetValues(typeof(eVehicleMode));

        foreach (eVehicleMode mode in modes)
        {
           sb.Append($"{index}. {mode} \n");
           index++;
        }
        Console.WriteLine(sb.ToString());

        while (true)
        {
            string i_UserInput = Console.ReadLine();

            if(!int.TryParse(i_UserInput, out choice))
            {
                throw new FormatException();
            }

            if(choice >= 1 && choice <= modes.Length + 1)
            {
                if(choice == 1)
                {
                    foreach (string licenseNumber in r_Garage.Vehicles.Keys)
                    {
                        Console.WriteLine(licenseNumber);
                    }
                    
                }
                else
                {
                    eVehicleMode selectedMode = modes[choice-2];
                    DisplayVehiclesByFilter(selectedMode);
                }
                break;
            }
            else
            {
            Console.WriteLine("Not on the menu! please enter a correct menu item.");
            }
        }
    }

    public void DisplayVehiclesByFilter(eVehicleMode selectedMode)
    {
            Console.WriteLine("All the vehicles in " + selectedMode + " mode in the garage:");

            foreach (string licenseNumber in r_Garage.VehicleModes.Keys)
            {
                eVehicleMode vehicleMode = r_Garage.VehicleModes[licenseNumber];
                if(vehicleMode == selectedMode)
                {
                    Console.WriteLine(licenseNumber);
                }
            }
        
    }

    public void ChangeVehicleMode()
    {
        string licenseNumber;

        Console.Write("Please enter license number: ");
        while(true)
        {
            licenseNumber = Console.ReadLine();
            if(!r_Garage.ContainsVehicle(licenseNumber))
            {   
                Console.WriteLine("Vehicle don't exists in garage registry, please ender a valid license number.");
            }
            else
            {
                break;
            }
        }

        eVehicleMode currentMode = r_Garage.VehicleModes[licenseNumber];
        StringBuilder sb = new StringBuilder();
        sb.Append($"The vehicle {licenseNumber} is in {currentMode} mode\n");
        sb.Append("Which mode would you like to change to ?\n");
        sb.Append("Please insert mode:\n");

        int index = 1;
        int choice;
        eVehicleMode[] modes = (eVehicleMode[])Enum.GetValues(typeof(eVehicleMode));

        foreach (eVehicleMode mode in modes)
        {
           sb.Append($"{index}. {mode} \n");
           index++;
        }
        Console.WriteLine(sb.ToString());

        while (true)
        {
            string i_UserInput = Console.ReadLine();
            
            if(!int.TryParse(i_UserInput, out choice))
            {
                throw new FormatException();
            }
            else
            {
                if(choice >= 1 && choice <= modes.Length)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Not on the menu! please enter a correct menu item.");

                }
            }
        }
        eVehicleMode selectedMode = modes[choice-1];
        r_Garage.ChangeMode(licenseNumber, selectedMode);
        Console.WriteLine($"Vehicle number {licenseNumber} mode has changed to {selectedMode}");

    }

    public void InflateToMax()
    {
        string licenseNumber;

        Console.Write("Please enter license number: ");
        while(true)
        {
            licenseNumber = Console.ReadLine();
            if(!r_Garage.ContainsVehicle(licenseNumber))
            {   
                Console.WriteLine("Vehicle don't exists in garage registry, please ender a valid license number.");
            }
            else
            {
                break;
            }
        }
        
        foreach(Wheel wheel in r_Garage.Vehicles[licenseNumber].Wheels)
        {
            wheel.Inflate(wheel.MaxAirPressure - wheel.AirPressure);
        }
        Console.Write("Wheels inflated!");
    }

    public void handleFuel()
    {
        string licenseNumber;

        Console.Write("Please enter license number: ");
        while(true)
        {
            licenseNumber = Console.ReadLine();
            if(!r_Garage.ContainsVehicle(licenseNumber))
            {   
                Console.WriteLine("Vehicle don't exists in garage registry, please ender a valid license number.");
            }
            else
            {
                break;
            }
        }

        
        StringBuilder sb = new StringBuilder();
        sb.Append("Chosse a fuel type ?\n");

        int index = 1;
        int choice;
        eEnergySource[] fuelTypes = (eEnergySource[])Enum.GetValues(typeof(eEnergySource));

        foreach (eEnergySource type in fuelTypes)
        {
           sb.Append($"{index}. {type} \n");
           index++;
        }
        Console.WriteLine(sb.ToString());

        eEnergySource fuelTypeToAdd;
            while (true)
            {
                string i_UserInput = Console.ReadLine();

                if(!int.TryParse(i_UserInput, out choice))
                {
                    throw new FormatException();
                }

                if(choice >= 1 && choice <= fuelTypes.Length)
                {
                    fuelTypeToAdd = fuelTypes[choice - 1];
                    break;
                }
                else
                {
                Console.WriteLine("Not on the menu! please enter a correct menu item.");
                }
            }
            int amout;

            while(true)
            {
                Console.WriteLine("Please enter amount to fuel");
                string i_UserInput = Console.ReadLine();
                
                if(!int.TryParse(i_UserInput, out amout))
                {
                    throw new FormatException();
                }
                else
                {
                    break;
                }
            }

        r_Garage.Vehicles[licenseNumber].FillTank(amout, fuelTypeToAdd);
        Console.WriteLine("Vehicle Fueled!");
    }

    public void handleCharge()
    {
        string licenseNumber;

        Console.Write("Please enter license number: ");
        while(true)
        {
            licenseNumber = Console.ReadLine();
            if(!r_Garage.ContainsVehicle(licenseNumber))
            {   
                Console.WriteLine("Vehicle don't exists in garage registry, please ender a valid license number.");
            }
            else
            {
                break;
            }
        }

        int amout;

        while(true)
        {
            Console.WriteLine("Please enter minutes to charge");
            string i_UserInput = Console.ReadLine();
                    
            if(!int.TryParse(i_UserInput, out amout))
            {
                throw new FormatException();
            }
            else
            {
                break;
            }
        }

        r_Garage.Vehicles[licenseNumber].FillTank(amout, eEnergySource.Electric);
        Console.WriteLine("Vehicle Charged!");
    }
}