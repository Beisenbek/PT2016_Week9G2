using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example1
{
    public partial class Form1 : Form
    {
        Timer t = new Timer();

        public Form1()
        {
            
            InitializeComponent();

            t.Interval = 1000;
            t.Tick += T_Tick;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            progressBar1.PerformStep();
        }

        private void action2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("action 2 clicked!");
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t.Start();

        }
    }
}
