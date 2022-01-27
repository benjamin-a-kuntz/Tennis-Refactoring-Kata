namespace Tennis
{
    /// <summary>
    /// Supporting object class including name and score 
    /// </summary>
    public class TennisPlayer : ITennisPlayer
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

