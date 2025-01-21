using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenisu.Domain
{
    public class Players
    {
        public List<Player> ListOfPlayers { get; set; }

        public Players()
        {
            ListOfPlayers = new List<Player>();
        }

        public Country ComputeGreatestCountryRatio()
        {
            var maxRatio = ListOfPlayers.Max(p => p.GetRatio());
            return ListOfPlayers.FirstOrDefault(p => p.GetRatio() == maxRatio).Country;
        }

        public int ComputeMeanBMI()
        {
            return ListOfPlayers.Sum(p => p.GetBMI()) / ListOfPlayers.Count();
        }


        public int ComputeMedianHeight()
        {
            var orderedList = ListOfPlayers.OrderBy(p => p.Data.Height).ToList();

            if (ListOfPlayers.Count() % 2 == 0)
            {
                var index = ListOfPlayers.Count() / 2;
                var index2 = ListOfPlayers.Count() / 2 + 1;                
                return (orderedList[index].Data.Height + orderedList[index2].Data.Height) / 2;

            }

            int medianIndex = (orderedList.Count + 1) / 2;
            return (orderedList[medianIndex]).Data.Height;
        }
    }
}
