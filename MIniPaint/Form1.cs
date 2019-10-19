using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MIniPaint
{
    public partial class Form1 : Form
    {
        Bitmap picsel;
        Bitmap picsel1;
        int x1, y1;
        int xclik1, yclick1;
        string mode;
        public Form1()
        {
            mode = "Line";
            InitializeComponent();
            picsel = new Bitmap(1000,1000);
            picsel1 = new Bitmap(1000, 1000);
            x1 = y1 = 0;
        }

        /// <summary>
        /// Przycisk z kolorem
        /// </summary>
        private void button9_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            button4.BackColor = b.BackColor;
        }

        /// <summary>
        /// otwiera plik z komputera
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                picsel1 = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = picsel;
            }
            
        }

        /// <summary>
        /// Zachowuje gotową grafikę
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
          saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            picsel.Save(saveFileDialog1.FileName);
        }

        /// <summary>
        /// Zamyka program
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Funkcja linii
        /// </summary>
        private void button10_Click(object sender, EventArgs e)
        {
            mode = "Line";
        }

        /// <summary>
        /// Funkcja kwadratu
        /// </summary>
        private void button11_Click(object sender, EventArgs e)
        {
            mode = "Square";
        }

        /// <summary>
        /// Funkcja Owalu
        /// </summary>
        private void button12_Click(object sender, EventArgs e)
        {
            mode = "Oval";
        }

        /// <summary>
        /// Rysowanie linii i figur na polu
        /// </summary>
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            Pen pen;
            pen = new Pen(button4.BackColor, trackBar1.Value);
          
            Graphics graphics;
            graphics = Graphics.FromImage(picsel);
            if (mode == "Square")
            {
                graphics.DrawRectangle(pen, xclik1, yclick1, e.X - xclik1, e.Y - yclick1);
            }
            if (mode == "Oval")
            {
                graphics.DrawEllipse(pen, xclik1, yclick1, e.X - xclik1, e.Y - yclick1);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void plikToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
           xclik1= e.X;
           yclick1= e.Y;
        }

        /// <summary>
        /// Sam proces wykonywania programu
        /// </summary>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen pen;
            pen = new Pen(button4.BackColor, trackBar1.Value);

            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            
            Graphics graphics;
            graphics = Graphics.FromImage(picsel);

            Graphics graphics1;
            graphics1 = Graphics.FromImage(picsel1);


            if (e.Button == MouseButtons.Left)
            {
                if (mode == "Line")
                {
                    graphics.DrawLine(pen, x1, y1, e.X, e.Y);
                }
                if (mode == "Square")
                { 
                    graphics1.Clear(Color.White);
                    int x, y;
                    x = xclik1;
                    y = yclick1;
                    if (x > e.X)x = e.X;
                    if (y > e.Y)y = e.Y;
                    graphics1.DrawRectangle(pen, x, y, Math.Abs( e.X - xclik1),Math.Abs( e.Y - yclick1));
                }
                if (mode == "Oval")
                {
                    graphics1.Clear(Color.White);
                    graphics1.DrawEllipse(pen, xclik1, yclick1, e.X - xclik1, e.Y - yclick1);
                }
                graphics1.DrawImage(picsel, 0, 0);
                pictureBox1.Image = picsel1;
               
            }
            x1=e.X;
            y1=e.Y;
        }
    }
}
