using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerRandomizerMappingGenerator.RandomizerGeneration.Exception
{
    public class RandomizerNoMoreLocationsException : System.Exception
    {
        public RandomizerNoMoreLocationsException()
        {
        }

        public RandomizerNoMoreLocationsException(string message) : base(message)
        {
        }

        public RandomizerNoMoreLocationsException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
