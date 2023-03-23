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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.MinimumSize = this.Size;
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
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
        /// Wyjście z gry
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Przejście do wyboru poziomu
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            Poziomy gameWindow = new Poziomy();
            this.Visible = false;
            gameWindow.Show();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
