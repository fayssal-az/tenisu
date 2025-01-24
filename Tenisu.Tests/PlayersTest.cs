using System;
using System.Collections.Generic;
using Xunit;
using Tenisu.Domain;
using Tenisu.Tests;
using NSubstitute;

namespace Tenisu.Tests
{
    public class PlayersTest
    {
        [Fact]
        public void ComputeMeanBMI_WithValidPlayers_ReturnsCorrectAverage()
        {
            // Arrange
            var players = new Players();


            players.ListOfPlayers = new List<Player>
            {
                new Player { Data = new Data { Height = 2, Weight = 160 }},
                new Player { Data = new Data { Height = 1, Weight = 50 }}
            };

            // Act
            double meanBMI = players.ComputeMeanBMI();

            // Assert
            Assert.Equal(45, meanBMI);
        }

        [Fact]
        public void ComputeMeanBMI_WithSinglePlayer_ReturnsPlayerBMI()
        {
            // Arrange
            var players = new Players();

            players.ListOfPlayers = new List<Player>
            {
                new Player { Data = new Data { Height = 2, Weight = 160 }}
            };

            // Act
            double meanBMI = players.ComputeMeanBMI();

            // Assert
            Assert.Equal(40, meanBMI);
        }

        [Fact]
        public void ComputeMeanBMI_WithNoPlayers_ReturnsZero()
        {
            // Arrange
            var players = new Players();

            // Act
            double meanBMI = players.ComputeMeanBMI();

            // Assert
            Assert.Equal(0, meanBMI);
        }


        [Fact]
        public void ComputeGreatestCountryRatio_ReturnsCountryWithHighestRatio()
        {
            // Arrange
            var player1 = new FakePlayer { Ratio = 1.5, Country = new Country { Code = "SRB" } };
            var player2 = new FakePlayer { Ratio = 2.0, Country = new Country { Code = "FRA" } };

            var listOfPlayers = new List<Player> { player1, player2 };
            var players = new Players();

            players.ListOfPlayers = listOfPlayers;

            // Act
            var result = players.ComputeGreatestCountryRatio();

            // Assert
            Assert.Equal("FRA", result.Code);
        }

        [Fact]
        public void ComputeMedianHeight_WithEvenNumberOfPlayers_ReturnsCorrectMedian()
        {
            // Arrange
            var players = new Players();

            players.ListOfPlayers = new List<Player>
                {
                new Player { Data = new Data { Height = 180 }},
                new Player { Data = new Data { Height = 190 }},
                new Player { Data = new Data { Height = 170 }},
                new Player { Data = new Data { Height = 200 }}
                };

            // Act
            double medianHeight = players.ComputeMedianHeight();

            // Assert
            Assert.Equal(185, medianHeight);
        }

        [Fact]
        public void ComputeMedianHeight_WithOddNumberOfPlayers_ReturnsCorrectMedian()
        {
            // Arrange
            var players = new Players();

            players.ListOfPlayers = new List<Player>
                {
                new Player { Data = new Data { Height = 180 }},
                new Player { Data = new Data { Height = 190 }},
                new Player { Data = new Data { Height = 170 }}
                };

            // Act
            double medianHeight = players.ComputeMedianHeight();

            // Assert
            Assert.Equal(180, medianHeight);
        }



        public class FakePlayer : Player
        {
            public double Ratio { get; set; }
            public override double ComputeRatio() => Ratio;
        }
        [Fact]
        public void ComputeMedianHeight_WithEmptyList_ThrowsException()
        {
            // Arrange
            var players = new Players();

            // Act & Assert
            Assert.Throws<Exception>(() => players.ComputeMedianHeight());
        }

        [Fact]
        public void ComputeMeanBMI_WithTwoPlayers_ReturnsCorrectAverage()
        {
            // Arrange
            var players = new Players();

            players.ListOfPlayers = new List<Player>
    {
        new Player { Data = new Data { Height = 2, Weight = 160 }},
        new Player { Data = new Data { Height = 1, Weight = 50 }}
    };

            // Act
            double meanBMI = players.ComputeMeanBMI();

            // Assert
            Assert.Equal(45, meanBMI);
        }
}

}