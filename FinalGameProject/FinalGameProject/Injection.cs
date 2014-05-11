using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FinalGameProject
{
   public enum Direction { 
        Right = 0,
        Left = 1,
        Up = 2
    };

    public class Injection
    {
        public Direction DirectionInjection { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Bitmap CurrentInjectionBmp;
        public bool alreadyKilledSomething { get; set; }

        public Injection()
        {
            DirectionInjection = Direction.Right;
            CurrentInjectionBmp = Properties.Resources.injd;
        }


        /// <summary>
        /// апдејтирај ја позицијата на инекцијата во случај да треба да се пука
        /// и додека се пука.
        /// </summary>
        /// <param name="Position">позиција на играчот кој се движи</param>
        /// <param name="CharacterSize">големина на играчот кој се движи</param>
        public void UpdatePosition(Point Position, Size CharacterSize) {

            switch (DirectionInjection)
            {
                case Direction.Right:
                    {
                        X = Position.X + CharacterSize.Width + 2;
                        Y = Position.Y + CurrentInjectionBmp.Height / 2;

                        break;
                    }
                case Direction.Left:
                    {
                        X = Position.X - 50;
                        Y = Position.Y + CurrentInjectionBmp.Height / 2;
                        break;
                    }
            
                default:
                    break;
            }  
        }

        /// <summary>
        /// апдејтирај ја насоката на пукањето всушност сликата .
        /// </summary>
        public void UpdateDirection(Direction direction) {

            DirectionInjection = direction;

            switch (direction)
            {
                case Direction.Right: { CurrentInjectionBmp.Dispose(); CurrentInjectionBmp = Properties.Resources.injd; }
                    break;
                case Direction.Left: { CurrentInjectionBmp.Dispose(); CurrentInjectionBmp = Properties.Resources.injl; }
                    break;
                case Direction.Up: { CurrentInjectionBmp.Dispose(); CurrentInjectionBmp = Properties.Resources.injup; }
                    break;
                default:
                    break;
            } 
        }

        /// <summary>
        /// цртање на инекција (слика).
        /// </summary>
        /// <param name="grp"></param>
        public void DrawInjection(Graphics grp) {
            grp.DrawImage(CurrentInjectionBmp, new Point(X, Y));
        }
      
    }

}
