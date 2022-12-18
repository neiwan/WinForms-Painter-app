using System.Windows.Forms;
using System.Drawing;
using System;

namespace Painter
{
    public partial class Form1 : Form
    {
        DrawSystem DS;
        public Form1()
        {
            InitializeComponent();
            DS = new DrawSystem(CreateGraphics());
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Line line2_4 = new Line(100, 1, 1, 100);
            Line dot = new Line(1, 1, 100, 100);
            Rect rect1 = new Rect(100, 100, 100, 100);

            FillProps fp1 = new FillProps(Color.Red);
            LineProps lp1 = new LineProps(Color.Black, 10.5F);

            FillProps fp2 = new FillProps(Color.Azure);
            LineProps lp2 = new LineProps(Color.Blue, 4.5F);

            FillProps fp3 = new FillProps(Color.Transparent);
            LineProps lp3 = new LineProps(Color.Black, 1F);

            //line2_4.Draw(DS);
            Group group = new Group(line2_4, dot);
            group.Add(rect1);
            
            dot.AddProps(lp1);

            rect1.AddProps(fp2);
            rect1.AddProps(lp2);

            group.Draw(DS);

            rect1.AddProps(fp3);
            rect1.AddProps(lp3);

            rect1.Draw(DS);

        }
        //rd line
        private void button1_Click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            Line line1 = new Line(random.Next(0, Form1.ActiveForm.Width - 100), random.Next(0, Form1.ActiveForm.Height), random.Next(0, Form1.ActiveForm.Width - 100), random.Next(0, Form1.ActiveForm.Height));
            line1.Draw(DS);
        }
        //rd rect
        private void button2_Click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            int x1 = random.Next(0, Form1.ActiveForm.Width - 100);
            int y1 = random.Next(0, Form1.ActiveForm.Height);
            Rect rect1 = new Rect(x1, y1, random.Next(0, Form1.ActiveForm.Width - 100 - x1), random.Next(0, Form1.ActiveForm.Height - y1));
            rect1.Draw(DS);
        }
        //line
        private void button3_Click(object sender, System.EventArgs e)
        {
            try
            {
                Line line1 = new Line(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                line1.Draw(DS);
            }
            catch
            {

            }
        }
        //rect
        private void button4_Click(object sender, System.EventArgs e)
        {
            try
            {
                Rect rect1 = new Rect(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text));
                rect1.Draw(DS);
            }
            catch
            {

            }
        }
    }
}
