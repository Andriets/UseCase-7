using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCase_7.PlayerTask;

namespace UseCase_7Tests
{
    public class PlayerTests
    {
        private PlayerAnalyzer _playerAnalyzer;

        public PlayerTests()
        {
            _playerAnalyzer = new PlayerAnalyzer();
        }

        [Theory]
        [InlineData(25, 5, 2, 250)]
        [InlineData(15, 3, 3, 67.5)]
        [InlineData(35, 15, 4, 2520)]

        public void CalculateScore_ReturnsCorrectScore(int age, int experience, int skills, double expectedScore)
        {
            // Arrange
            List<Player> players = new List<Player>
            {
                new Player
                {
                    Age = age,
                    Experience = experience,
                    Skills = new List<int> { skills, skills, skills }
                }
            };

            // Act
            var result = _playerAnalyzer.CalculateScore(players);

            // Assert
            Assert.Equal(expectedScore, result);
        }

        [Fact]
        public void CalculateScore_ReturnsSumOfScores()
        {
            // Arrange
            var player1 = new Player
            {
                Age = 25,
                Experience = 5,
                Skills = new List<int> { 2, 2, 2 }
            };

            var player2 = new Player
            {
                Age = 15,
                Experience = 3,
                Skills = new List<int> { 3, 3, 3 }
            };

            var player3 = new Player
            {
                Age = 35,
                Experience = 15,
                Skills = new List<int> { 4, 4, 4 }
            };

            List<Player> players = new List<Player>
            {
                player1,
                player2, 
                player3
            };

            var expectedScore = 2837.5;

            // Act
            var result = _playerAnalyzer.CalculateScore(players);

            // Assert
            Assert.Equal(expectedScore, result);
        }

        [Fact]
        public void CalculateScore_ThrowsAnError()
        {
            // Arrange
            List<Player> players = new List<Player>
            {
                new Player
                {
                    Age = 25,
                    Experience = 10,
                    Skills = null,
                }
            };

            //Assert
            Assert.Throws<ArgumentNullException>(() => _playerAnalyzer.CalculateScore(players));
        }

        [Fact]
        public void CalculateScore_Returns0()
        {
            // Arrange
            List<Player> players = new List<Player>();
            var expectedScore = 0;

            // Act
            var result = _playerAnalyzer.CalculateScore(players);

            //Assert
            Assert.Equal(expectedScore, result);
        }
    }
}
