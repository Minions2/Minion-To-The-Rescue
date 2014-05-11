using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FinalGameProject
{
    public class Background
    {
        /// <summary>
        /// листа од сликите за подвижната позадина.
        /// </summary>
        public List<Bitmap> Images { get; set; }
        public static int HEIGHT = 600;
        public int width { get; set; }
        public int startingX { get; set; }

        /// <summary>
        /// дифолт конструктор
        /// </summary>
        public Background()
        {
            Images = new List<Bitmap>();
            startingX = 0;
            width = 0;
        }

        /// <summary>
        /// одбирање на позадина во зависност од левелот на играта која се игра.
        /// </summary>
        public void ChooseBackground() {


            if (Images.Count != 0)
            {
                Images.Clear();
            }
            switch (MainForm.gamemode)
            {
                case GameMode.Easy:
                    {
                        Images.Add(Properties.Resources.MAIN_BACKGROUND);
                        Images.Add(Properties.Resources.MAIN_BACKGROUND);
                    }
                    break;
                case GameMode.Medium: {
                    Images.Add(Properties.Resources.saveEdithBCK);
                    Images.Add(Properties.Resources.savevEdithBCK2);
                    Images.Add(Properties.Resources.savevEdithBCK2);

                }
                    break;
                case GameMode.Hard: {
                    Images.Add(Properties.Resources.BackgroundAgnes);
                    Images.Add(Properties.Resources.BackgroundAgnes);

                }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// додавање на слика во позадината.
        /// </summary>
        /// <param name="bmp"></param>
        public void AddImage(Bitmap bmp){
            Images.Add(bmp);
        }


        public void RemoveImage() {
            Images.Remove(Images[0]);
        }

        /// <summary>
        /// ги комбинира битмапите во една голема битмапа
        /// </summary>
        /// <returns>ја враќа конечната позадината на играта</returns>
        public Bitmap GenerateBackground()
        {

            Bitmap finalBackground = null;
            for (int i = 0; i < Images.Count; i++)
            {
                width += Images.ElementAt(i).Width;
            }
            finalBackground = new Bitmap(width, HEIGHT);
            Graphics grp = Graphics.FromImage(finalBackground);
            int offset = 0; // поместување од една до друга слика во листата.
            foreach (Bitmap img in Images)
            {
                grp.DrawImage(img, offset, 0, img.Width, HEIGHT);
                offset += img.Width;
            }
            grp.Dispose();
            return finalBackground;
        }

    }
}
