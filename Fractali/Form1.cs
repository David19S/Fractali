using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractali
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        Brush[] brushes = { Brushes.Red, Brushes.Green, Brushes.Blue,Brushes.Violet ,Brushes.Yellow, Brushes.Orange, Brushes.Indigo,Brushes.Beige ,Brushes.Pink };
        Brush br = new SolidBrush(Color.Black);
        int x;
        int i = 0;
        private void button1_Click(object sender, EventArgs e)
        {

            pictureBox1.Invalidate();
            if(checkBox1.Checked == false)
                br = new SolidBrush(Color.Black);
        }
        private void draw(Graphics g,int x ,Point p1, Point p2, Point p3)
        {
            if (x == 0)
            {
                if (checkBox1.Checked)
                {
                    br = brushes[i];
                    i++;
                    if(i==8)
                        i = 0;
                }
                Point[] pp = { p1, p2, p3 };
                g.FillPolygon(br, pp);
            }
            else
            {
                
                Point pm1 = new Point((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);
                Point pm2 = new Point((p1.X + p3.X) / 2, (p1.Y + p3.Y) / 2);
                Point pm3 = new Point((p2.X + p3.X) / 2, (p2.Y + p3.Y) / 2);
                Point[] points = { pm1, pm2, pm3 };
                draw(g, x -1 , p1, pm1, pm2);
                draw(g,x - 1,  pm1, p2, pm3);
                draw(g,x -1 , pm2, pm3, p3);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            pictureBox1.BackColor = Color.White;
            
            Point p1 = new Point(325, 30);
            Point p2 = new Point(50, 450);
            Point p3 = new Point(600, 450);
            x = (int)numericUpDown1.Value;
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            draw(e.Graphics, x, p1, p2, p3);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
