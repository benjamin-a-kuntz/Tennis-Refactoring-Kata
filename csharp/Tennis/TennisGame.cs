using System;

namespace Tennis
{
    /// <summary>
    /// Primary class - contains all variables and functions necessary for program execution.
    /// </summary>
    class TennisGame : ITennisGame
    {
        //Variable Declarations
        private readonly TennisPlayer player1, player2;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="player1Name">TennisPlayer object containing name and score for player1</param>
        /// <param name="player2Name">TennisPlayer object containing name and score for player2</param>
        public TennisGame(string player1Name, string player2Name)
        {
            this.player1 = new TennisPlayer() { name = player1Name, score = 0 };
            this.player2 = new TennisPlayer() { name = player2Name, score = 0 };
        }

        /// <summary>
        /// Simple logic for score increment.  
        /// Takes playername and increments the score of the relevant player. 
        /// I.E. if playerName = "player1", then player1Score is incremented
        /// </summary>
        /// <param name="playerName"></param>
        public void WonPoint(string playerName)
        {
            if (playerName == player1.name)
                player1.score += 1;
            else if (playerName == player2.name)
                player2.score += 1;
            else
            {
                throw new System.Exception("Specified player name '" + playerName + "' does not match the name of either of the current players ['" + player1.name + "', '" + player2.name + "'].");
            }
        }

        /// <summary>
        /// Logic for score tabulation and translation into tennis jargan.
        /// </summary>
        /// <returns>string score value</returns>
        public string GetScore()
        {
            /*
             * Scoring translation rules below for future reference:
             *      Win condition - a game is won by the first player to have score >= 4 in total and to have at least 2 points more than the opponent
             *      Running score jargon - The running score of each game is described in a manner peculiar to tennis:
             *          0 points - "Love"
             *          1 point  - "Fifteen"
             *          2 points - "Thirty"
             *          3 points - "Forty"
             *          3+ points and scores are within a point but not tied - lead player "Advantage"
             *              [Further explanation of above - if at least 3 points have been scored by each side, and a player has one more point than the
             *              opponent, the score if the game is stated as "Advantage" for the player in the lead.]
             *          4+ points and tie - "Deuce"
             *          0-3 point tie - "[jargon score]-All"
             *              [I.E. Players are tied at 2 points each - score reported as "Thirty-All"]
            */

            //Stores technical term for current game score
            string scoreJargon = "";

            //Ensure both scores are nonnegative before attempting computation
            if (player1.score >= 0 && player2.score >= 0)
            {
                //All tie conditions
                if (player1.score == player2.score)
                {
                    //0-3 point tie - "[jargon score]-All"
                    if (player1.score < 3)
                        scoreJargon = translateScore(player1.score) + "-All";
                    //4+ points and tie -"Deuce"
                    else
                        scoreJargon = "Deuce";
                }

                //All non-tie Advantage and Win conditions
                //3+ points and scores are within a point but not tied - lead player "Advantage"
                //Win condition - a game is won by the first player to have score >= 4 in total and to have at least 2 points more than the opponent
                else if ((player1.score > 3 || player2.score > 3) && player1.score != player2.score)
                {
                    scoreJargon = calculateAdvantageOrWin(player1.score, player2.score);
                }

                //All non-tie, non-win conditions
                else
                {
                    string player1ScoreJargon = translateScore(player1.score);
                    string player2ScoreJargon = translateScore(player2.score);
                    scoreJargon = player1ScoreJargon + "-" + player2ScoreJargon;
                }
            }
            else
                throw new System.Exception("One of the players scores is an invalid (negative) value.");

            return scoreJargon;
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