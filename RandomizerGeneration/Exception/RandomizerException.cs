

namespace MessengerRandomizerMappingGenerator.RandomizerGeneration.Exception
{
    /// <summary>
    /// Empty rando exception class used to keep track of errors
    /// </summary>
    public class RandomizerException : System.Exception
    {
        public RandomizerException()
        {
        }

        public RandomizerException(string message) : base(message)
        {
        }

        public RandomizerException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
