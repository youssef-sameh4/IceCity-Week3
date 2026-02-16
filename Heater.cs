public abstract class Heater
{
    private double _powerValue;
    public double PowerValue { get { return _powerValue; } set
        {

            if (value < 0)
            {
                throw new ArgumentException("Power cannot be negative");
            }
            _powerValue = value;
        }

    }
   public abstract double EffectivePower();
 }

