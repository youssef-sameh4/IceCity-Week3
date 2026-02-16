
public class Service
{
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

        if (n % 2 == 1)
            return values[n / 2];           
        else
            return (values[n / 2 - 1] + values[n / 2]) / 2.0;
    }

    public double CalculateMonthlyAverageCost(int totalWorkingTime, double medianHeaterValue)
    {
        return medianHeaterValue * ((double)totalWorkingTime / (24 * 30));
    }
}

