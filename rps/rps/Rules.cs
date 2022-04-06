namespace rps
{
    class Rules
    {
        private int count;
        public Rules(int count)
        {
            this.count = count / 2;
        }
        public GameResult GetGameResult(int a, int b)
        {
            if (b == a)
            {
                return GameResult.Draw;
            }

            if ((b > a && b - a <= count) ||
                (a > b && a - b > count))
            {
                return GameResult.Lose;
            }

            return GameResult.Win;
        }
    }
}
