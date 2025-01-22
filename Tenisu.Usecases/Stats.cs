using Tenisu.Domain;

namespace Tenisu.Usecases
{
    public class Stats
    {
        public string GreatestCountry { get; internal set; }
        public double MeanBMI { get; internal set; }
        public int MedianHeight { get; internal set; }
    }
}