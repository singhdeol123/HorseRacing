using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace HorseRacing
{
    class Horse
    {
        private static int Startpoint;
        private static int RacetrackLength;
        public PictureBox PictureBox = null;
        public int Location = 0;
        public static Random MyRandom = new Random(); 

        public static int startpoint1 { get => Startpoint; set => Startpoint = value; }
        public static int RacetrackLength1 { get => RacetrackLength; set => RacetrackLength = value; }

        

        public static bool Run(Horse obj)
        {
            int distance = MyRandom.Next(3 ,9 )+2;
            if (obj.PictureBox != null) 
                obj.MoveLionPictureBox(distance);

            obj.Location += distance;
            if (obj.Location >= (RacetrackLength1 - startpoint1))
            {
                return true;
            }
            return false;
        }

        public void StartPoint()
        {
            MoveLionPictureBox(-Location); 
            Location = 0;

        }

        public void MoveLionPictureBox(int distance)
        {
            Point p = PictureBox.Location;
            p.X += distance;
            PictureBox.Location = p; 
        }
    }
}
