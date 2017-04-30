using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        Random rd = new Random();
        Question questions = new Question();
        Actor[] a1 = new Actor[10];
        Genre[] g1 = new Genre[5];
        int currentquestion = 0;
        int currentplayer = 0;
        Player[] p1 = new Player[Player.NUM_OF_PLAYERS];
        int maxyear=2017, maxaward=0, maxrating=0, maxruntime=0;
        int year, award, rating, runtime;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            questionlabel.Text = "";
            checkAns();
            currentplayer += 1;
            GetNextElement(questions.questionlist);
            

        }

        private void checkAns()
        {
            if (currentquestion == 0)
                p1[currentplayer].points += ActorQuestion.checkAns(textBox1.Text);
            else if (currentquestion == 1)
            {
                if(maxruntime<RuntimeQuestion.checkAns(textBox1.Text))
                    {
                    maxruntime = RuntimeQuestion.checkAns(textBox1.Text);
                    runtime = currentplayer;
                }
            }
            else if (currentquestion == 2)
            {
                if (maxyear > YearQuestion.checkAns(textBox1.Text))
                {
                    maxyear = YearQuestion.checkAns(textBox1.Text);
                    year = currentplayer;

                }

            }
            else if (currentquestion == 3)
                p1[currentplayer].points += GenreQuestion.checkAns(textBox1.Text);
           
           
            else if (currentquestion == 4)
            {
                if (maxrating < RatingQuestion.checkAns(textBox1.Text))
                {
                    maxrating = RatingQuestion.checkAns(textBox1.Text);
                    rating = currentplayer;

                }
            }
            else if (currentquestion == 5)
            {
                if (maxaward< OscarQuestion.checkAns(textBox1.Text))
                {
                    maxaward = OscarQuestion.checkAns(textBox1.Text);
                    award = currentplayer;

                }
            }




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            

            for (int i = 0; i < p1.Length; i++)
            {
                p1[i] = new Player();
            }

            a1[0] = new Actor("Tom Hanks");
            a1[1] = new Actor("Johnny Depp");
            a1[2] = new Actor("Leonardo DiCaprio");
            a1[3] = new Actor("Jack Nicholson");
            a1[4] = new Actor("Robert DeNiro");
            a1[5] = new Actor("Al Pacino");
            a1[6] = new Actor("Shahrukh Khan");
            a1[7] = new Actor("Morgan Freeman");
            a1[8] = new Actor("Meryl Streep");
            a1[9] = new Actor("Brad Pitt");

            g1[0] = new Genre("Horror");
            g1[1] = new Genre("Action");
            g1[2] = new Genre("Comedy");
            g1[3] = new Genre("Romantic");
            g1[4] = new Genre("Thriller");

            label4.Visible = false;
            questions.questionlist[0] = new ActorQuestion(a1[rd.Next(0, a1.Length)].name);
            questions.questionlist[1] = new RuntimeQuestion();
            questions.questionlist[2] = new YearQuestion();
            questions.questionlist[3] = new GenreQuestion(g1[rd.Next(0, g1.Length)].name);
            questions.questionlist[4] = new RatingQuestion();
            questions.questionlist[5] = new OscarQuestion();

            //GetNextElement(questions.questionlist);

            questionlabel.Text = questions.questionlist[currentquestion].question;
            label1.Text = "" + p1[currentplayer].ID;
            

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void GetNextElement(Question[] strArray)
        { 
            
            if (currentplayer == Player.NUM_OF_PLAYERS && currentquestion == Question.NUM_OF_QUESTIONS-1)
            {
                questionlabel.Text = "The End";
                label1.Text = "";
                textBox1.Visible = false;
                button1.Visible = false;
                label3.Visible = false;
                label4.Visible = true;
                p1[year].points += 1;
                p1[award].points += 1;
                p1[rating].points += 1;
                p1[runtime].points += 1;
                int max = 0;
                int m = p1[0].points;
                for (int i = 1; i < p1.Length; i++)
                {
                    if (p1[i].points > m)
                    {
                        m = p1[i].points;
                        max = i;
                    }
                }
                label1.Text = "" + max+1;


            }


            else if (currentplayer == Player.NUM_OF_PLAYERS && currentquestion < Question.NUM_OF_QUESTIONS)
            {  currentplayer = 0;
                currentquestion += 1;
                questionlabel.Text = questions.questionlist[currentquestion].question;
                label1.Text = "" + p1[currentplayer].ID;
                
            }
             

            else
            {
                
                questionlabel.Text = questions.questionlist[currentquestion].question;
                label1.Text = "" + p1[currentplayer].ID;
            }
           // p1[currentplayer].points += questions.questionlist[currentquestion].checkAns();


        }
    }
}
