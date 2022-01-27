namespace Tennis
{
    /// <summary>
    /// Wrapper for object of type TennisGame.
    /// Used solely to allow unit testing.
    /// Methods should be passthrough only and directly invoke TennisGame methods.
    /// </summary>
    public interface ITennisGame
    {
        /// <summary>
        /// Triggers the main score changing logic based on paramater playerName.  Does not return a value.
        /// </summary>
        /// <param name="playerName"></param>
        void WonPoint(string playerName);

        /// <summary>
        /// Calculates the current game score(s) and returns the result in a string format.
        /// </summary>
        /// <returns>String of scores</returns>
        string GetScore();
    }
}

