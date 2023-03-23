using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projektjpwp
{
    public partial class Poziomy : Form
    {
        public Poziomy()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        /// <summary>
        /// Przejście do 1 poziomu
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            Poziom1 gameWindow = new Poziom1();
            this.Visible = false;
            gameWindow.Show();
        }
        /// <summary>
        /// Przejście do 2 poziomu
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Poziom2 gameWindow = new Poziom2();
            this.Visible = false;
            gameWindow.Show();
        }
        /// <summary>
        /// Przejście do menu
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 gameWindow = new Form1();
            this.Visible = false;
            gameWindow.Show();
        }
        /// <summary>
        /// Wyjście z gry
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Przejście do 3 poziomu
        /// </summary>
        private void button5_Click(object sender, EventArgs e)
        {
            Poziom3 gameWindow = new Poziom3();
            this.Visible = false;
            gameWindow.Show();
        }
        /// <summary>
        /// Przejście do 4 poziomu
        /// </summary>
        private void button6_Click(object sender, EventArgs e)
        {
            Poziom4 gameWindow = new Poziom4();
            this.Visible = false;
            gameWindow.Show();
        }
        private void Poziomy_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
