using System;

namespace KataTennis
{
    public class Game
    {
        private readonly string _joueurAName;
        private readonly string _joueurBName;

        private int joueurAScore;
        private int joueurBScore;

        public Game(string joueurAName, string joueurBName)
        {
            _joueurAName = joueurAName;
            _joueurBName = joueurBName;
        }

        public string GetScore()
        {
            if (HasWinner())
            {
                return GetPlayerWithHigherScore() + " wins";
            }
            if (IsDeuce())
            {
                return Translate(joueurAScore) + " all";
            }
            if (IsAdvantage())
            {
                return "Advantage " + GetPlayerWithHigherScore();
            }
            return "test";
        }

        private bool IsAdvantage()
        {
            if (joueurAScore >= 3 && joueurBScore >= 3 
                && (joueurAScore == joueurBScore + 1 || joueurBScore == joueurAScore + 1))
            {
                return true;
            }
            return false;
        }

        private bool IsDeuce()
        {
            if (joueurAScore >= 3 && joueurBScore >= 3 && joueurBScore == joueurAScore)
            {
                return true;
            }
            return false;
        }

        private bool HasWinner()
        {
            if (joueurAScore >= 4 && joueurAScore > joueurBScore + 2 || joueurBScore >= 4 && joueurBScore > joueurAScore + 2)
                return true;
            return false;
        }

        public string GetPlayerWithHigherScore()
        {
            if (joueurAScore > joueurBScore)
                return _joueurAName;
            if (joueurAScore < joueurBScore)
                return _joueurBName;
            return "";
        }

        private string Translate(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "fifteen";
                case 2:
                    return "thirty";
                case 3:
                    return "forty";
            }
            throw new ArgumentOutOfRangeException();
        }

        public void PlayerAScore()
        {
            joueurAScore++;
        }

        public void PlayerBScore()
        {
            joueurBScore++;
        }
    }
}
