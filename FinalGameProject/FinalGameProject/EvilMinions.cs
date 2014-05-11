using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace FinalGameProject
{
    public class EvilMinions : IDisposable
    {
         List<EvilMinion> Enemies;
         List<EvilMinion> KilledEnemiesReuse;
         public GameMode mode;
         Random Random1;
         Random Random2;

        /// <summary>
        /// конструктор
        /// </summary>
        /// <param name="mode"></param>
        public EvilMinions(GameMode mode)
        {
            this.mode = mode;
            Enemies = new List<EvilMinion>();
            KilledEnemiesReuse = new List<EvilMinion>();
            int numberOfMinions = (int)mode;
           
            Random1 = new Random();
            Random2 = new Random();
        }


        /// <summary>
        /// ги апдејтира сите манјони, апдејтирање на слика од анимации како и придвижување и плус додава уште еден minion(easy mode).
        /// </summary>
        public void UpdateEvilMinions() {

            for (int i = 0; i < Enemies.Count; i++)
            {
                Enemies.ElementAt(i).UpdateCurrentImage();

                if (Enemies.ElementAt(i).FromLeft)
                {
                    Enemies.ElementAt(i).X += 20; // придвижување ако непријателот доаѓа од лево.
                }
                else
                {
                    Enemies.ElementAt(i).X -= 20; // придвижување ако непријателот доаѓа од десно.
                }
                }
        }

        /// <summary>
        /// исцртување на сите манјонс (живи).
        /// </summary>
        /// <param name="g"></param>
        public void DrawEvilMinions(Graphics g) {

            for (int i = 0; i < Enemies.Count; i++)
            {
                if(!Enemies.ElementAt(i).IsKilled)
                Enemies.ElementAt(i).DrawEvilMinion(g);
            }
        }

        /// <summary>
        /// функција која проверува дали манјнонот е убиен и ако е тогаш го отстранува + го става во листата на убиени,
        /// враќа бул, ако е true, значи не е фатен непријателот и пиштолот останува видлив, во спротивно
        /// видливоста на пиштолот се губи.
        /// </summary>
        /// <param name="bullet"></param>
        public bool IsEnemyKilled(Injection bullet) {

            bool result = true;

            for (int i = 0; i < Enemies.Count; i++)
            {
                if (Enemies.ElementAt(i).FromRight)
                {
                    if (bullet.X + bullet.CurrentInjectionBmp.Width - 100 >= Enemies.ElementAt(i).X && bullet.Y >= Enemies.ElementAt(i).Y && bullet.Y <= (Enemies.ElementAt(i).Y + Enemies.ElementAt(i).CurrentImage.Height))
                    {
                        Enemies.ElementAt(i).IsKilled = true;
                        result = false;
                        break;
                    }
                }
                else {
                    if (bullet.X <= Enemies.ElementAt(i).X && bullet.Y >= Enemies.ElementAt(i).Y && bullet.Y <= (Enemies.ElementAt(i).Y + Enemies.ElementAt(i).CurrentImage.Height))
                    {
                        Enemies.ElementAt(i).IsKilled = true;
                        result = false;
                        break;
                    }
                }
            }

            // отстранување на убиени манјнони.
            for (int i = Enemies.Count - 1; i >= 0; i--)
            {
                if (Enemies.ElementAt(i).IsKilled)
                {
                    MainForm.CounterKilledEvilMinions++;
                    Enemies.ElementAt(i).CurrentImage.Dispose();
                    Enemies.Remove(Enemies.ElementAt(i));
    
                }
            
            }
            return result;
        }

        public void AddEnemy()
        {

         
                EvilMinion em = new EvilMinion(mode, EvilCreatures.FirstType);

                Enemies.Add(em);
            
  
 }


        public bool KillingCharacter(Character chara)
        {

            bool result = false;

            for (int i = 0; i < Enemies.Count; i++)
            {

                result = Enemies.ElementAt(i).HasKilled(chara);
                if (result) { break; }
            }

            return result;
        }

         /// <summary>
        /// ако играчот изгуби и треба повторно да игра, се стопира тајмерот се поставува играчот
        /// на почетната позиција и се повикува оваа функција за да се тргнат сите манјнони.
        /// </summary>
        /// <returns></returns>
        public void PlayAgain() {

   
            for (int i = 0; i < Enemies.Count; i++)
            {
                KilledEnemiesReuse.Add(Enemies.ElementAt(i));
            }

            Enemies.Clear();
            EvilMinion.PositionRIGHT = 1500;
           
        }

        public void Dispose()
        {
            Enemies.Clear();
            Enemies = null;
        }
    }
    }





