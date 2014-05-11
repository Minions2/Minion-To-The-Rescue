using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlServerCe;
using System.Media;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace FinalGameProject
{
    public enum GameMode { 
        Easy = 5,
        Medium = 25,
        Hard = 35
    };

    public partial class MainForm : Form
    {
        //formata
        private Point StartPoint = new Point(0, 0);

        //database
        SqlCeConnection con;
        SqlCeCommand cmd = new SqlCeCommand();
        SqlCeDataReader rdr;
     

        // background initialization
        public Background Bckgr { get; set; }
        public Bitmap BckgrBitmap { get; set; }
        
        // character initialization 
        public Character Character { get; set; }
        // moving
        public int indexR { get; set; }
        public int indexL { get; set; }
      

        public bool MoveBackground { get; set; }
        public bool GoRight { get; set; }
        public bool GoLeft { get; set; }
        public bool Jump { get; set; }
        public static int NORMALIZATION;
        public int MaxForce = 30;
        public int CurrentForce { get; set; }


        public Injection BulletInjection { get; set; }
        public bool TurnedRight { get; set; }
        public bool TurnedLeft { get; set; }
        
        // shooting
        public static bool VisibleBullet { get; set; }
        public int counterShooting { get; set; }

        // Enemies
        public EvilMinions MyEnemies { get; set; }
        public int counterMove { get; set; }
        public int counterKilling { get; set; }
        public int counterAddEnemy { get; set; }
        public static int CounterKilledEvilMinions;

        // ako igrachot saka da se vrati do nazad da ne mozhe da prejde preku leva granica:
        public bool ComesBackToStart { get; set; }
        // so vrtenje na ciklus na pozadinata ima fleg da ne mozhe da se vrati povekje od 200 px nazad;
        public bool CanComeBack { get; set; }
        public int counterComeBack { get; set; }

        public static GameMode gamemode { get; set; }
        public static readonly int FixedPoint = 500; 

        // Collecting Items
        public CollectingItems Coins { get; set; }
        public CollectingItems Bananas { get; set; }

        // labels and decorations

        public static int CollectedBananas;
        public static int CollectedCoins { get; set; }
        public bool FirstIteration { get; set; }
        public static int Lifes { get; set; }
        public static int CollectedCoinsPlusLife { get; set; }
        public int JumpC;
        public bool CharLosesLife;
       
        // музика
        SoundPlayer jump = new SoundPlayer(Properties.Resources.space);
        SoundPlayer shoot = new SoundPlayer(Properties.Resources.shoot);
        SoundPlayer coins = new SoundPlayer(Properties.Resources.coins);
        public bool jumpFinishMusic;


        // фонтови 
        Font font = new Font("Showcard Gothic", 30, FontStyle.Bold);
        Brush brush;
        Point point = new Point(0, 0);
        Point point2 = new Point(0, 50);

        // MDI connected:
        LevelChooserForm LCForm;

        public static readonly int WIDTH = 1052;
        public static readonly int HEIGHT = 589;

        public int CounterLosingEnergy;
        public static bool EndEasy;
        public static bool EndMedium;
        public static bool EndHard;


        public static bool endOfLevel;
        public bool firstEnter;
        public bool firstEnterPause;

        public int SpeedOfGame;
        public int CounterVector;
        public Vector VectorVillian;
        public int CounterVectorMoving;
        public int CounterVectorKilled;
        public bool VectorCanShowUp;

        public MainForm(LevelChooserForm LCForm, GameMode GameMode)
        {
            InitializeComponent();

            con = new SqlCeConnection(@"Data Source=App_Data\Database.sdf");
            cmd.Connection = con;

            Bckgr = new Background();

            // карактер иницијализација
            Character = new Character();

            // куршум (банани, инекции)
            BulletInjection = new Injection();

            VectorCanShowUp = true;
            
            TmrMoving.Enabled = false;
            this.LCForm = LCForm;
            gamemode = GameMode;

            brush = new SolidBrush(Color.LightYellow);

            
                VectorVillian = new Vector();
            

            this.DoubleBuffered = true;
            NewGame();
        }


        /// <summary>
        /// функција која почнува нова игра.
        /// </summary>
        public void NewGame() {

            Application.DoEvents(); // MISLAM NE MORA.
           // TmrPauseBetweenGames.Stop();
            // позадина
            endOfLevel = false;
            Character.UpdateInitialPosition();

            Bckgr = new Background();
            Bckgr.ChooseBackground(); // ZA KOJ LEVEL POZADINA.
            BckgrBitmap = Bckgr.GenerateBackground();
            MoveBackground = false;

            // карактер (играч)
            indexR = 0;
            indexL = 0;

            // куршум (банани, инекции)
            VisibleBullet = false;
            TurnedRight = true;
            counterShooting = 0;


            CollectedCoins = 0; // ne e povrzano so high-scorot tuku samo na edna igra.
            CollectedCoinsPlusLife = 0;
            JumpC = 0;
            CollectedBananas = 0;
            CollectingItem.CounterBananas = 0;
            CollectingItem.CounterCoins = 0;

            // непријатели:
            MyEnemies = new EvilMinions(gamemode);
            counterMove = 0;
            counterKilling = 0; // за тајмер.
            CanComeBack = true;
            counterComeBack = 0;
            counterAddEnemy = 0;
            CounterKilledEvilMinions = 0;

            // Collecting Items
            Coins = new CollectingItems(100, TypeItem.Coin);
            Bananas = new CollectingItems(30, TypeItem.Bananas);

            // Lifes
            Lifes = 3; 

            switch (gamemode)
            {
                case GameMode.Easy: { NORMALIZATION = 50; SpeedOfGame = 5; }
                    break;
                case GameMode.Medium: { NORMALIZATION = 190; SpeedOfGame = 3;  }
                    break;
                case GameMode.Hard: { NORMALIZATION = 50; SpeedOfGame = 2; TmrMoving.Interval = 10; lblVector.Visible = true; }
                    break;
                default:
                    break;
            }

            endOfLevel = false;
            TmrMoving.Enabled = true;
            TmrMoving.Start();
        }

        /// <summary>
        /// исцртување на главната панела (позадина, карактер, по потреба куршуми, непријатели, скорови ... итн)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
           

                e.Graphics.DrawImage(BckgrBitmap, Bckgr.startingX, 0, BckgrBitmap.Width, BckgrBitmap.Height);
                e.Graphics.DrawImage(Character.CurrentCharacterImage, Character.X, Character.Y);
                if (VisibleBullet) { BulletInjection.DrawInjection(e.Graphics); }
                MyEnemies.DrawEvilMinions(e.Graphics);
                Coins.Draw(e.Graphics);
                Bananas.Draw(e.Graphics);
                e.Graphics.DrawString("COINS: " + CollectedCoins.ToString(), font, brush, point);
                //e.Graphics.DrawString("FOOD: " + CollectedBananas.ToString(), font, brush, point2);
                this.DrawLifeAndKilledEM(e.Graphics);

                if (!VectorVillian.IsKilled && gamemode == GameMode.Hard)
                {
                    VectorVillian.DrawVector(e.Graphics);
                }

            
        }





        /// <summary>
        /// ги исцртува преостанатите животи на играчот.
        /// </summary>
        /// <param name="g"></param>
        public void DrawLifeAndKilledEM(Graphics g) {

            g.DrawString(Lifes.ToString() + "X" , font, brush, 880, 10);
            g.DrawImage(Properties.Resources.life, 950, -20);
            g.DrawImage(Properties.Resources.EMIcon, 10, 50);
            lblEMKilled.Text = CounterKilledEvilMinions.ToString();
        }

        /// <summary>
        /// функција која проверува дали играчот при стартување на играта стасува до
        /// фиксната позиција каде започнува илузијата.
        /// </summary>
        public void checkIfOnPosition()
        {
            if (Character.X == FixedPoint && !ComesBackToStart)
            {
                MoveBackground = true;
            }     
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            Invalidate();
        }


     

        /// <summary>
        /// функција која проверува дали куршумот дошол до одредена позиција, за да може да пука повторно играчот, 
        /// исто така проверува и дали убил некое суштество за да може да исчезне.
        /// </summary>
        public void CheckForReshooting(){

            if (BulletInjection.DirectionInjection == Direction.Right)
            {
                if (BulletInjection.X >= this.Width) { VisibleBullet = false; }    
            }

            if (BulletInjection.DirectionInjection == Direction.Left)
            {
                if (BulletInjection.X + 50 <= 0) { VisibleBullet = false; }
            }
        }

        /// <summary>
        /// го поместува играчот во десно.
        /// </summary>
        public void moveRight() {


            Character.UpdateCharacterImage();
            if (!endOfLevel)
            {
                if (!MoveBackground)
                {
                    if (Character.X <= FixedPoint)
                        Character.X += 5;
                    if (Character.X >= FixedPoint)
                        ComesBackToStart = false;

                }
                else
                {

                    Bckgr.startingX -= 5;
                    Coins.Move("RIGHT");
                    Bananas.Move("RIGHT");
                }
            }
            else {

                if (Character.X <= this.Width - 60) 
                Character.X += 5;
            }
        }

        /// <summary>
        /// го поместува играчот во лево.
        /// </summary>
        public void moveLeft()
        {

            Character.UpdateCharacterImage();
   if(!endOfLevel){
       if (!MoveBackground)
       {
           if (Character.X > 0)
               Character.X -= 5;

       }
       else
       {
           if (!CanComeBack)
           {

               if (counterComeBack <= 100)
               {
                   counterComeBack++;
                   ComesBackToStart = true;
                   MoveBackground = false;
               }
               else
               {
                   Bckgr.startingX += 5;
                   Coins.Move("LEFT");
                   Bananas.Move("LEFT");
               }
           }
           else
           {
               ComesBackToStart = true;
               MoveBackground = false;
           }

       }
   }
   else
   {
       if(Character.X >= 30)
        Character.X -= 5;
   }
        }



        /// <summary>
        /// тајмерот проверува дали каракатерот дошол до фиксната точка, ако да
        /// го фиксира и притоа ја придвижува позадината согласно кон кој правец
        /// се движи играчот како би се створила илузија на движење на позадината.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TmrMoving_Tick(object sender, EventArgs e)
        {
            
               
                MovingTimer();
               

            if (counterShooting++ == 2)
            {

                ShootingTimer();
                counterShooting = 0;
                // + анимација на парички (се совпаѓа), мењање на моментална слика.
                Coins.UpdateImage();
                Coins.IsCollected(Character);
                Coins.IsntCollectedPassed();

                Bananas.IsCollected(Character);
                Bananas.IsntCollectedPassed();
            }
            
            if (counterKilling++ == 1) {
                counterKilling = 0;
                if (VisibleBullet)
                {
                    VisibleBullet = MyEnemies.IsEnemyKilled(BulletInjection);
              
                }
                CharLosesLife = MyEnemies.KillingCharacter(Character);
            }

            if (!endOfLevel)
            {
                if (counterMove++ == SpeedOfGame)
                {
                    counterMove = 0;
                    MyEnemies.UpdateEvilMinions();
                }

                if (counterAddEnemy++ == 60)
                {
                    counterAddEnemy = 0;
                    MyEnemies.AddEnemy();
                }
            }
            
            if (Character.Hit >= 3)
            {
                Character.Killed = true;
                this.TmrMoving.Stop();
                GameOver gm = new GameOver();
                gm.ShowDialog();
                
            }

            if (CollectedCoinsPlusLife == 50)
            {
                CollectedCoinsPlusLife = 0;
                Lifes++;
            }

            if (CharLosesLife)
            {
                PlayAgain();
                CharLosesLife = false;
            }

            if (endOfLevel)
            {
                TmrMoving.Stop();
                    pnlWinning.Visible = true;
                    lblCongrats.Visible = true;
                    lblEndWinning.Visible = true;
                    lblNextLevel.Visible = true;
                    this.DrawSavedGirl(pnlWinning.CreateGraphics());
                    EndOfGame();
            }

            if ((++CounterVector == 200) )
            {
                CounterVector = 0;
                if ((gamemode == GameMode.Hard) && (VectorCanShowUp))
                {
                    VectorVillian = new Vector();
                    VectorCanShowUp = false;
                }
               
            }

            if (++CounterVectorMoving == 2)
            {
                CounterVectorMoving = 0;

                if (gamemode == GameMode.Hard && !VectorCanShowUp)
                {
                    VectorVillian.updatePosition();

                    if (VectorVillian.VectorAttacked(BulletInjection))
                    {
                        CounterVectorKilled++;
                        lblVector.Text = "VECTOR DEFEATED " + CounterVectorKilled.ToString() + " TIMES !!";
                        VectorCanShowUp = true;
                    } 
                }
            }

            if (gamemode == GameMode.Hard)
            {
                if (VectorVillian.X + VectorVillian.CurrentImage.Width < 0)
                {
                    VectorCanShowUp = true;
                }
            }

            

            Invalidate();
        }

        /// <summary>
        /// функција која се повикува кога играта ќе заврши. (при губење)
        /// </summary>
        public void GameOver() { 
            // panelata so vector i game over :)
        
        }
        public void PlayAgain()
        {
            jump.Play();
            Character.X = 50;
            Character.MovingRight = true;
            Character.MovingLeft = false;
            TurnedRight = true;
            TurnedLeft = false;
            Character.UpdateCharacterImage();
            MoveBackground = false;
            CanComeBack = true;

            if (gamemode == GameMode.Easy)
            {
                Character.Y = 200;
            }
            else
            {
                Character.Y = 100;
            }
            
            MyEnemies.PlayAgain();
        }

        /// <summary>
        /// во тајмерот се проверува дали каракатерот дошол до фиксната точка, ако да
        /// го фиксира и притоа ја придвижува позадината согласно кон кој правец
        /// се движи играчот како би се створила илузија на движење на позадината. (20ms)
        /// </summary>
        public void MovingTimer() {

            if (GoRight) { moveRight(); if (TurnedLeft) { TurnedLeft = false; TurnedRight = true; } else TurnedRight = true; }

            if (GoLeft) { moveLeft(); if (TurnedRight) { TurnedRight = false; TurnedLeft = true; } else TurnedLeft = true; }

            if (Jump == true || JumpC == 2) { Character.Y -= CurrentForce; CurrentForce -= 1; }

            // ако дојде до дното на екранот.
            if (Character.Y + Character.CurrentCharacterImage.Height >= this.Height - NORMALIZATION)
            {
                Character.Y = this.Height - Character.CurrentCharacterImage.Height - NORMALIZATION;
                Jump = false;
                JumpC = 0;
            }
            else
            {
                // паѓа 
                Character.Y += 10;
            }

            checkBackgroundLength();
            checkIfOnPosition();

        }

        /// <summary>
        /// во тајмерот се проверува дали куршумот сеуште е видлив на екран,
        /// при тоа го придвижува зависно од насоката + се апдејтира насоката на куршумот во случај
        /// играчот во меѓувреме да се сврти + се проверува дали (ако е убиен непријател или куршумот е 
        /// излезен од екран играчот може повторно да пука. (30ms)
        /// </summary>
        public void ShootingTimer() {

            Point charPoint = new Point(Character.X, Character.Y);
            Size charSize = new Size(Character.CurrentCharacterImage.Width, Character.CurrentCharacterImage.Height);

            if (VisibleBullet)
            {
                switch (BulletInjection.DirectionInjection)
                {
                    case Direction.Right: {
                        BulletInjection.X += 2;
                        charPoint.X = BulletInjection.X;
                        BulletInjection.UpdatePosition(charPoint, charSize);
                    }
                        break;
                    case Direction.Left: {

                        BulletInjection.X -= 2;
                        charPoint.X = BulletInjection.X;
                        BulletInjection.UpdatePosition(charPoint, charSize);
                    }
                        break;
                  
                    default:
                        break;
                }
              

            }
            else
            {
                if (TurnedRight) BulletInjection.UpdateDirection(Direction.Right);
                if (TurnedLeft) BulletInjection.UpdateDirection(Direction.Left);

                BulletInjection.UpdatePosition(charPoint, charSize);
            }

            CheckForReshooting();
        }


        /// <summary>
        /// наместо KeyDown поради имплементација на MDI
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Right: { GoRight = true; Character.MovingRight = true; Character.MovingLeft = false;  return true; }
                case Keys.Left: { GoLeft = true; Character.MovingLeft = true; Character.MovingRight = false;   return true; }
                case Keys.Space:
                    {

                        JumpC++;

                        if (!Jump || JumpC == 2)
                        {
                            Jump = true;
                            CurrentForce = MaxForce;
                        }

                        return true;
                    }
                case Keys.Q:
                    {
                        if (!VisibleBullet)
                        {
                            shoot.Play();    
                        }
                        
                        VisibleBullet = true;
                    }
                    return true;

                case Keys.Up: {

                    VisibleBullet = true;
                    return true;
                }
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }



        /// <summary>
        /// настан кој се јавува при ослободување на копчињата.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Right): GoRight = false;
                    break;
                case (Keys.Left): GoLeft = false;
                    break;
                
                default:
                    break;
            }
        }      
        
        /// <summary>
        /// апдејтирање и циклус на позадината.
        /// </summary>
        public void checkBackgroundLength() {

            if (Bckgr.startingX + BckgrBitmap.Width <= this.Width + 50)
            {
                Bckgr.startingX = Bckgr.startingX + Bckgr.Images.ElementAt(0).Width;
            
                CanComeBack = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (LCForm != null)
            {
                LCForm.Close();    
            }
            
        }

       
   
        private void lblPause_MouseEnter(object sender, EventArgs e)
        {
            lblPause.ForeColor = Color.White;
        }

        private void lblPause_MouseLeave(object sender, EventArgs e){
            lblPause.ForeColor = Color.Tomato;
        }

        private void lblPause_Click(object sender, EventArgs e)
        {
            TmrMoving.Stop();
            PauseForm pf = new PauseForm(this);
            pf.ShowDialog();
            if (pf.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                TmrMoving.Start();
            }
        }



        public void DrawSavedGirl(Graphics g) {


            switch (gamemode)
            {
                case GameMode.Easy: {

                    g.DrawImage(Properties.Resources.MargoSaved, this.Width / 2, this.Height / 2);
                    EndEasy = true;
                   
                }
                    break;
                case GameMode.Medium: {

                    g.DrawImage(Properties.Resources.EdithSaved, this.Width / 2, this.Height / 2);
                    EndMedium = true;
                }
                    break;
                case GameMode.Hard: {

                    g.DrawImage(Properties.Resources.AgnesSaved, this.Width / 2, this.Height / 2);
                    EndHard = true;
                }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// ослободување од меморија за сите потрошени објекти
        /// </summary>
        public void EndOfGame() {


            MyEnemies.Dispose();
            string query = "SELECT * FROM PlayerTable WHERE username = '" + LogInForm.Username + "'";
            cmd = new SqlCeCommand(query, con);

            con.Open();
                rdr = cmd.ExecuteReader();
                rdr.Read();

            switch (gamemode)
            {
                case GameMode.Easy:
                    int s1 = Convert.ToInt16(rdr[3]);
                    int score1 = CollectedCoins + CollectedBananas * 10 + CounterKilledEvilMinions * 20;
                    if (score1 > s1)
                    {
                        cmd.CommandText = "UPDATE PlayerTable Set scoreL1=@scoreL1 where username=@username";
                        cmd.Parameters.AddWithValue("username", LogInForm.Username);
                        cmd.Parameters.AddWithValue("@scoreL1", score1);
                        cmd.ExecuteNonQuery();
                    }
                    break;

                case GameMode.Medium:
                    int s2 = Convert.ToInt16(rdr[4]);
                    int score2 = CollectedCoins + CollectedBananas * 10 + CounterKilledEvilMinions * 20;
                    if (score2 > s2)
                    {
                        cmd.CommandText = "UPDATE PlayerTable Set scoreL2=@scoreL2 where username=@username";
                        cmd.Parameters.AddWithValue("username", LogInForm.Username);
                        cmd.Parameters.AddWithValue("@scoreL2", score2);
                        cmd.ExecuteNonQuery();
                    }
                    break;

                case GameMode.Hard:
                  int s3 = Convert.ToInt16(rdr[4]);
                    int score3 = CollectedCoins + CollectedBananas * 10 + CounterKilledEvilMinions * 20+CounterVectorKilled*50;
                    if (score3 > s3)
                    {
                        cmd.CommandText = "UPDATE PlayerTable Set scoreL3=@scoreL3 where username=@username";
                        cmd.Parameters.AddWithValue("username", LogInForm.Username);
                        cmd.Parameters.AddWithValue("@scoreL3", score3);
                        cmd.ExecuteNonQuery();
                    }
                    break;


                default:
                    break;
            }
            con.Close();

        }

        private void lblEndWinning_MouseEnter(object sender, EventArgs e)
        {
            lblEndWinning.ForeColor = Color.White;
        }

        private void lblEndWinning_MouseLeave(object sender, EventArgs e)
        {
            lblEndWinning.ForeColor = Color.Tomato;
        }

        private void lblNextLevel_Click(object sender, EventArgs e)
        {
            switch (gamemode)
            {
                case GameMode.Easy: {
                    LevelChooserForm LCF = new LevelChooserForm(null, this);
                    LCF.MdiParent = this.MdiParent;
                    LCF.Show();
                    LCF.Location = new Point(0, 0);
                }
                    break;
                case GameMode.Medium: {

                    LevelChooserForm LCF = new LevelChooserForm(null, this);
                    LCF.MdiParent = this.MdiParent;
                    LCF.Show();
                    LCF.Location = new Point(0, 0);
                }
                    
                    break;
                case GameMode.Hard: { lblNextLevel.Enabled = false;  }
                    break;
                default:
                    break;
            }
        }

        


    }
}
