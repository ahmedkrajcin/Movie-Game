using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication4
{
    class MovieData
    {
        public int year;
        public String [] actors;
        public int awards;
        public int runtime;
        public int rating;
        public String title;
        public String [] genre;


        public MovieData Data(string movie)
        {
            MovieData movie1 = new MovieData();
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString("http://www.omdbapi.com/?t=" + movie);
                JObject obj = JObject.Parse(json);
                if (obj != null)
                {

                    movie1.title = "" + obj["Title"];
                    String[] arr2 = ("" + obj["Genre"]).Split(',');

                    movie1.genre = arr2;
                    movie1.year = int.Parse("" + obj["Year"]);
                    string oscar = "" + obj["Awards"];
                    String[] arr = oscar.Split(' ');
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (arr[i] == ("Oscar."))
                            movie1.awards = int.Parse(arr[i - 1]);
                        else if (arr[i] == ("Oscars."))
                            movie1.awards = int.Parse(arr[i - 1]);
                        else
                            movie1.awards = 0;
                    }

                    movie1.runtime = int.Parse(Regex.Replace(("" + obj["Runtime"]), "[^0-9]+", string.Empty));
                    movie1.rating = int.Parse(Regex.Replace(("" + obj["imdbRating"]), "[^0-9]+", string.Empty));
                    String[] arr1 = ("" + obj["Actors"]).Split(',');
                    movie1.actors = arr1;
                    return movie1;
                }
                
            }

        }

    }
}
