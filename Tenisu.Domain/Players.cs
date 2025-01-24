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
            var maxRatio = ListOfPlayers.Max(p => p.ComputeRatio());
            return ListOfPlayers.FirstOrDefault(p => p.ComputeRatio() == maxRatio).Country;
        }

        public double ComputeMeanBMI()
        {
            return ListOfPlayers.Count == 0 ? 0 : ListOfPlayers.Sum(p => p.ComputeBMI()) / ListOfPlayers.Count();
        }

        public double ComputeMedianHeight()
        {
            if (ListOfPlayers.Count == 0)
            {
            throw new Exception("The list of players is empty");
            }

            var orderedList = ListOfPlayers.OrderBy(p => p.Data.Height).ToList();
            int count = orderedList.Count;

            if (count == 2)
            {
                return (orderedList[0].Data.Height + orderedList[1].Data.Height) / 2;
            }
            else if (count % 2 == 0)
            {
                int midIndex1 = count / 2 - 1;
                int midIndex2 = count / 2;
                return (orderedList[midIndex1].Data.Height + orderedList[midIndex2].Data.Height) / 2;
            }
            else
            {
                int midIndex = count / 2;
                return orderedList[midIndex].Data.Height;
            }
        }
        
    }
}
