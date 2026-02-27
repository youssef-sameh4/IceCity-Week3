
using IceCity_Week2;
using System;
using System.Diagnostics.Metrics;
using System.Text.Json;

public class Service
{
   
    public async Task<List<DailyUsage>> GetLastMonthWeatherAsync()
    {
        List<DailyUsage> weatherList = new List<DailyUsage>();
        using var httpClient = new HttpClient();
        DateTime now = DateTime.UtcNow;

        DateTime start = new DateTime(now.Year, now.Month, 1).AddMonths(-1);

        DateTime end = new DateTime(now.Year, now.Month, 1).AddDays(-1);

        string url =

        $"https://archive-api.open-meteo.com/v1/archive?" +

       $"latitude=31.0409&longitude=31.3785" +

        $"&start_date={start:yyyy-MM-dd}" +

        $"&end_date={end:yyyy-MM-dd}" +

        $"&daily=temperature_2m_max,temperature_2m_min,precipitation_sum";


        var response = await httpClient.GetStringAsync(url);


        using var json = JsonDocument.Parse(response);


        var daily = json.RootElement.GetProperty("daily");


        var dates = daily.GetProperty("time").EnumerateArray();

        var maxTemps = daily.GetProperty("temperature_2m_max").EnumerateArray();

        var minTemps = daily.GetProperty("temperature_2m_min").EnumerateArray();

        var rain = daily.GetProperty("precipitation_sum").EnumerateArray();


        while (dates.MoveNext() && maxTemps.MoveNext() && minTemps.MoveNext() && rain.MoveNext())

        {

            Console.WriteLine(

            $"{dates.Current.GetString()} | " +

            $"Max: {maxTemps.Current.GetDouble()}°C | " +

            $"Min: {minTemps.Current.GetDouble()}°C | " +

            $"Rain: {rain.Current.GetDouble()} mm");
            DailyUsage dailyUsage = new DailyUsage()
            {
                Heatervalue = maxTemps.Current.GetDouble()
            };
            weatherList.Add( dailyUsage );
        }
        return weatherList;

    }
    public async void StartHeaterProcess(int heaterIndex, House house)
    {

        if (house.Heaters[heaterIndex] == null)
        {
            Console.WriteLine($"Slot {heaterIndex} is empty! Requesting replacement...");
            house.Heaters[heaterIndex] = await CityCenterService.RequestReplacementAsync();
            return;
        }
        try
        {
            house.Heaters[heaterIndex].Open();

        }
        catch (HeaterFailedException ex)
        {
            var replacement = await CityCenterService.RequestReplacementAsync();
            house.Heaters[heaterIndex] = replacement;
        }
    }
    public int CalculateTotalWorkingTime(List<DailyUsage> dailyUsages)
    {
        int total = 0;
        for (int i = 0; i < dailyUsages.Count; i++)
        {
            total += (int)dailyUsages[i].WorkingHours;
        }
        return total;
    }

    public double CalculateMedianHeaterValue(List<DailyUsage> dailyUsages)
    {
        List<double> values = new List<double>();
        foreach (var item in dailyUsages)
            values.Add(item.Heatervalue);

        // Bubble sort
        for (int i = 0; i < values.Count - 1; i++)
        {
            for (int j = 0; j < values.Count - i - 1; j++)
            {
                if (values[j] > values[j + 1])
                {
                    double temp = values[j];
                    values[j] = values[j + 1];
                    values[j + 1] = temp;
                }
            }
        }
        int n = values.Count;

        if (IntExtensions.IsEven(n))
            return values[n / 2];
        else
            return (values[n / 2 - 1] + values[n / 2]) / 2.0;
    }

    public double CalculateMonthlyAverageCost(int totalWorkingTime, double medianHeaterValue)
    {
        return medianHeaterValue * ((double)totalWorkingTime / (24 * 30));
    }

    public void PrintUsingThread(List<DailyUsage> dailyUsages)
    {
        Thread t1 = new Thread(() => PrintUsageWithThreadId(dailyUsages));
        Thread t2 = new Thread(() => PrintUsageWithThreadId(dailyUsages));
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
    }
    public async Task PrintUsingTask(List<DailyUsage> dailyUsages)
    {
        var tasks = new[] {
  Task.Run(() => PrintUsageWithThreadId(dailyUsages)),
  Task.Run(() => PrintUsageWithThreadId(dailyUsages))
                     };
        await Task.WhenAll(tasks);
    }
    void PrintUsageWithThreadId(IEnumerable<DailyUsage> usages)
    {
        foreach (var u in usages)
        {
            Console.WriteLine($" Hours={u.WorkingHours} | HeaterVal={u.Heatervalue} | Thread={Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
