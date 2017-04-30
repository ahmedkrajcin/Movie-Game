using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4
{
    class Player
    {   public static int currentID=0;
        public static int NUM_OF_PLAYERS = 2;
        public int ID;
        public int points;
        
        public Player()
        {
            this.ID = GetNextID();
            this.points = 0;

        }
        public Player(int id,int points)
        {
            this.ID = GetNextID(); 
            this.points = points;
            
            }

        private int GetNextID()
        {
            return ++currentID;
        }

        
        

    }
}
