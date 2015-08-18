using NUnit.Framework;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class GameTests
    {
        private Game _game;

        private void RollMany(int n, int pins)
        {
            for (int i = 0; i < n; i++)
            {
                _game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            _game.Roll(5);
            _game.Roll(5);
        }

        private void RollStrike()
        {
            _game.Roll(10);
        }

        [SetUp]
        public void SetUp()
        {
            _game = new Game();
        }

        [Test]
        public void Game_Should_HaveScoreOfZero_When_NoPinsHit()
        {
            // Arrange
            RollMany(20, 0);

            // Act
            var result = _game.Score();

            // Assert
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void Game_Should_HaveScore20_When_NoOnePinEveryFrame()
        {
            // Arrange
            RollMany(20, 1);

            // Act
            var result = _game.Score();

            // Assert
            Assert.That(result, Is.EqualTo(20), "Score should be 20 when one pin hit in every frame");
        }

        [Test]
        public void Game_Should_HaveScore16_When_SpareAnd3()
        {
            // Arrange
            RollSpare();
            _game.Roll(3);
            RollMany(17, 0);

            // Act
            var result = _game.Score();

            // Assert
            Assert.That(result, Is.EqualTo(16));
        }

        [Test]
        public void Game_Should_HaveScore24_WhenStrikeAnd3And4()
        {
            // Arrange
            RollStrike();
            _game.Roll(3);
            _game.Roll(4);
            RollMany(16, 0);

            // Act
            var result = _game.Score();

            // Assert
            Assert.That(result, Is.EqualTo(24));
        }

        [Test]
        public void Game_Should_HaveScore300_WhenOnlySrikes()
        {
            // Arrange
            RollMany(12, 10);

            // Act
            var result = _game.Score();

            // Assert
            Assert.That(result, Is.EqualTo(300));
        }
    }
}
