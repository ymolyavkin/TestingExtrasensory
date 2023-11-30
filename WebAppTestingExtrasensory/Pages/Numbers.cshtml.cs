using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppTestingExtrasensory.Models;

namespace WebAppTestingExtrasensory.Pages
{
    [IgnoreAntiforgeryToken]
    public class NumbersModel : PageModel
    {
        readonly string SessionKeyName = "user";
        
        public List<string> Info { get; set; }
        
        public void OnGet()
        {
            Info = new List<string>();
            Actors empty = ManageUser.InitializeData();
            
            Info.Add("¬веденные ¬ами числа: ");
            for (int i = 0; i < empty.GetListPredictors().Count; i++)
            {
                Info.Add(empty.GetAllNamesPredictors()[i]);
            }
            
        }
        public void OnPost(int number)
        {
            {
                Info = new List<string>();
                Info.Add("");
                Actors actors = HttpContext.Session.GetObjectFromJson<Actors>(SessionKeyName);
                if (actors == null)
                {
                    actors = ManageUser.InitializeData();
                    actors.AddNextNumbers(number);
                    string[] fullInfo = actors.PrintAllInfo();
                    Info = fullInfo.ToList<string>();
                    HttpContext.Session.SetObjectAsJson(SessionKeyName, actors);
                }
                else
                {
                    actors.AddNextNumbers(number);
                    string currentInfo = actors.CurrentInfo();
                    string[] fullInfo=actors.PrintAllInfo();
                    Info = fullInfo.ToList<string>();
                    HttpContext.Session.SetObjectAsJson(SessionKeyName, actors);
                   // string currentRating = actors.CurrentRating();
                }

                
            }

        }
    }
}
