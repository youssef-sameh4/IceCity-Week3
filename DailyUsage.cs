
public class DailyUsage
{
    private int _daynumber;
    private double _workinghours;
    private double heatervalue;
    public int DayNumber
    {
        get { return _daynumber; }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Day Nubmer Can Not be Less than one");
            }

            _daynumber = value;
        }
    }

    public double WorkingHours
    {
        get { return _workinghours; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentException("Working hours cannot be negative");
            }

            _workinghours = value;
        }
    }

    public double Heatervalue
    {
        get { return heatervalue; }
        set
        {

            if (value < 0)
            {
                throw new ArgumentException("Power cannot be negative");
            }
            heatervalue = value;
        }
    }
    public DailyUsage()
    { }
    public DailyUsage(int dayNumber, double workingHours, double heatervalue)
    {
        DayNumber = dayNumber;
        WorkingHours = workingHours;
        Heatervalue = heatervalue;
    }

    


}

