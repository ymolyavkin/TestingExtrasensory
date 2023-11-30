﻿namespace WebAppTestingExtrasensory.Models
{
    [Serializable]
    public class Actors
    {
        public List<Predictor> AllPredictors;
        public List<int> userNumbers;

        private string _userName;

        public string userName
        {
            get { return _userName; }
            set { _userName = value; }
        }


        public Actors()
        {
            userNumbers = new List<int>();
            AllPredictors = new List<Predictor>();
        }

        public void AddUserNumber(int number)
        {
            userNumbers.Add(number);
        }
        public void AddPredictor(Predictor predictor)
        {
            AllPredictors.Add(predictor);
        }
        
        public List<Predictor> GetListPredictors()
        {
            return AllPredictors;
        }

        public void ChangePredictors(List<Predictor> predictors, int userNumber)
        {
            Random random = new Random();
            List<Predictor> modifiedPredictor = new List<Predictor>();
            foreach (var item in predictors)
            {
                int number = random.Next(10, 100);
                item.AddPrediction(number);//Добавляем в историю очередной номер
                item.AddRating(userNumber, number);
                modifiedPredictor.Add(item);//Добавляем в коллекцию очередного экстрасенса
            }

        }
        public void AddNextNumbers(int number)
        {
            AddUserNumber(number);

            List<Predictor> originalListPredictors = GetListPredictors();
            ChangePredictors(originalListPredictors, number);
        }
        public string[] GetAllNamesPredictors()
        {
            List<string> names = new List<string>();
            foreach (var item in AllPredictors)
            {
                string predictorName = "Экстрасенс " + item.Name + ": ";
                names.Add(predictorName);
            }
            return names.ToArray<string>();
        }
        public string[] PrintAllInfo()
        {
            List<string> info = new List<string>();
            string userInfo = "Введенные Вами числа: ";
            foreach (var item in userNumbers)
            {
                userInfo += item.ToString() + " ";
            }
            info.Add(userInfo);
            foreach (var item in AllPredictors)
            {
                string predictorInfo = "Экстрасенс " + item.Name + ": ";
                foreach (var n in item.Predictions)
                {
                    predictorInfo += n.ToString() + " ";
                }
                predictorInfo += "  Уровень достоверности: " + item.GetRating().ToString();
                info.Add(predictorInfo);
                
            }

           
            return info.ToArray<string>();
        }
        public string CurrentInfo()
        {
            string info = "";

            foreach (var item in AllPredictors)
            {
                info += $"Экстрасенс {item.Name}: {item.GetLastPredictions().ToString()}       ";
            }
            return info;
        }
        /*public string CurrentRating()
        {
            string info = "";

            foreach (var item in AllPredictors)
            {
                info += "Уровень достоверности " + item.Name + ": " + item.GetRating().ToString() + "      ";
            }
            return info;
        }*/
    }
}
