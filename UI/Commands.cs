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
        sb.Append("2. Repair\n");
        sb.Append("3. Fixed\n");
        sb.Append("4. Paid\n");
        Console.WriteLine(sb.ToString());

        while (true)
        {
            string i_UserInput = Console.ReadLine();
            int choice;

            if(!int.TryParse(i_UserInput, out choice))
            {
                throw new FormatException();
            }

            if(choice >= 1 && choice <=4)
            {
                DisplayVehiclesByFilter(choice);
                break;
            }
            else
            {
            Console.WriteLine("Not on the menu! please enter a correct menu item.");
            }
        }
    }

    public void DisplayVehiclesByFilter(int i_Filter)
    {
        if(i_Filter == 1)
        {
            Console.WriteLine("All the vehicles in the garage:");
            foreach (string licenseNumber in r_Garage.Vehicles.Keys)
            {
                Console.WriteLine(licenseNumber);
            }
        }
        else
        {
            eVehicleMode filter= eVehicleMode.Repair;

            switch (i_Filter)
            {
                case 3:
                    filter = eVehicleMode.Fixed;
                    break;
                case 4:
                    filter = eVehicleMode.Paid;
                    break;
            }
            Console.WriteLine("All the vehicles in " + filter + " mode in the garage:");

            foreach (string licenseNumber in r_Garage.VehicleModes.Keys)
            {
                eVehicleMode vehicleMode = r_Garage.VehicleModes[licenseNumber];
                if(vehicleMode == filter)
                {
                    Console.WriteLine(licenseNumber);
                }
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
        sb.Append("The vehicle " + licenseNumber + " is in " + currentMode + " mode\n");
        sb.Append("Which mode would you like to change to ?\n");
        sb.Append("Please insert mode:\n");
        sb.Append("1. Repair\n");
        sb.Append("2. Fixed\n");
        sb.Append("3. Paid\n");
        Console.WriteLine(sb.ToString());

        while (true)
        {
            string i_UserInput = Console.ReadLine();
            int choice;

            if(!int.TryParse(i_UserInput, out choice))
            {
                throw new FormatException();
            }

            if(choice >= 1 && choice <=3)
            {
                eVehicleMode mode= eVehicleMode.Repair;

                switch (choice)
                {
                    case 2:
                        mode = eVehicleMode.Fixed;
                        break;
                    case 3:
                        mode = eVehicleMode.Paid;
                        break;
                }
                r_Garage.ChangeMode(licenseNumber,mode);
                Console.WriteLine("The vehicle " + licenseNumber + " mode changed to " + r_Garage.VehicleModes[licenseNumber]);
                break;
            }
            else
            {
            Console.WriteLine("Not on the menu! please enter a correct menu item.");
            }
        }

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

    public void handleFuelOrCharge(string i_VehicleType)
    {
        string licenseNumber;
        eEnergySource fuelType= eEnergySource.Gas_Octan95;
        int amout = 0;

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

        if(i_VehicleType == "Gas")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Choose a fuel type:\n");
            sb.Append("1. Gas_Octan95\n");
            sb.Append("2. Gas_Octan98\n");
            sb.Append("3. Gas_Soler\n");
            Console.WriteLine(sb.ToString());

            while (true)
            {
                string i_UserInput = Console.ReadLine();
                int choice;

                if(!int.TryParse(i_UserInput, out choice))
                {
                    throw new FormatException();
                }

                if(choice >= 1 && choice <=3)
                {
                    

                    switch (choice)
                    {
                        case 2:
                            fuelType = eEnergySource.Gas_Octan98;
                            break;
                        case 3:
                            fuelType = eEnergySource.Gas_Soler;
                            break;
                    }
                    break;
                }
                else
                {
                Console.WriteLine("Not on the menu! please enter a correct menu item.");
                }
            }
        }
        if(i_VehicleType != "Electric")
        {
            while(true)
            {
                if(i_VehicleType == "Gas")
                {
                    Console.WriteLine("Please enter amount to fuel");
                }
                else
                {
                    Console.WriteLine("Please enter amount of minutes to charge");
                }
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
        }
        else
        {
            fuelType = eEnergySource.Electric;
        }

        r_Garage.Vehicles[licenseNumber].FillTank(amout, fuelType);

        if(i_VehicleType == "Electric")
        {
            Console.WriteLine("Vehicle Charged!");
        }
        else
        {
            Console.WriteLine("Vehicle Fueled!");
        }
        
    }
}