using GiphyAPIJim1.Models;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace GiphyAPIJim1.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            string apiKey = System.Web.Configuration.WebConfigurationManager.AppSettings["giphyAPIKey"];

            string query = "funny dogs";
            Random random = new Random();
            string offset = random.Next(0, 400).ToString();

            //create the request to the API
            WebRequest request = WebRequest.Create("http://api.giphy.com/v1/gifs/search?q=" + query + "&api_key=" + apiKey + "&limit=30" + "&offset=" + offset);
            //send that API request
            WebResponse response = request.GetResponse();
            //Get back the response stream
            Stream stream = response.GetResponseStream();
            //make it accessible
            StreamReader reader = new StreamReader(stream);
            //put stream into string, which is JSON formatted
            string responseFromServer = reader.ReadToEnd();

            JObject parsedString = JObject.Parse(responseFromServer);

            Gif myGifs = parsedString.ToObject<Gif>();

            return View(myGifs);

        }




    }

}