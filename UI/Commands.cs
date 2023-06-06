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
            Vehicle newVehicle = createNewVehicle(licenseNumber);
            addWheelsData(newVehicle);
            addVehicleAdditionalProperties(newVehicle);
            r_Garage.AddVehicle(newVehicle);
            Console.WriteLine($"\nVehicle {licenseNumber} sucessfully added to the garage!");
        }
    }

    public void DisplayVehicles()
    {
        string availableModes = string.Join("/", Enum.GetNames(typeof(eVehicleMode)));

        while (true)
        {
            Console.Write($"Which vehicles would you like to choose? All/{availableModes}: ");
            string userResponse = Console.ReadLine();

            if (userResponse == "All")
            {
                Console.WriteLine(string.Join("\n", r_Garage.Vehicles.Keys));
                break;
            }
            else
            {
                try
                {
                    displayVehiclesByFilter((eVehicleMode)Enum.Parse(typeof(eVehicleMode), userResponse));
                    break;
                }
                catch(ArgumentException)
                {
                    Console.WriteLine("Please enter a valid input.");
                }
            }
        }
    }

    public void ChangeVehicleMode()
    {
        string licenseNumber;

        string availableModes = string.Join("/", Enum.GetNames(typeof(eVehicleMode)));

        licenseNumber = getValidLicenseNumber();

        while(true)
        {
            try
            {
                Console.Write($"Enter mode to change to ({availableModes}): ");
                r_Garage.ChangeMode(licenseNumber, (eVehicleMode)Enum.Parse(typeof(eVehicleMode), Console.ReadLine()));
                Console.WriteLine("\nVehicle state changed succesfully!");
                break;
            }
            catch(ArgumentException)
            {
                Console.WriteLine("Please enter a valid mode.");
            }
        }
    }

    public void InflateToMax()
    {
        string licenseNumber;

        licenseNumber = getValidLicenseNumber();
        foreach(Wheel wheel in r_Garage.Vehicles[licenseNumber].Vehicle.Wheels)
        {
            wheel.Inflate(wheel.MaxAirPressure - wheel.AirPressure);
        }

        Console.Write("\nWheels are inflated!");
    }

    public void FuelVehicle(bool i_isElectric)
    {
        string licenseNumber;

        licenseNumber = getValidLicenseNumber();
        Vehicle selectedVehicle = r_Garage.Vehicles[licenseNumber].Vehicle;
        float amountToFuel = getValidAmountToFuel();
        if(i_isElectric)
        {
            if (selectedVehicle.Tank is ElectricTank electricTank)
            {
                try
                {
                    electricTank.Fill(amountToFuel);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("The license number you provided is associated with a gas vehicle. Please use menu item 3.");
            }
        }
        else
        {
            if (selectedVehicle.Tank.EnergySource != eEnergySource.Electric)
            {
                eEnergySource gasType = getValidGasType();
                try
                {
                    selectedVehicle.Tank.Fill(amountToFuel, gasType);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                Console.WriteLine("The license number you provided is associated with an electric vehicle. Please use menu item 4.");
            }
        }

        Console.WriteLine("\nVehicle has been fueled succesfully!");
    }

    private string getVehicleType()
    {
        string vehicleSelection = string.Join(", ", Enum.GetNames(typeof(VehicleFactory.eVehicleType)));
        Console.Write($"Please enter vehicle type (Available types: {vehicleSelection}): ");
        string selection = Console.ReadLine().Replace(" ", "");

        return selection;
    }    

    private void addWheelsData(Vehicle i_Vehicle)
    {
        string wheelModel;
        float wheelPressure;

        while(true)
        {
            Console.Write("Would you like to insert wheels data for all wheels(Y/N)? ");
            string input = Console.ReadLine();
            try
            {
                if (input == "Y")
                {
                    (wheelModel, wheelPressure) = getWheelInfo();
                    i_Vehicle.UpdateAllWheels(wheelModel, wheelPressure);
                    break;
                }
                else if (input == "N")
                {
                    for (int i = 0; i < i_Vehicle.Wheels.Count; i++)
                    {
                        Console.WriteLine($"Insert data for wheel {i+1}");
                        (wheelModel, wheelPressure) = getWheelInfo();
                        i_Vehicle.UpdateWheel(i, wheelModel, wheelPressure);
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.");
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    private void addVehicleAdditionalProperties(Vehicle i_Vehicle)
    {
        foreach (string property in i_Vehicle.VehicleProperties.Keys)
        {
            while(true)
            {
                try
                {
                    Console.Write($"{i_Vehicle.VehicleProperties[property]}? ");
                    string input = Console.ReadLine();

                    PropertyInfo propertyInfo = i_Vehicle.GetType().GetProperty(property);
                    propertyInfo.SetValue(i_Vehicle, Convert.ChangeType(input, propertyInfo.PropertyType));
                    break;
                }
                catch (TargetInvocationException e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Please enter the correct data type.");
                }
            }
        }
    }

    private Vehicle createNewVehicle(string i_LicenseNumber)
    {
        Vehicle newVehicle;

        while (true)
        {
            try
            {
                string vehicleType = getVehicleType();
                newVehicle = VehicleFactory.makeVehicle(i_LicenseNumber, vehicleType.Replace(" ", ""));
                break;
            }
            catch(Exception)
            {
                Console.WriteLine("Vehicle type not valid. Please choose from the available vehicle types.");
            }
        }
        
        return newVehicle;
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

    private void displayVehiclesByFilter(eVehicleMode mode)
    {
        foreach (string licenseNumber in r_Garage.GetLicensesByMode(mode))
        {
            Console.WriteLine(licenseNumber);
        }
    }

    private string getValidLicenseNumber()
    {
        string licenseNumber;

        while (true)
        {
            Console.Write("Please enter license number: ");
            licenseNumber = Console.ReadLine();
            if (r_Garage.ContainsVehicle(licenseNumber))
            {
                break;
            }

            Console.WriteLine("Please enter a valid license number.");
        }

        return licenseNumber;
    }

    private float getValidAmountToFuel()
    {
        float amountToFuel;

        while (true)
        {
            Console.Write("Please enter amount to fuel: ");
            if (float.TryParse(Console.ReadLine(), out amountToFuel))
            {
                break;
            }

            Console.WriteLine("Please enter a valid decimal number.");
        }

        return amountToFuel;
    }

    private eEnergySource getValidGasType()
    {
        eEnergySource gasType;
        eEnergySource[] gasTypes = (eEnergySource[])Enum.GetValues(typeof(eEnergySource));
        string availableGasTypes = string.Join("/", gasTypes.Where(gasType => gasType != eEnergySource.Electric));

        while (true)
        {
            Console.Write($"Please enter a gas type to fuel({availableGasTypes}): ");
            if (Enum.TryParse(typeof(eEnergySource), Console.ReadLine(), out object result))
            {
                gasType = (eEnergySource)result;
                break;
            }
            else
            {
                Console.WriteLine("Please choose from the available gas types.");
            }
        }
        
        return gasType;
    }
}