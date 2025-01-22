using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenisu.Domain;
using Tenisu.Infrastructure;

namespace Tenisu.Usecases
{


    public class FetchPlayersStatsUC

    {
        private readonly IPlayersRepository _playersRepository;
        public FetchPlayersStatsUC(IPlayersRepository playersRepository)
        {
            _playersRepository = playersRepository;
        }

        public Stats Execute()
        {
            IEnumerable<Player> playersDto = _playersRepository.GetPlayers();
            Players players = new Players() ;
            players.ListOfPlayers = (List<Player>)playersDto;

            var greatestCountryRatio = players.ComputeGreatestCountryRatio();

            var meanBMI = players.ComputeMeanBMI();

            var medianHeight = players.ComputeMedianHeight();

            return new Stats
            {
                GreatestCountry = greatestCountryRatio.Code,
                MeanBMI = meanBMI, 
                MedianHeight = medianHeight
            };
        }
    }
}
