using NFluent;
using NUnit.Framework;

namespace KataTennis.Test
{
    [TestFixture]    
    public class JeuTest
    {
        [Test]
        public void UnJoueurCommenceAvec0Points()
        {
            var game = new Game("Nadege", "Batiste");
            var result = game.GetScore();

            Check.That(result).Equals("Love all");
        }

        [Test]
        public void WhenPlayerAHasAtLeast4pointsAnd2PointsMoreTheOpponentThenGameIsWon()
        {
            var game = new Game("Nadege", "Batiste");
            game.PlayerAScore();
            game.PlayerAScore();
            game.PlayerAScore();
            game.PlayerBScore();
            game.PlayerAScore();
            Check.That(game.GetScore()).Equals("Nadege wins");
        }

        [Test]
        public void WhenPlayerBHasAtLeast4pointsAnd2PointsMoreTheOpponentThenGameIsWon()
        {
            var game = new Game("Nadege", "Batiste");
            game.PlayerBScore();
            game.PlayerBScore();
            game.PlayerBScore();
            game.PlayerAScore();
            game.PlayerBScore();
            Check.That(game.GetScore()).Equals("Batiste wins");
        }

        [Test]
        public void WhenPlayersHave3PointsAndScoreAreEqualsThenGameIsDeuce()
        {
            var game = new Game("Nadege", "Batiste");
            game.PlayerBScore();
            game.PlayerBScore();
            game.PlayerBScore();
            game.PlayerAScore();
            game.PlayerAScore();
            game.PlayerAScore();
            Check.That(game.GetScore()).Equals("forty all");
        }

        [Test]
        public void WhenPlayersHave3PointsAndAPlayerHasOneMorePointThenGameIsAdvantage()
        {
            var game = new Game("Nadege", "Batiste");
            game.PlayerBScore();
            game.PlayerBScore();
            game.PlayerBScore();
            game.PlayerBScore();
            game.PlayerAScore();
            game.PlayerAScore();
            game.PlayerAScore();
            Check.That(game.GetScore()).Equals("Advantage Batiste");
        }
    }
}
