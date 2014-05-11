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

    public class Bullet
    {
        public Direction DirectionBullet { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Bitmap CurrentBulletBmp;
        public bool alreadyKilledSomething { get; set; }

        public Bullet()
        {
      
            DirectionBullet = Direction.Right;
            CurrentBulletBmp = Properties.Resources.injd;
        }


        /// <summary>
        /// апдејтирај ја позицијата на куршумот во случај да треба да се пука
        /// и додека се пука.
        /// </summary>
        /// <param name="Position">позиција на играчот кој се движи</param>
        /// <param name="CharacterSize">големина на играчот кој се движи</param>
        public void UpdatePosition(Point Position, Size CharacterSize) {
            switch (DirectionBullet)
            {
                case Direction.Right:
                    {
                        X = Position.X + CharacterSize.Width + 2;
                        Y = Position.Y + CurrentBulletBmp.Height / 2;

                        break;
                    }
                case Direction.Left:
                    {
                        X = Position.X -50;
                        Y = Position.Y + CurrentBulletBmp.Height / 2;
                        break;
                    }
                case Direction.Up:
                    break;
                default:
                    break;
            }  
        }

        /// <summary>
        /// апдејтирај ја насоката на куршумот (пукањето) всушност сликата .
        /// </summary>
        public void UpdateDirection(Direction direction) {

            DirectionBullet = direction;

            switch (direction)
            {
                case Direction.Right: { CurrentBulletBmp.Dispose(); CurrentBulletBmp = Properties.Resources.injd; }
                    break;
                case Direction.Left: { CurrentBulletBmp.Dispose(); CurrentBulletBmp = Properties.Resources.injl; }
                    break;
                case Direction.Up:
                    break;
                default:
                    break;
            } 
        }

        /// <summary>
        /// цртање на куршум (слика).
        /// </summary>
        /// <param name="grp"></param>
        public void DrawBullet(Graphics grp) {
            grp.DrawImage(CurrentBulletBmp, new Point(X, Y));
        }


        

      
    }

}
