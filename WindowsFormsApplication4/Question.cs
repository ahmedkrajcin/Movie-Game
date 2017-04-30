using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication4
{
    public  class Question
    {
        public String question;
        public Question[] questionlist;
        public static int NUM_OF_QUESTIONS = 6;
        public Question()
        {
            questionlist = new Question[NUM_OF_QUESTIONS];

        }

        internal int checkAns()
        {
            throw new NotImplementedException();
        }
        //public  bool checkAns(String ans);

    }
    public class ActorQuestion : Question
    {

        public  ActorQuestion(string actor)
        {
            question = "Name a movie in which an actor " + actor + " plays one of the leading roles";
        }
        public static int checkAns(String ans)
        {
            MovieData movie = new MovieData();
            movie = movie.Data(ans);
            int correct = 0;
            for (int i = 0; i < movie.actors.Length; i++) {
                if (movie.actors[i] == ans)
                    correct= 1; }


            return correct;
        }

    }
    public class GenreQuestion : Question
    {
        public GenreQuestion(string genre)
        {
            this.question = "Name a movie of genre " + genre;
        }
        public static int checkAns(String ans)
        {
            MovieData movie = new MovieData();
            movie = movie.Data(ans);
            int correct = 0;
            for (int i = 0; i < movie.genre.Length; i++)
            {
                if (movie.genre[i] == ans)
                    correct = 1;
            }


            return correct;

        }
    }
    public class RatingQuestion : Question
    {
        public RatingQuestion()
        {
            this.question = "Name a movie that has a higher IMDB score";
        }
        public static int checkAns(String ans)
        {
            MovieData movie = new MovieData();
            movie = movie.Data(ans);
           
            return movie.rating;
        }
    }
    public class RuntimeQuestion : Question
    {
        public RuntimeQuestion()
        {
            this.question = "Name a movie that lasts longer";
        }
        public  static int checkAns(String ans)
        {
            MovieData movie = new MovieData();
            movie = movie.Data(ans);

            return movie.rating;

        }
    }
    public class OscarQuestion : Question
    {
        public OscarQuestion()
        {
            this.question = "Name a movie that has won more Oscars";
        }
        public static int checkAns(String ans)
        {
            MovieData movie = new MovieData();
            movie = movie.Data(ans);

            return movie.awards;

        }
    }
    public class YearQuestion : Question
    {
        public YearQuestion()
        {
            this.question = "Name a movie that is older";
        }
        public static int checkAns(String ans)
        {
            MovieData movie = new MovieData();
            movie = movie.Data(ans);

            return movie.year;
        }

    }




}

