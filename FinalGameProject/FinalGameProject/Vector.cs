using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

// пет пати треба да се убива за да умре.
namespace FinalGameProject
{
    public class Vector
    {
        public Bitmap CurrentImage;
        public int X;
        public int Y;
        public bool IsKilled;
        public int WIDTH = Properties.Resources.VECTOR1.Width;
        public int counterImages;

        public Vector()
        {
            X = MainForm.WIDTH ;
            Y = 50;
            IsKilled = false;
            counterImages = 0;
            UpdateCurrentImage();
        }

        public void updatePosition(){
            X -= 5;
        }
        public void DrawVector(Graphics g) {

            g.DrawImage(CurrentImage,X,Y);
        }

        public void UpdateCurrentImage() {

            if (++counterImages == 4 )
            {
                counterImages = 1;
            }

            CurrentImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("VECTOR" + counterImages);
        }

        public bool VectorAttacked(Injection inj) {


            if (MainForm.VisibleBullet)
            {
                if (inj.DirectionInjection == Direction.Right)
                {
                    if (inj.X + inj.CurrentInjectionBmp.Width >= X + 50 && inj.Y >= Y && inj.Y <= Y + CurrentImage.Height)
                    {
                        inj.alreadyKilledSomething = true;
                        IsKilled = true;

                    }
                }
                else
                {
                    if (inj.X <= X + CurrentImage.Width - 50 && inj.Y >= Y && inj.Y <= Y + CurrentImage.Height)
                    {
                        inj.alreadyKilledSomething = true;
                        IsKilled = true;
                    }
                }
            }

            return IsKilled;
        }
    }
}
