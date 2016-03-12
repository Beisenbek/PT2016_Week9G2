using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Example2.Model
{
    public enum Shape
    {
        Line,
        Pencil,
        Eraser
    }

    class Drawer
    {
        Bitmap bmp;
        Graphics g;
        public Pen p;
        Point prevPoint;
        PictureBox pictureBox;
        GraphicsPath path;

        public Shape Shape { get; set; }

        public Drawer(PictureBox pictureBox)
        {

            Shape = Shape.Pencil;

            this.pictureBox = pictureBox;

            this.pictureBox.MouseMove += PictureBox_MouseMove;
            this.pictureBox.MouseDown += PictureBox_MouseDown;
            this.pictureBox.MouseUp += PictureBox_MouseUp;
            this.pictureBox.Paint += PictureBox_Paint;

            p = new Pen(Color.Black);
            Load("");
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            if (path != null)
            {
                e.Graphics.DrawPath(p, path);
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (path != null)
            {
                g.DrawPath(p, path);
                path = null;
            }
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            prevPoint = e.Location;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Draw(e.Location);
            }
        }

        public void Draw(Point currentPoint)
        {

            switch (Shape)
            {
                case Shape.Line:
                    path = new GraphicsPath();
                    path.AddLine(prevPoint, currentPoint);
                    break;
                case Shape.Pencil:
                    g.DrawLine(p, prevPoint, currentPoint);
                    prevPoint = currentPoint;
                    break;
                case Shape.Eraser:
                    g.DrawLine(new Pen(Color.White,p.Width), prevPoint, currentPoint);
                    prevPoint = currentPoint;
                    break;
                default:
                    break;
            }

            pictureBox.Refresh();
        }

        public void Load(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                bmp = new Bitmap(pictureBox.Width, pictureBox.Height);
                g = Graphics.FromImage(bmp);

                g.Clear(Color.White);
            }
            else
            {
                bmp = new Bitmap(fileName);
                g = Graphics.FromImage(bmp);
            }

            pictureBox.Image = bmp;
        }

        public void Save(string fileName)
        {
            bmp.Save(fileName);
        }
    }
}
