using StarField;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StarsWithoutHelp
{
    public partial class Form1 : Form
    {
        private Random random = new Random();
        private Star[] stars = new Star[15000];
        private Graphics graphics;

        public float Map(float n, float start1, float stop1, float start2, float stop2)
        {
            return start2 + (n - start1) / (stop1 - start1) * (stop2 - start2);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            graphics.Clear(Color.Black);

            for (int i = 0; i < stars.Length; i++)
            {
                DrawStar(stars[i]);
                MoveStar(stars[i]);
            }

            pictureBox1.Refresh();
        }

        private void DrawStar(Star star)
        {
            float starSize = Map(star.Z, 0, pictureBox1.Width, 7, 0);
            float x = Map(star.X / star.Z, 0, 1, 0, pictureBox1.Width) + pictureBox1.Width / 2;
            float y = Map(star.Y / star.Z, 0, 1, 0, pictureBox1.Height) + pictureBox1.Height / 2;

            graphics.FillEllipse(Brushes.WhiteSmoke, x, y, starSize, starSize);

        }

        private void MoveStar(Star star)
        {
            star.Z -= 10;
            if (star.Z < 1)
            {
                star.Z = random.Next(1, pictureBox1.Width);
                star.X = random.Next(-pictureBox1.Width, pictureBox1.Width);
                star.Y = random.Next(-pictureBox1.Height, pictureBox1.Height);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            graphics = Graphics.FromImage(pictureBox1.Image);

            for (int i = 0; i < stars.Length; i++)
            {
                stars[i] = new Star()
                {
                    X = random.Next(-pictureBox1.Width, pictureBox1.Width),
                    Y = random.Next(-pictureBox1.Height, pictureBox1.Height),
                    Z = random.Next(1, pictureBox1.Width)
                };
            }
            timer1.Start();
        }

    }   
}
