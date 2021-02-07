using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HorseRacing
{
    public class Bet
    {
        public int Amount;
        public int HorseNum;
        public Punter Bettor;

        public Bet(int Amount, int HorseNum, Punter Bettor)
        {
            this.Amount = Amount;
            this.HorseNum = HorseNum;
            this.Bettor = Bettor;
        }

        public string Getmessage()
        {
            string showmessage = "";

            if (Amount > 0)
            {
                showmessage = String.Format("{0} bets {1} on horse #{2}",
                    Bettor.Name, Amount, HorseNum);
            }
            else
            {
                showmessage = String.Format("{0} hasn't placed any bets",
                    Bettor.Name);
            }
            return showmessage;
        }

        public int Pay(int Winner)
        {
            if (HorseNum == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}

