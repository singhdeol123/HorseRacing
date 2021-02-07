using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRacing
{
      public  class Factory
    {
        public Punter getPunter(String Name, Label MaximumBet, Label bet)
        {
            Punter p;
            switch (Name.ToLower())
            {
                case "player1":
                    p = new Player1(null, MaximumBet, 50, bet);
                    break;

                case "player2":
                    p = new Player2(null, MaximumBet, 50, bet);
                    break;

                case "player3":
                    p = new Player3(null, MaximumBet, 50, bet);
                    break;

                default:
                    p = null;
                    break;
            }
            p.setPunterName();
            return p;
        }
    }
}
