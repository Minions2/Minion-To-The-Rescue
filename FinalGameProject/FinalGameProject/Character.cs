using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FinalGameProject
{
    public enum State
    {
        Walking,
        Shooting
    };

    public class Character
    {

       
        public Bitmap CurrentCharacterImage { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int ScoreL1 { get; set; }
        public int ScoreL2 { get; set; }
        public int ScoreL3 { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Highscore { get; set; }
        public State StateCh { get; set; }
        public int Health { get; set; }
        public int Hit { get; set; }
        public bool Killed { get; set; }

        public bool MovingRight { get; set; }
        public bool MovingLeft { get; set; }
        public int IndexRight { get; set; }
        public int IndexLeft { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Character()
        {
            
            StateCh = State.Walking;
            MovingLeft = false;
            MovingRight = true;
            IndexLeft = 0;
            IndexRight = 1;
            CurrentCharacterImage = Properties.Resources.MINIONR1;
            UpdateInitialPosition();
            Hit = 0;
            Killed = false;
            Username = "";
            ScoreL1 = 0;
            ScoreL2 = 0;
            ScoreL3 = 0;

        }

        public void UpdateInitialPosition() {
            if (MainForm.gamemode == GameMode.Easy)
            {
                X = 30;
                Y = 200;
              
            }
            else if (MainForm.gamemode == GameMode.Medium || MainForm.gamemode == GameMode.Hard)
            {
                X = 180;
                Y = 100;
            }
        }

        /// <summary>
        /// апдејтирај ја сликата на карактерот во моментот од множеството слики за една анимација.
        /// </summary>
        public void UpdateCharacterImage() {
            
            if(MovingLeft){

                if (++IndexLeft == 8) {
                    IndexLeft = 1;
                }

                CurrentCharacterImage.Dispose();
                CurrentCharacterImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("MINIONL" + IndexLeft);
         
            } else if(MovingRight){

                if (++IndexRight == 8)
                {
                    IndexRight = 1;
                }

                CurrentCharacterImage.Dispose();
                CurrentCharacterImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("MINIONR" + IndexRight);
         
            }
        }

        public override string ToString()
        {
            return string.Format("{0}          -    {1}    -    {2}    -    {3}", Username, ScoreL1, ScoreL2, ScoreL3);
        }
    }
}
