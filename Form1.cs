using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

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
        private void randomLine_Click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            try
            {
                PropList pl = new PropList();
                pl.Add(new FillProps(this.colorFill.BackColor));
                pl.Add(new LineProps(this.colorContour.BackColor, float.Parse(textBox5.Text)));
                Line line1 = new Line(new Frame(random.Next(0, Form1.ActiveForm.Width - 100), random.Next(0, Form1.ActiveForm.Height), random.Next(0, Form1.ActiveForm.Width - 100), random.Next(0, Form1.ActiveForm.Height)), pl);
                line1.Draw(DS);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите корректную толщину!");
            }
            
        }
        private void randomRect_Click(object sender, System.EventArgs e)
        {
            Random random = new Random();
            int x1 = random.Next(0, Form1.ActiveForm.Width - 100);
            int y1 = random.Next(0, Form1.ActiveForm.Height);
            try
            {
                PropList pl = new PropList();
                pl.Add(new FillProps(this.colorFill.BackColor));
                pl.Add(new LineProps(this.colorContour.BackColor, float.Parse(textBox5.Text)));
                Rect rect1 = new Rect(new Frame(x1, y1, random.Next(0, Form1.ActiveForm.Width - 100 - x1), random.Next(0, Form1.ActiveForm.Height - y1)), pl);
                rect1.Draw(DS);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите корректную толщину!");
            }

        }
        private void lineCoords_Click(object sender, System.EventArgs e)
        {
            try
            {
                PropList pl = new PropList();
                pl.Add(new FillProps(this.colorFill.BackColor));
                pl.Add(new LineProps(this.colorContour.BackColor, float.Parse(textBox5.Text)));
                Line line1 = new Line(new Frame(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text)), pl );
                line1.Draw(DS);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите корректные данные!");
            }
        }
        private void rectCoords_Click(object sender, System.EventArgs e)
        {
            try
            {
                PropList pl = new PropList();
                pl.Add(new FillProps(this.colorFill.BackColor));
                pl.Add(new LineProps(this.colorContour.BackColor, float.Parse(textBox5.Text)));
                Rect rect1 = new Rect(new Frame(int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text), int.Parse(textBox4.Text)), pl);
                rect1.Draw(DS);
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Введите корректные данные!");
            }
        }
        private void colorFill_Click(object sender, EventArgs e)
        {
            this.colorFillDialog.ShowDialog();
            this.colorFill.BackColor = this.colorFillDialog.Color;
        }
        private void colorContour_Click(object sender, EventArgs e)
        {
            this.colorContourDialog.ShowDialog();
            this.colorContour.BackColor = this.colorContourDialog.Color;
        }
        private void paint(object sender, PaintEventArgs e)
        {
            Group group = new Group(new List<Item> { new Line(new Frame(1, 1, 100, 100), new PropList())});

            group.Add(new Rect(new Frame(100, 100, 200, 200), new PropList()));
            group.Draw(DS);
            group.frame.DrawFrame(DS).Draw(DS);
        }
    }
}
