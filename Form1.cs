using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        // Variables
        Graphics draw;
        int pen_x = -1, pen_y = -1;
        bool pen_moving = false;
        Pen my_pen;
        bool my_dots = true;

        public Form1()
        {
            InitializeComponent();
            draw = flowLayoutPanel1.CreateGraphics();
            draw.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            my_pen = new Pen(Color.Black, 3);
            pictureBox6.BackColor = Color.Black;
            my_pen.StartCap = my_pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            label4.Text = my_pen.Width.ToString();
            my_dots = true;
            Dots_check.Text = "Dots";
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PictureBox my_picture = (PictureBox)sender;
            my_pen.Color = my_picture.BackColor;
            pictureBox6.BackColor = my_picture.BackColor;
        }

        private void flowLayoutPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            pen_moving = true;
            pen_x = e.X;
            pen_y = e.Y;
        }

        private void flowLayoutPanel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (pen_moving && pen_x != -1 && pen_y != -1)
            {
                if (my_dots)
                {
                    draw.DrawLine(my_pen, new Point(pen_x, pen_y), e.Location);
                    pen_x = e.X;
                    pen_y = e.Y;
                }
                else
                {
                    draw.DrawLine(my_pen, new Point(pen_x, pen_y), e.Location);
                }
            }
        }

        private void Dots_Click(object sender, EventArgs e)
        {
            Button my_obj = (Button)sender;
            if (my_obj.Text == "Dots")
            {
                my_obj.Text = "Lines";
                my_dots = false;
            }
            else if (my_obj.Text == "Lines")
            {
                my_obj.Text = "Dots";
                my_dots = true;
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            my_pen.Width += 2;
            if (my_pen.Width > 0)
                label4.Text = my_pen.Width.ToString();
            else
            {
                label4.Text = Convert.ToString(1);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            my_pen.Width -= 2;
            if (my_pen.Width > 0)
                label4.Text = my_pen.Width.ToString();
            else
            {
                label4.Text = Convert.ToString(1);
                my_pen.Width = 1;
            }
        }

        private void clearbtn_Click(object sender, EventArgs e)
        {
            draw.Clear(BackColor);
        }

        private void flowLayoutPanel1_MouseUp(object sender, MouseEventArgs e)
        {
            pen_moving = false;
            pen_x = -1;
            pen_y = -1;
        }
    }
}
