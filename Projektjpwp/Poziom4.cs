﻿using System;
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
    public partial class Poziom4 : Form
    {
        public Point firstPoint = new Point();
        private Stopwatch stopWatch;
        int b = 0;
        static public string wynik4;
        int liczba = 8;
        public Point A = new Point(45, 468);
        public Point B = new Point(125, 468);
        public Point C = new Point(205, 468);
        public Point D = new Point(285, 468);
        public Point E = new Point(365, 468);
        public Point F = new Point(445, 468);
        public Point G = new Point(525, 468);
        public Point H = new Point(605, 468);
        System.Windows.Forms.Label[] tablica = new System.Windows.Forms.Label[8];
        public Poziom4()
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
            tablica[6] = label16;
            tablica[7] = label18;
            for (int i = 0; i <= 7; i++)
            {
                Poziom1.move(tablica[i]);
            }
        }
        private string time()
        {
            int m = 0;
            int s = 34;
            int mil = 999;
            string a;
            m -= stopWatch.Elapsed.Minutes;
            s -= stopWatch.Elapsed.Seconds;
            mil -= stopWatch.Elapsed.Milliseconds;
            a = string.Format("{0}:{1}.{2}", m, s, mil);
            if (s <= -1)
            {
                stopWatch.Stop();
                b = 1;
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "lose.wav";
                myPlayer.Play();
                MessageBox.Show("Przegrywasz w 3 poziomie, wrócisz do menu", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 gameWindow = new Form1();
                this.Visible = false;
                gameWindow.Show();
            }
            return a;
        }
        public void sprawdz(Label a)
        {
            stopWatch.Stop();
            if ((Math.Abs(label9.Location.X - A.X) < 15 && Math.Abs(label9.Location.Y - A.Y) < 15) &&
                (Math.Abs(label10.Location.X - B.X) < 15 && Math.Abs(label10.Location.Y - B.Y) < 15) &&
                (Math.Abs(label11.Location.X - C.X) < 15 && Math.Abs(label11.Location.Y - C.Y) < 15) &&
                (Math.Abs(label12.Location.X - D.X) < 15 && Math.Abs(label12.Location.Y - D.Y) < 15) &&
                (Math.Abs(label13.Location.X - E.X) < 15 && Math.Abs(label13.Location.Y - E.Y) < 15) &&
                (Math.Abs(label14.Location.X - F.X) < 15 && Math.Abs(label14.Location.Y - F.Y) < 15) &&
                (Math.Abs(label16.Location.X - G.X) < 15 && Math.Abs(label16.Location.Y - G.Y) < 15) &&
                (Math.Abs(label18.Location.X - H.X) < 15 && Math.Abs(label18.Location.Y - H.Y) < 15)
                )
            {
                stopWatch.Stop();
                wynik4 = string.Format("{0}:{1}.{2}", stopWatch.Elapsed.Minutes, stopWatch.Elapsed.Seconds, stopWatch.Elapsed.Milliseconds);
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "win.wav";
                myPlayer.Play();
                MessageBox.Show("Wygrana, czas gry: " +wynik4, "Wygrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Wygrałeś wszystkie poziomy, czas gry: " + Environment.NewLine +"Poziom1: " + Poziom1.wynik1 + Environment.NewLine + "Poziom2: " + Poziom2.wynik2 + Environment.NewLine + "Poziom3: " + Poziom3.wynik3 + Environment.NewLine + "Poziom4: " + wynik4, "Podsumowanie", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 gameWindow = new Form1();
                this.Visible = false;
                gameWindow.Show();
            }
            else
            {
                stopWatch.Stop();
                System.Media.SoundPlayer myPlayer = new System.Media.SoundPlayer();
                myPlayer.SoundLocation = "lose.wav";
                myPlayer.Play();
                MessageBox.Show("Przegrywasz w 4 poziomie, wrócisz do menu", "Przegrana", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 gameWindow = new Form1();
                this.Visible = false;
                gameWindow.Show();
            }
        }
        private void Poziom4_Load(object sender, EventArgs e)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();
            Poziom1.losowanie(liczba, tablica);
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
        private void Poziom4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
