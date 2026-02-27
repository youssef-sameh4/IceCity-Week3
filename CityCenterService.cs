using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity_Week2
{
     class CityCenterService
    {
        
         public static  async Task<Heater> RequestReplacementAsync()
        {
            await Task.Delay(1000);

            Console.WriteLine("CityCenter: Replacement heater is being dispatched...");

            
               return new ElectricHeater { PowerValue = 2000 };
            

        }
    }
}
