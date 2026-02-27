
public class InputHandler
{
    private List<DailyUsage> dailyUsages()
    {
        /*  List<DailyUsage> dailyusages = new List<DailyUsage>();
          Console.WriteLine("\n===== Enter Daily Usage Data (30 Days for Demo) =====\n"); 
          for (int i = 1; i <= 2; i++)
          {
              Console.WriteLine($"Day {i}");

              Console.Write("Working Hours : ");
              double hours = double.Parse(Console.ReadLine());

              Console.Write("Heater Value : ");
              double value = double.Parse(Console.ReadLine());

              DailyUsage dailyUsage = new DailyUsage(i, hours, value);

              dailyusages.Add(dailyUsage);
          }*/
        List<DailyUsage> dailyusages = new List<DailyUsage> {
            new DailyUsage(1, 5, 1500),
            new DailyUsage(2, 6, 1450),
            new DailyUsage(3, 4.5, 1600),
            new DailyUsage(4, 7, 1550),
            new DailyUsage(5, 3, 1300),
            new DailyUsage(6, 8, 1700),
            new DailyUsage(7, 6.5, 1500),
            new DailyUsage(8, 5.5, 1400),
            new DailyUsage(9, 4, 1350),
            new DailyUsage(10, 7.5, 1650),
            new DailyUsage(11, 6, 1500),
            new DailyUsage(12, 5, 1450),
            new DailyUsage(13, 4.5, 1550),
            new DailyUsage(14, 8, 1750),
            new DailyUsage(15, 6.5, 1600),
            new DailyUsage(16, 5, 1500),
            new DailyUsage(17, 3.5, 1200),
            new DailyUsage(18, 7, 1680),
            new DailyUsage(19, 6, 1520),
            new DailyUsage(20, 4, 1380),
            new DailyUsage(21, 5.5, 1490),
            new DailyUsage(22, 6.5, 1580),
            new DailyUsage(23, 7, 1620),
            new DailyUsage(24, 3, 1250),
            new DailyUsage(25, 4.5, 1400),
            new DailyUsage(26, 8, 1800),
            new DailyUsage(27, 6, 1550),
            new DailyUsage(28, 5, 1480),
            new DailyUsage(29, 7.5, 1700),
            new DailyUsage(30, 6.5, 1600)

        };
        return dailyusages;
    }
    private House inputHouseData()
    {
        List<(string type, double power)> heatersData = new List<(string type, double power)>();
        Console.WriteLine("\n===== Enter House Information =====\n");
        Console.Write("House ID ?");
        int HouseId = int.Parse(Console.ReadLine());
        Console.Write("Enter Address ? ");
        string HouseAddress = Console.ReadLine();


        Console.Write("How many heaters in this house? ");
        int num = int.Parse(Console.ReadLine());

        for (int i = 1; i <= num; i++)
        {
            Console.WriteLine($"Heater {i}");
            Console.Write("Type ( Electric, Gas) : ");
            string type = Console.ReadLine();
            Console.Write("Enter Power Value : ");
            double power = double.Parse(Console.ReadLine());
            heatersData.Add((type, power));
        }
        var dailyusages = dailyUsages();
        House house = new House(HouseId, HouseAddress, dailyusages, heatersData);
        return house;


    }
    public Owner inputOwnerData()
    {
        bool oK = true;
        Owner owner = new Owner();
        Console.WriteLine("Enter Owner Information");
        Console.WriteLine("------------------------");
        Console.Write("Enter Owner Name ? ");
        owner.OwnerName = Console.ReadLine();

        Console.Write("Phone Number ? ");
        owner.PhoneNumber = Console.ReadLine();

        Console.Write("Enter Email ? ");
        owner.Email = Console.ReadLine();


        Console.Write("Enter Address ? ");
        owner.Address = Console.ReadLine();
        //////////////
        while (oK)
        {
            var house = inputHouseData();
            owner.houses.Add(house);
            Console.Write("Do you want to move into a new house? (Yes : No)");
            string choice = Console.ReadLine();
            if (choice == "No")
            {
                oK = false;
            }

        }
        return owner;
    }
}
    

