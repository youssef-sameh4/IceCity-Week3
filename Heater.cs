using IceCity_Week2;
using NUnit.Framework.Internal.Execution;

public abstract class Heater
{
    private double _powerValue;
    private DateTime? _lastOpenTime;
    public double PowerValue { get { return _powerValue; } set
        {

            if (value < 0)
            {
                throw new ArgumentException("Power cannot be negative");
            }
            _powerValue = value;
        }

    }
   public  event EventHandler? OpenHeater;
    public event EventHandler<DailyUsage>? CloseHeater;
    public void Open()
    {
        _lastOpenTime = DateTime.UtcNow;
        if (OpenHeater != null)
        {
            if(PowerValue>5000)
            {
                throw new HeaterFailedException("Power OF Heater Is Large");
            }
            OpenHeater.Invoke(this, EventArgs.Empty);
        }
    }
    public void Close()
    {
        if (CloseHeater != null)
        {
        if (_lastOpenTime == null)
        {
            throw new HeaterFailedException("The Last Open Time Is Empty");
        }
        TimeSpan subtime= (TimeSpan)(DateTime.UtcNow - _lastOpenTime);
        _lastOpenTime = null;
            DailyUsage dailyUsage = new DailyUsage();

            dailyUsage.DayNumber= DateTime.UtcNow.Day;
            dailyUsage.Heatervalue = EffectivePower();
            dailyUsage.WorkingHours = subtime.TotalHours;

            CloseHeater.Invoke(this, dailyUsage);
        }
    }
   public abstract double EffectivePower();
 }

