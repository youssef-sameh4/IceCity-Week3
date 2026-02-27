using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCity_Week2
{
    internal class HeaterFailedException:Exception
    {
       

        public HeaterFailedException(string message):base(message) 
        {
           
        }
    }
}
