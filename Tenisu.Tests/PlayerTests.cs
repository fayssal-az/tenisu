using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tenisu.Domain;

namespace Tenisu.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void ComputeRatio_WithValidData_ReturnsCorrectRatio()
        {
            // Arrange
            var player = new Player
            {
                Data = new Data
                {
                    Last = new List<double> { 1, 0, 0 }
                }
            };

            // Act
            double ratio = player.ComputeRatio();

            // Assert
            Assert.Equal(1.0 / 3.0, ratio, 5);
        }

        [Fact]
        public void ComputeRatio_WithNoData_ThrowsException()
        {
            // Arrange
            var player = new Player
            {
                Data = new Data
                {
                    Last = new List<double>()
                }
            };

            // Act & Assert
            Assert.Throws<Exception>(() => player.ComputeRatio());
        }

        [Fact]
        public void ComputeBMI_WithValidData_ReturnsCorrectBMI()
        {
            // Arrange
            var player = new Player
            {
                Data = new Data { Height = 2, Weight = 160 }
            };

            // Act
            double bmi = player.ComputeBMI();

            // Assert
            Assert.Equal(40, bmi);
        }

        [Fact]
        public void ComputeBMI_WithZeroHeight_ThrowsException()
        {
            // Arrange
            var player = new Player
            {
                Data = new Data { Height = 0, Weight = 160 }
            };

            // Act & Assert
            Assert.Throws<Exception>(() => player.ComputeBMI());
        }
    }
}