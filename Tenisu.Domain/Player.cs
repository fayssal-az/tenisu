using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Tenisu.Domain
{
    public class Player
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Shortname { get; set; }
        public string Sex { get; set; }
        public Country Country { get; set; }
        public string Picture { get; set; }
        public Data Data { get; set; }

        public virtual double ComputeRatio()
        {
            if (this.Data.Last.Count > 0)
            {              
                return this.Data.Last.Sum() / this.Data.Last.Count();
            }
                  

            throw new Exception("There is no available data");
        }

        public double ComputeBMI()
        {
            if (this.Data.Height > 0)
                return ( Data.Weight / 1000) / ( (Data.Height / 100) * (Data.Height / 100) );

            throw new Exception("There is no available data");
        }
    }
}