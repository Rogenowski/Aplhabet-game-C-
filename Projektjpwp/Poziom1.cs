using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Projektjpwp
{
    public partial class Poziom1 : Form
    {

        static public Point firstPoint = new Point();
        private Stopwatch stopWatch;
        int b=0;
        static public string wynik1;
        int liczba = 5;

        public Point A = new Point(45, 468);
        public Point B = new Point(125, 468);
        public Point C = new Point(205, 468);               
        public Point D = new Point(285, 468);
        public Point E = new Point(365, 468);
        System.Windows.Forms.Label[] tablica = new System.Windows.Forms.Label[5];

        public Poziom1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;          
            tablica[0] = label9;         
            tablica[1] = label10;    
            tablica[2] = label11;
            tablica[3] = label12;
            tablica[4] = label13;
            for(int i=0; i<=4; i++)
            {
                move(tablica[i]);    
            }           
        }
        /// <summary>
        /// Funkcja generująca losowe wspołrzedne literom
        /// </summary>
        public static void losowanie(int liczba, System.Windows.Forms.Label[] tablica)
        {
            int[] a = new int[liczba];
            int[] b = new int[liczba];
            Random x = new Random();
            for (int i = 0; i < liczba; i++)
            {
               
                  
                  a[i] = x.Next(0,520);                            
                  b[i] = x.Next(0, 320);                
                  tablica[i].Location = new Point(a[i], b[i]);
            }  
        }
        private void Poziom1_Load(object sender, EventArgs e)
        {

            stopWatch = new Stopwatch();
            stopWatch.Start();
            losowanie(liczba, tablica);
            label2.Parent = pictureBox1;
            stoper.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            stoper.BackColor = System.Drawing.Color.Transparent;
        }
        /// <summary>
        /// funkcja do poruszania literami za pomocą myszki
        /// </summary>
        static public void move(Label a)              
        {
            a.MouseDown += (ss, ee) =>
            {
                if (ee.Button == MouseButtons.Left)
                {
                    firstPoint = Control.MousePosition;           
                }
            };
            a.MouseMove += (ss, ee) =>
            {
                if (ee.Button == MouseButtons.Left)
                {
                    Point temp = Control.MousePosition;
                    Point res = new Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);
                    a.Location = new Point(a.Location.X - res.X, a.Location.Y - res.Y);
                    firstPoint = temp;
                    /// <summary>
                    /// sprawdzanie czy użytkownik nie przenosi liter poza obszar gry w osi x
                    /// </summary>
                    if (a.Location.X < 0 || a.Location.X > 800)                                 
                    {
                        a.Location = new Point(a.Location.X<0 ? 0 : 800, a.Location.Y);              
                    }
                    /// <summary>
                    /// sprawdzanie czy użytkownik nie przenosi liter poza obszar gry w osi y
                    /// </summary>
                    if (a.Location.Y < 0 || a.Location.Y > 600)
                    {
                        a.Location = new Point(a.Location.X, a.Location.Y < 0 ? 0 : 600 );
                    }

                }
            };
        }
        /// <summary>
        /// funkcja minutnika odliczającego w dół
        /// </summary>
        private string time()          
        {
            int m = 1;
            int s = 59;
            int mil = 999;
            string a;
            m -= stopWatch.Elapsed.Minutes;
            s -= stopWatch.Elapsed.Seconds;
            mil -= stopWatch.Elapsed.Milliseconds;
            a = string.Format("{0}:{1}.{2}", m, s, mil);
            /// <summary>
            /// sprawdzenie czy czas minął
            /// </summary>
            if ((m<=0)&&(s<=-1))
            {
                b = 1;               
                stopWatch.Stop(); 
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "lose.wav";
                myPlayer.Play();
                MessageBox.Show("Przegrywasz w 1 poziomie, wrócisz do menu", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 gameWindow = new Form1();
                this.Visible = false;
                gameWindow.Show();              
            }           
            return a;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /// <summary>
            /// dla b=0 do labela przypisawana jest wartość aktualnie minionego czasu
            /// </summary>
            if (b == 0)
            {
                string a = time();
                this.stoper.Text = a;
            }
            /// <summary>
            /// dla b=1 do labela przypisane jest 00:00:00, ponieważ w czasie przesyłu aktualnego czasu do labela występuje malutki delay przez co na liczniku widniałoby kilka milisekund
            /// </summary>
            else if (b == 1)
            {
                this.stoper.Text = "00:00:00";
            }
        }
        /// <summary>
        /// funkcja sprawdzania poprawności 
        /// </summary>
        public void sprawdz(Label a)
        {
            /// <summary>
            /// warunek sprawdzający poprawność ułożenia liter
            /// </summary>
            stopWatch.Stop();

            if ((Math.Abs(label9.Location.X - A.X) < 15 && Math.Abs(label9.Location.Y - A.Y) < 15) &&         
                (Math.Abs(label10.Location.X - B.X) < 15 && Math.Abs(label10.Location.Y - B.Y) < 15) &&
                (Math.Abs(label11.Location.X - C.X) < 15 && Math.Abs(label11.Location.Y - C.Y) < 15) &&
                (Math.Abs(label12.Location.X - D.X) < 15 && Math.Abs(label12.Location.Y - D.Y) < 15) &&
                (Math.Abs(label13.Location.X - E.X) < 15 && Math.Abs(label13.Location.Y - E.Y) < 15))
            {
                stopWatch.Stop();
                /// <summary>
                /// przypisanie do wynik czasu jaki był potrzebny do przejścia poziomu
                /// </summary>
                wynik1 = string.Format("{0}:{1}.{2}", stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "win.wav";
                myPlayer.Play();
                MessageBox.Show("Wygrywasz, czas gry: "+ wynik1, "Wygrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Poziom2 gameWindow = new Poziom2();
                this.Visible = false;
                gameWindow.Show();
            }
            else
            {
                stopWatch.Stop();
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "lose.wav";
                myPlayer.Play();
                MessageBox.Show("Przegrywasz w 1 poziomie, wrócisz do menu", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 gameWindow = new Form1();
                this.Visible = false;
                gameWindow.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            sprawdz(label7);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            Form1 gameWindow = new Form1();
            this.Visible = false;
            gameWindow.Show();
        }
        private void Poziom1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
