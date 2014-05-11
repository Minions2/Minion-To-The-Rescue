using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Media;

namespace FinalGameProject
{
    public class CollectingItems : IDisposable
    {
        public List<CollectingItem> Items { get; set; }
        public TypeItem Type { get; set; }
        public int NumberOfItems { get; set; }
        public int CounterGroupsX { get; set; }
        public int CounterGroupsY { get; set; }



        public CollectingItems(int NumberOfItems, TypeItem Type)
        {

            this.NumberOfItems = NumberOfItems;
            this.Type = Type;
            Items = new List<CollectingItem>();
            for (int i = 0; i < NumberOfItems; i++)
            {
                Items.Add(new CollectingItem(Type));
            }

            CounterGroupsX = 1;
            CounterGroupsY = 1;

            if (Type == TypeItem.Coin)
            {
                // za da se pojavat povekje delcinja so parichki
                for (int i = 0; i < NumberOfItems; i++)
                {
                    if (CollectingItem.CounterCoins % 5 == 0) { CounterGroupsX++; }
                    if (CollectingItem.CounterCoins % 5 == 0) { CounterGroupsY++; }
                    if (CollectingItem.CounterCoins % 15 == 0) { CounterGroupsX -= 2; }
                    Items.ElementAt(i).UpdatePosition(CounterGroupsX, CounterGroupsY % 2);

                }
            }

            if (Type == TypeItem.Bananas)
            {
                CounterGroupsY = 2;
                for (int i = 0; i < NumberOfItems; i++)
                {
                    if (CollectingItem.CounterBananas % 2 == 0) { CounterGroupsX++; }
                    Items.ElementAt(i).UpdatePosition(CounterGroupsX, CounterGroupsY);
                }
            }
        }

        /// <summary>
        /// ги исцртува сите елементи од ист тип (парички, пиштоли).
        /// </summary>
        /// <param name="g"></param>
        public void Draw(Graphics g) {
            for (int i = 0; i < Items.Count; i++)
            {
                g.DrawImage(Items.ElementAt(i).CurrentImage, Items.ElementAt(i).X, Items.ElementAt(i).Y, 30, 30);
                             
            }
        }

        /// <summary>
        /// ги поместува заедно со позадината
        /// </summary>
        /// <param name="Direction"></param>
        public void Move(string Direction) {


            for (int i = 0; i < Items.Count; i++)
            {
                if (Direction.CompareTo("RIGHT") == 0)
                {
                    Items.ElementAt(i).X -= 5;
                }
                else if (Direction.CompareTo("LEFT") == 0) 
                
                {
                    Items.ElementAt(i).X += 5;
                   
                }
            }

            // дали дошол крај на левелот, ако крајно поставените парички дојдат на позиција во формата.
            if (Items.ElementAt(Items.Count - 1).X <= MainForm.WIDTH - 100)
            {
                MainForm.endOfLevel = true;
            }
        }

        /// <summary>
        /// ја апдејтира моменталната слика од анимацијата.
        /// </summary>
        public void UpdateImage() {

            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].indexImage += 1;
                Items[i].CurrentImage = Items[i].Images[Items[i].indexImage % Items[i].Images.Count];
            }
        }



        SoundPlayer coins = new SoundPlayer(Properties.Resources.coins);
        /// <summary>
        /// проверува дали некое од коинс-от е собран од страна на играчот.
        /// </summary>
        public void IsCollected(Character character)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                // ili x,y ili x + 1/4, y ili x + 3/4, y ili x + 1, y + 1 
                if (((character.CurrentCharacterImage.Width + character.X - 20 >= Items[i].X && character.CurrentCharacterImage.Width + character.X - 20 <= Items[i].X + Items[i].CurrentImage.Width))
                     && character.Y <= Items[i].Y + Items[i].CurrentImage.Height)
                {
                    Items[i].IsCollected = true;
                    if (Type == TypeItem.Coin)
                    {
                        coins.Play();
                        MainForm.CollectedCoins++;
                        MainForm.CollectedCoinsPlusLife++;
                    }

                    if (Type == TypeItem.Bananas)
                    {
                        MainForm.CollectedBananas++;
                    }
                }


            }

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                if (Items[i].IsCollected)
                {
                    Items[i].DisposeAfterRemoval();
                    Items.Remove(Items[i]);
                    GC.Collect();
                }
            }
        }


        /// <summary>
        /// оние што не се слободни избриши ги.
        /// </summary>
        public void IsntCollectedPassed() {
            for (int i = 0; i < Items.Count; i++)
            {
                if (Items[i].X < -100) {
                    Items[i].IsPassed = true;
                  
                }
            }

            for (int i = Items.Count - 1; i >= 0; i--)
            {
                if (Items[i].IsPassed) {

                    Items[i].DisposeAfterRemoval();
                    Items.Remove(Items[i]);
                }

        
            }

         
        }

        public void Dispose()
        {
            if (Type == TypeItem.Coin)
            {
                for (int i = Items.Count - 1; i >= 0; i--)
                {
                    Items.Remove(Items[i]);
                    Items[i].DisposeAfterRemoval();
                }
            }
        }
    }

}
