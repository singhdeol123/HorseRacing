using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRacing
{
    
        public class Player1 : Punter
        {
            public Player1(Bet MyBet, Label MaximumBet, int Cash, Label MyLabel) : base(MyBet, MaximumBet, Cash, MyLabel)
            {
            }

            public override void setPunterName()
            {
                Name = "Player1";
            }
        }
    
}
