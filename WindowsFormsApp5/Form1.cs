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
    public partial class drawFrm : Form
    {
        Point StartPoint = new Point();
        Point EndPoint = new Point();
        Random Random = new Random();
        int counter = 1;
        public drawFrm()
        {
            InitializeComponent();
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
                if (Math.Abs(EndPoint.X - StartPoint.X) < 10 && Math.Abs(EndPoint.Y - StartPoint.Y) < 10) MessageBox.Show("Less than 10x10");
                else
                {
                    EndPoint.X = e.X;
                    EndPoint.Y = e.Y;
                    Label label = new Label();
                    if (EndPoint.X > StartPoint.X && EndPoint.Y > StartPoint.Y) label.Location = StartPoint;
                    else if (EndPoint.X < StartPoint.X && EndPoint.Y < StartPoint.Y) label.Location = EndPoint;
                    else if (EndPoint.X < StartPoint.X && EndPoint.Y > StartPoint.Y) label.Location = new Point(EndPoint.X,StartPoint.Y);
                    else label.Location = new Point(StartPoint.X, EndPoint.Y);
                    label.Size = new Size(Math.Abs(EndPoint.X - StartPoint.X), Math.Abs(EndPoint.Y - StartPoint.Y));
                    label.BackColor = Color.FromArgb(Random.Next(0, 256), Random.Next(0, 256), Random.Next(0, 256));
                    label.Text = (counter++).ToString();
                    label.TextAlign = ContentAlignment.MiddleCenter;
                    Controls.Add(label);
                    label.MouseClick += Label_MouseClick;
                    label.MouseDoubleClick += Label_MouseDoubleClick;
                }
            }
        }

        private void Label_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if ((e as MouseEventArgs).Button == MouseButtons.Left)
            {
                (sender as Label).Dispose();
                foreach (var Control in Controls)
                {
                    if ((Control as Label).Location.X == (sender as Label).Location.X)
                    {
                        (Control as Label).Dispose();
                        break;
                    }
                }
            }
        }

        private void Label_MouseClick(object sender, MouseEventArgs e)
        {
            if ((sender as Label).Name != "created")
            {
                if (e.Button == MouseButtons.Left)
                {
                    Label newLabel = new Label();
                    newLabel.Location = new Point((sender as Label).Location.X, (sender as Label).Location.Y - 15);
                    newLabel.Text = $"Label area is {e.Location.X * e.Location.Y}. Location : {e.Location}";
                    newLabel.AutoSize = true;
                    newLabel.BackColor = Color.DarkGray;
                    Controls.Add(newLabel);
                    (sender as Label).Name = "created";
                }
            }
        }
    }
}
