using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Drawing2D;
using System.Drawing;


namespace FinalGameProject
{
    public enum EvilCreatures { 
        FirstType = 1,  // најлесен (го убива еден куршум (банана, што и да биде).
        SecondType = 2    // потежок (го убиваат два куршума (-||-).
    }

    public class EvilMinion
    {

        public int IndexRight { get; set; }
        public int IndexLeft { get; set; }
        public Bitmap CurrentImage { get; set; }
        public bool IsKilled { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public static int PositionRIGHT = 1500 ; //  pozadi ekranot od desno.
        public Random Random { get; set; }
        public static int PositionLEFT = -100; // pred ekranot od levo.
        public bool FromRight { get; set; }
        public bool FromLeft { get; set; }
        public Random Random2 { get; set; }
        public bool HasKilledCharacter { get; set; }
        public GameMode GM;
        public Random random;
        public int IndexEndEvil;
        public EvilCreatures EvilType;

        /// <summary>
        /// конструктор.
        /// </summary>
        public EvilMinion(GameMode GM, EvilCreatures EvilType)
        {


            random = new Random();
            this.GM = GM;
            this.EvilType = EvilType;
            IndexRight = 0;
            IndexLeft = 0;
            IndexEndEvil = 0;
            Random = new Random();
            Random2 = new Random();
            placeEvilMinionsGM();
            HasKilledCharacter = false;
            UpdateCurrentImage();
            chooseY();
        }

        public void chooseY() {

            if ((GM == GameMode.Easy) || (GM == GameMode.Hard))
            {
                Y = 450;
            }
            else if ((GM == GameMode.Medium))
            {
                Y = 300;
            }
            
        }

        /// <summary>
        /// функција која се грижи за поставување на непријателите зависно од тоа за кој левел се работи.
        /// </summary>
        public void placeEvilMinionsGM()
        {

            int LR = Random.Next(2); // 0 за да дојде од лево и 1 за да дојде од десно на играчот.

            switch (GM)
            {
                case GameMode.Easy: {
                    int RandomXX = Random2.Next(PositionRIGHT, PositionRIGHT + 200);
                    PositionRIGHT += 300;
                    FromRight = true;
                    FromLeft = false;
                    X = RandomXX;
                }
                    break;
                case GameMode.Medium: {
                    if (LR == 0)
                    {

                        int RandomX = Random2.Next(Math.Abs(PositionLEFT), Math.Abs(PositionLEFT - 500));
                        RandomX = -RandomX;
                        FromLeft = true;
                        FromRight = false;
                        X = RandomX;
                    }
                    else if (LR == 1)
                    {
                        int RandomXX = Random2.Next(PositionRIGHT, PositionRIGHT + 200);
                        PositionRIGHT += 300;
                        FromRight = true;
                        FromLeft = false;
                        X = RandomXX;
                    }
                }
                    break;
                case GameMode.Hard: {

                    if (LR == 0)
                    {

                        int RandomX = Random2.Next(Math.Abs(PositionLEFT), Math.Abs(PositionLEFT - 500));
                        RandomX = -RandomX;
                        FromLeft = true;
                        FromRight = false;
                        X = RandomX;
                    }
                    else if (LR == 1)
                    {
                        int RandomXX = Random2.Next(PositionRIGHT, PositionRIGHT + 200);
                        PositionRIGHT += 300;
                        FromRight = true;
                        FromLeft = false;
                        X = RandomXX;
                    }
                }
                    break;
                default:
                    break;
            }
           
        }


        /// <summary>
        /// ја апдејтира моменталната секвенца (слика) која се покажува во анимацијата.
        /// </summary>
        public void UpdateCurrentImage()
        {
            if (EvilType == EvilCreatures.FirstType)
            {

                if (FromLeft)
                {
                    if (++IndexLeft == 6)
                    {
                        IndexLeft = 1;
                    }
                    if (CurrentImage != null)
                        CurrentImage.Dispose();
                    CurrentImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("EL" + IndexLeft);
                }
                else
                {

                    if (++IndexRight == 6)
                    {
                        IndexRight = 1;
                    }
                    if (CurrentImage != null)
                        CurrentImage.Dispose();
                    CurrentImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("ER" + IndexRight);
                }
            }
            else // POSLEDNOTO GOLEMO
            {
                if (++IndexEndEvil == 5)
                {
                    IndexEndEvil = 1;
                }

                if (CurrentImage != null)
                {
                    CurrentImage.Dispose();
                }
                CurrentImage = (Bitmap)Properties.Resources.ResourceManager.GetObject("EE" + IndexEndEvil);
            }
        }

        /// <summary>
        /// исцртување на Minion-от.
        /// </summary>
        /// <param name="g"></param>
        public void DrawEvilMinion(Graphics g)
        {
            g.DrawImage(CurrentImage, X, Y);
        }

        public bool HasKilled(Character character)
        {
            if (!HasKilledCharacter)
            {
                if (FromLeft)
                {
                    if ((X + CurrentImage.Width >= character.X + 15 && character.Y + character.CurrentCharacterImage.Height >= Y - 50) && this.HasKilledCharacter == false)
                    {
                        this.HasKilledCharacter = true;
                        character.Hit++;

                        if (MainForm.Lifes > 0)
                        {
                            MainForm.Lifes--;
                        }

                        return true;
                    }
                }
                else
                {
                    if ((X <= character.X + character.CurrentCharacterImage.Width - 35 && character.Y + character.CurrentCharacterImage.Height >= Y - 50) && this.HasKilledCharacter == false)
                    {
                        this.HasKilledCharacter = true;
                        character.Hit++;
                        if (MainForm.Lifes > 0)
                        {
                            MainForm.Lifes--;
                        }
                        return true;
                    }
                }
            }

            return false;

        }

    }
}
