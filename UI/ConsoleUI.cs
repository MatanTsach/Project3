using System.Text;

public class ConsoleUI
{
    private readonly Garage r_Garage;
    private readonly Commands r_Commands;
    public ConsoleUI()
    {
        r_Garage = new Garage();
        r_Commands = new Commands(r_Garage);
    }

    private void showMenu()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("\n\n------- MENU -------\n");
        sb.Append("1. Add a new vehicle\n");
        sb.Append("2. Display vehicles in the garage\n");
        sb.Append("3. Change vehicle status\n");
        sb.Append("4. Inflate vehicle tires (to max)\n");
        sb.Append("5. Fuel gas vehicle\n");
        sb.Append("6. Charge electric vehicle\n");
        sb.Append("7. Display vehicle data\n");
        sb.Append("--------------------\n");
        Console.WriteLine(sb.ToString());
    }
    public void Start()
    {
        while (true)
        {
            showMenu();
            Console.Write("Please write your desired menu item: ");
            string userInput = Console.ReadLine();
            handleInput(userInput);
        }
    }

    private void handleInput(string i_UserInput)
    {
        int choice;

        if(!int.TryParse(i_UserInput, out choice))
        {
            throw new FormatException();
        }
        
        switch (choice)
        {
            case 1:
                r_Commands.GarageEntry();
                break;
            case 2:
                r_Commands.DisplayVehicles();
                break;
            case 3:
                r_Commands.ChangeVehicleMode();
                break;
            case 4:
                r_Commands.InflateToMax();
                break;
            case 5:
                r_Commands.handleFuel();
                break;
            case 6:
                r_Commands.handleCharge();
                break;
            case 7:
                break;
            default:
                Console.WriteLine("Not on the menu! please enter a correct menu item.");
                break;
        }
    }


}