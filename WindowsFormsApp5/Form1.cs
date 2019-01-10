using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        Point StartPoint = new Point();
        Point EndPoint = new Point();
        public Form1()
        {
            InitializeComponent();
        }

        private void Label_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint.X = e.X;
            StartPoint.Y = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                EndPoint.X = e.X;
                EndPoint.Y = e.Y;
                Label label = new Label();

                if (EndPoint.X < StartPoint.X) label.Location = EndPoint;
                else label.Location = StartPoint;
                label.Size = new Size(Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
                label.BackColor = Color.Black;
                Controls.Add(label);
            }
        }
    }
}
