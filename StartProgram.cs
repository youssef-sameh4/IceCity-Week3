
    public class StartProgram
    {
    static public void Start()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("=========================================");
        Console.WriteLine("        WELCOME TO ICECITY HEATING       ");
        Console.WriteLine("=========================================\n");
        Console.ResetColor();
        InputHandler inputHandler = new InputHandler();
        Service service = new Service();
        Owner owner = new Owner();
        owner = inputHandler.inputOwnerData();
        Report report = new Report();
        for (int i = 0; i < owner.houses.Count; i++)
        {
            report.PrintReport(owner, owner.houses[i]);
        }
    }
}

