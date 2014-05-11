using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace FinalGameProject
{
    public enum TypeItem { 
        Coin,
        Pistol,
        Time,
        Bananas
    };
    public class CollectingItem
    {
        public TypeItem Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int indexImage { get; set; }
        public Bitmap CurrentImage { get; set; }
        public List<Bitmap> Images { get; set; }
        public bool IsCollected { get; set; }
     
        public static int CounterCoins = 0;
        public bool IsPassed { get; set; }
        public static int CounterBananas = 0;

        public CollectingItem(TypeItem Type)
        {
            this.Type = Type;
            Images = new List<Bitmap>();
            indexImage = 0;
            IsCollected = false;
            IsPassed = false;

            switch (Type)
            {
                case TypeItem.Coin:
                    {

                        Images.Clear();
                        Images.Add(Properties.Resources.coin1);
                        Images.Add(Properties.Resources.coin2);
                        Images.Add(Properties.Resources.coin3);
                        Images.Add(Properties.Resources.coin4);
                        Images.Add(Properties.Resources.coin5);
                        Images.Add(Properties.Resources.coin6);
                        Images.Add(Properties.Resources.coin7);
                        Images.Add(Properties.Resources.coin8);
                        CurrentImage = Images[indexImage];


                    }
                    break;
                case TypeItem.Bananas:
                    {

                        Images.Clear();
                        Images.Add(Properties.Resources.banani);
                        CurrentImage = Images[0];
                    }
                    break;
                default:
                    break;
            }


            
        }

        /// <summary>
        /// функција која ја апдејтира позицијата на паричките, бананите итн.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void UpdatePosition(int x, int y)
        {
        
            switch (MainForm.gamemode)
            {
                case GameMode.Easy: { Y = 300; }
                    break;
                case GameMode.Medium: { Y = 150; }
                    break;
                case GameMode.Hard: { Y = 300; }
                    break;
                default:
                    break;
            }
            if (Type == TypeItem.Coin)
            {
                X = x * 300 + (++CounterCoins) * 70;
                Y -= y * 30;
            }
            if (Type == TypeItem.Bananas)
            {
                CounterBananas += 2;
                X = x * 300 + (CounterBananas) * 50;
                Y = 250;
                Y -= y * 30;
            }
        }

        /// <summary>
        /// ослободи ги ресурсите на битмапите по изминување на пропуштените парички.
        /// </summary>
        public void DisposeAfterRemoval() {

            for (int i = 0; i < Images.Count; i++)
            {
                Images[i].Dispose();
            }
        }

    }
}
