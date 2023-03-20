namespace bearish_model.Models;

    public class Trending_Bearish
    {
        public string Ticker { get; set; }
        public string Sentiment { get; set; }
        public string LastSentiment { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Change { get; set; }
        public double ChangePercent { get; set; }
        public int Volume { get; set; }
        public long MarketCap { get; set; }
        public int PreviousVolume { get; set; }
        public double PreviousClose { get; set; }
    }

   
