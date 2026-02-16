
    
    public class Report
    {
        private Service service = new Service();

        public void PrintReport(Owner owner, House house)
        {
            int totalWork = service.CalculateTotalWorkingTime(house.dailyUsages);
            double medianHeater = service.CalculateMedianHeaterValue(house.dailyUsages);
            double monthlyCost = service.CalculateMonthlyAverageCost(totalWork, medianHeater);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=======================================");
            Console.WriteLine("         MONTHLY HEATING REPORT         ");
            Console.WriteLine("=======================================\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Owner Name     : ");
            Console.ResetColor();
            Console.WriteLine(owner.OwnerName);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("House Address  : ");
            Console.ResetColor();
            Console.WriteLine(house.HouseAddress);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Total Hours    : ");
            Console.ResetColor();
            Console.WriteLine(totalWork + " Hours");

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Median Heater  : ");
            Console.ResetColor();
            Console.WriteLine(medianHeater);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Monthly Cost   : ");
            Console.ResetColor();
            Console.WriteLine($"{monthlyCost:F2} EGP");

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n---------------------------------------\n");
            Console.ResetColor();
        }
    }


