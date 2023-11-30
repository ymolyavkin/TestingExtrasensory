namespace WebAppTestingExtrasensory.Models
{
    [Serializable]
    public class Predictor
    {
        private string _name;
        private List<int> _ratings;
        private List<int> _predictions;

         
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public List<int> Ratings
        {
            get { return _ratings; }
            set { _ratings = value; }
        }
        public List<int> Predictions
        {
            get { return _predictions; }
            set { _predictions = value; }
        }

        public Predictor()
        {
            _ratings = new List<int>();
            _predictions = new List<int>();
        }

       
        public int GetLastPredictions()
        {
            return Predictions[Predictions.Count - 1];
        }
        public void AddPrediction(int number)
        {
            Predictions.Add(number);
        }
        private int GetCoefficientProximity(int original, int predicted)
        {
            int difference = Math.Abs(original - predicted);
            if (difference <= 20)
            {
                return 5;
            }
            else if (difference > 20 && difference <= 40)
            {
                return 4;
            }
            else if (difference > 40 && difference <= 60)
            {
                return 3;
            }
            else if (difference > 60 && difference <= 80)
            {
                return 2;
            }
            else if (difference > 80)
            {
                return 1;
            }
            else return 0;
        }
        public void AddRating(int original, int prediction)
        {
            Ratings.Add(GetCoefficientProximity(original, prediction));
        }
        public decimal GetRating()
        {
            decimal average = 0;
            foreach (int item in Ratings)
            {
                average += item;
            }
            average /= Ratings.Count;

            return decimal.Round(average, 2, MidpointRounding.AwayFromZero);
        }

    }
}
