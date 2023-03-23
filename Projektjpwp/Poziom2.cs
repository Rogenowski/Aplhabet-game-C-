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
    public partial class Poziom2 : Form
    {
        public Point firstPoint = new Point();
        private Stopwatch stopWatch;
        int b = 0;
        static public string wynik2;
        int liczba = 6;
        public Point A = new Point(45, 468);
        public Point B = new Point(125, 468);
        public Point C = new Point(205, 468);
        public Point D = new Point(285, 468);
        public Point E = new Point(365, 468);
        public Point F = new Point(445, 468);
        System.Windows.Forms.Label[] tablica = new System.Windows.Forms.Label[6];
        public Poziom2()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
            tablica[0] = label9;
            tablica[1] = label10;
            tablica[2] = label11;
            tablica[3] = label12;
            tablica[4] = label13;
            tablica[5] = label14;
            for (int i = 0; i <= 5; i++)
            {
                Poziom1.move(tablica[i]);
            }

        }
        private void Poziom2_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            Poziom1.losowanie(liczba,  tablica);
        }
        private string time()
        {
            int m = 0;
            int s = 39;
            int mil = 999;
            string a;
            m -= stopWatch.Elapsed.Minutes;
            s -= stopWatch.Elapsed.Seconds;
            mil -= stopWatch.Elapsed.Milliseconds;
            a = string.Format("{0}:{1}.{2}", m, s, mil);
            if  (s <= -1)
            {
                stopWatch.Stop();
                b = 1;
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "lose.wav";
                myPlayer.Play();
                MessageBox.Show("Przegrywasz w 2 poziomie, wrócisz do menu", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 gameWindow = new Form1();
                this.Visible = false;
                gameWindow.Show();


            }
            return a;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (b == 0)
            {
                string a = time();
                this.stoper.Text = a;
            }
            else if (b == 1)
            {
                this.stoper.Text = "00:00:00";
            }
        }
        public void sprawdz(Label a)
        {
            stopWatch.Stop();
            if ((Math.Abs(label9.Location.X - A.X) < 15 && Math.Abs(label9.Location.Y - A.Y) < 15) &&
                (Math.Abs(label10.Location.X - B.X) < 15 && Math.Abs(label10.Location.Y - B.Y) < 15) &&
                (Math.Abs(label11.Location.X - C.X) < 15 && Math.Abs(label11.Location.Y - C.Y) < 15) &&
                (Math.Abs(label12.Location.X - D.X) < 15 && Math.Abs(label12.Location.Y - D.Y) < 15) &&
                (Math.Abs(label13.Location.X - E.X) < 15 && Math.Abs(label13.Location.Y - E.Y) < 15)&&
                (Math.Abs(label14.Location.X - F.X) < 15 && Math.Abs(label14.Location.Y - F.Y) < 15)
                )
            {
                stopWatch.Stop();
                wynik2 = string.Format("{0}:{1}.{2}", stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "win.wav";
                myPlayer.Play();
                MessageBox.Show("Wygrywasz, czas gry: "+ wynik2, "Wygrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Poziom3 gameWindow = new Poziom3();
                this.Visible = false;
                gameWindow.Show();
            }
            else
            {
                stopWatch.Stop();
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "lose.wav";
                myPlayer.Play();
                MessageBox.Show("Przegrywasz w 2 poziomie, wrócisz do menu", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void Poziom2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
