
public class InputHandler
{
    private List<DailyUsage> dailyUsages()
    {

        List<DailyUsage> dailyusages = new List<DailyUsage>();
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
        }
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
    

