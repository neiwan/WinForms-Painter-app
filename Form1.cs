using System.Windows.Forms;
using System.Drawing;
using System;
using System.Collections.Generic;

namespace Painter
{
    public partial class Form1 : Form
    {
        IController IContrl;
        public Form1(Model model)
        {
            InitializeComponent();
            IContrl = new Controller(model);
            IContrl.IModel.GrController.SetPort(panel2.CreateGraphics());
        }
        private void colorFill_Click(object sender, EventArgs e)
        {
            if (this.colorFillDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorFill.BackColor = this.colorFillDialog.Color;
                IContrl.IModel.GrParams.FillProps.Color = this.colorFillDialog.Color;
            }
        }
        private void colorContour_Click(object sender, EventArgs e)
        {
            if (this.colorContourDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorContour.BackColor = this.colorContourDialog.Color;
                IContrl.IModel.GrParams.LineProps.Color = this.colorContourDialog.Color;
            }
            
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = e.X;
                int y = e.Y;
                IContrl.IEventHandler.LeftMouseUp(x, y);
                IContrl.IModel.GrController.Repaint();
            }
        }
        private void paint(object sender, PaintEventArgs e)
        {
            IContrl.IModel.GrController.SetPort(panel2.CreateGraphics());
            IContrl.IModel.GrController.Repaint();
        }
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                IContrl.IModel.GrParams.LineProps.Width = float.Parse(textBox5.Text);
            }
            catch
            {

            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case (0):
                    IContrl.IModel.Factory.ItemType = ItemType.Line;
                    break;
                case (1):
                    IContrl.IModel.Factory.ItemType = ItemType.Rect;
                    break;
            }
        }
    }
}
