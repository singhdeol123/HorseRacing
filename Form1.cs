using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HorseRacing
{
    public partial class Form1 : Form
    {

        

        Horse[] Horses = new Horse[4];

        Factory pf = new Factory();
        Punter[] punters = new Punter[3];
        public Form1()
        {
            InitializeComponent();
            track();
        }


        private void track()
        {

            Horse.startpoint1 = H1.Right - Left;
            Horse.RacetrackLength1 = Size.Width - 50; 

            Horses[0] = new Horse() { PictureBox = H1 };
            Horses[1] = new Horse() { PictureBox = H2};
            Horses[2] = new Horse() { PictureBox =  H3 };
            Horses[3] = new Horse() { PictureBox = H4 };

            punters[0] = pf.getPunter("Player1", MaximumBet, p1bet); 
            punters[1] = pf.getPunter("Player2", MaximumBet, p2bet); 
            punters[2] = pf.getPunter("Player3", MaximumBet, p3bet); 

            foreach (Punter punter in punters)
            {
                punter.UpdateLabels();
            }
        }


        private void startbtn_Click(object sender, EventArgs e)
        {
            bool NoWinner = true;
            int winningh;
            startbtn.Enabled = false; 

            while (NoWinner)
            { 
                Application.DoEvents();
                for (int i = 0; i < Horses.Length; i++)
                {
                    if (Horse.Run(Horses[i]))
                    {
                        winningh = i + 1;
                        NoWinner = false;
                        MessageBox.Show("We have a winner Horse" + winningh);
                        foreach (Punter punter in punters)
                        {
                            if (punter.bet != null)
                            {
                                punter.Collect(winningh); 
                                punter.bet = null;
                                punter.UpdateLabels();
                            }
                        }
                        foreach (Horse Horse in Horses)
                        {
                            Horse.StartPoint();
                        }
                        break;
                    }
                }
            }
            if (punters[0].busted && punters[1].busted && punters[2].busted)
            {  
                String message = "Do you want to Play Again?";
                String title = "GAME OVER";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    track(); 
                }
                else
                {
                    this.Close();
                }

            }
            startbtn.Enabled = true; 
        }

        private void betbtn_Click(object sender, EventArgs e)
        {

            int PunterNum = 0;

            if (p1rbtn.Checked)
            {
                PunterNum = 0;
            }
            if (p2rbtn.Checked)
            {
                PunterNum = 1;
            }
            if (p3rbtn.Checked)
            {
                PunterNum = 2;
            }

            punters[PunterNum].PlaceBet((int)betamt.Value, (int)horsenum.Value);
            punters[PunterNum].UpdateLabels();
        }

        private void p1rbtn_CheckedChanged(object sender, EventArgs e)
        {
            Maximumbet(punters[0].Cash);
        }

        private void p2rbtn_CheckedChanged(object sender, EventArgs e)
        {
            Maximumbet(punters[1].Cash);
        }

        private void p3rbtn_CheckedChanged(object sender, EventArgs e)
        {
            Maximumbet(punters[2].Cash);
        }
        private void Maximumbet(int Cash)
        {
            MaximumBet.Text = String.Format("Maximum Bet: ${0}", Cash);
        }

        private void Lion2_Click(object sender, EventArgs e)
        {

        }

        private void H1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
