using System;

namespace Tennis
{
    /// <summary>
    /// Primary class - contains all variables and functions necessary for program execution.
    /// </summary>
    class TennisGame : ITennisGame
    {
        //Variable Declarations
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player1Name">Name of player 1</param>
        /// <param name="player2Name">Name of player 2</param>
        public TennisGame(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        /// <summary>
        /// Simple logic for score increment.  
        /// Takes playername and increments the score of the relevant player. 
        /// I.E. if playerName = "player1", then m_score1 is incremented
        /// </summary>
        /// <param name="playerName"></param>
        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
        }

        /// <summary>
        /// Logic for score tabulation and translation into tennis jargan.
        /// </summary>
        /// <returns>string score value</returns>
        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (m_score1 == m_score2)
            {
                switch (m_score1)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (m_score1 >= 4 || m_score2 >= 4)
            {
                var minusResult = m_score1 - m_score2;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = m_score1;
                    else { score += "-"; tempScore = m_score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }

        public string calculateAdvantageOrWin(int player1Score, int player2Score)
        {
            int scoreDifference = Math.Abs(player1Score - player2Score);
            string result;

            switch (scoreDifference)
            {
                case 1:
                    result = "Advantage ";
                    break;
                default:
                    result = "Win for ";
                    break;
            }

            if (player1Score > player2Score)
                result += "player1";
            else
                result += "player2";

            return result;
        }

        public string translateScore(int score)
        {
            string result;

            switch (score)
            {
                case 0:
                    result = "Love";
                    break;
                case 1:
                    result = "Fifteen";
                    break;
                case 2:
                    result = "Thirty";
                    break;
                case 3:
                    result = "Forty";
                    break;
                default:
                    throw new System.Exception("The translateScore function was passed an invalid value: " + score.ToString());
            }
            return result;
        }
    }
}

