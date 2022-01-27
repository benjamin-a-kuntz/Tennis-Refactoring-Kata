namespace Tennis
{
    /// <summary>
    /// Wrapper for object of type TennisPlayer.
    /// Used solely to allow unit testing.
    /// Methods should be passthrough only and directly invoke TennisPlayer methods.
    /// </summary>
    public interface ITennisPlayer
    {
        /// <summary>
        /// Player's current score
        /// </summary>
        public int score { get; set; }

        /// <summary>
        /// Player name
        /// </summary>
        public string name { get; set; }
    }
}

