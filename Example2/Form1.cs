using Example2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2
{
    public partial class Form1 : Form
    {

        Drawer d;
       
        public Form1()
        {
            InitializeComponent();
            d = new Drawer(pictureBox1);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            toolStripStatusLabel1.Text = e.Location.ToString();

           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button b = sender as Button;
            d.p.Color = b.BackColor;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                d.Save(saveFileDialog1.FileName);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                d.Load(openFileDialog1.FileName);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            d.Shape = Shape.Eraser;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            d.Shape = Shape.Line;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            d.Shape = Shape.Pencil;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                d.p.Color = colorDialog1.Color;
                Button b = sender as Button;
                b.BackColor = colorDialog1.Color;
            }
        }
    }
}
