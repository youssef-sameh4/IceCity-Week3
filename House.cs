  public class House
  {
    public House()
    { }

    public House(int houseId, string houseAddress, List<DailyUsage> dailyUsages, List<(string type, double power)> heaters)
    {
        HouseId = houseId;
        HouseAddress = houseAddress;
        this.dailyUsages = dailyUsages;
        foreach (var item in heaters)
        {
            Heater heater;
            if (item.type == "electric")
            {

                heater = new ElectricHeater { PowerValue = item.power };
            }
            else
                heater = new GasHeater { PowerValue = item.power };

            Heaters.Add(heater);


        }
    }
    public int HouseId {  get; set; }
    
    public string HouseAddress { get; set; }
    public List<DailyUsage> dailyUsages = new List<DailyUsage>();
    public List<Heater?> Heaters = new List<Heater>();
    public Action<DailyUsage>? SaveDailyUsage;

    

    public void SubscribeToHeaters()
    {
        foreach(var heater in Heaters)
        {
            if (heater != null)
            {
                heater.CloseHeater += (sender, usage) =>
            {
                SaveDailyUsage?.Invoke(usage);
            };
            }
        }
    }
}

