namespace TddTennisScore
{
    public class Game
    {
        public int FirstPlayerScore { get; set; }
        public int SecondPlayerScore { get; set; }
        public int Id { get; set; }

        private bool IsSameScore()
        {
            return FirstPlayerScore == SecondPlayerScore;
        }

        public string ScoreResult()
        {
            if (IsSameScore() && FirstPlayerScore == 1)
                return "Fifteen All";
            if (IsSameScore() && FirstPlayerScore == 2)
                return "Thirty All";

            return "Love All";
        }
    }
}