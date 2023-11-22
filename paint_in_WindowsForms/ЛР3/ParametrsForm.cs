using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ЛР3
{
    public partial class ParametrsForm : Form
    {
        Form1 parent;

        public ParametrsForm(Form1 parentForm)
        {
            InitializeComponent();
            Width = 400;
            Height = 400;

            this.parent = parentForm;
            FormClosed += ParametrsForm_FormClosed;

            /*System.Windows.Forms.Button b_color_point = new System.Windows.Forms.Button();
            b_color_point.Text = "Сменить цвет точки";
            b_color_point.Top = 10;
            b_color_point.Height = 50 ;
            b_color_point.Width = 200;
            b_color_point.Click += new EventHandler(b_color_point_Click);
            System.Windows.Forms.Button b_color_line = new System.Windows.Forms.Button();
            b_color_line.Text = "Сменить цвет кривой";
            b_color_line.Top = 70;
            b_color_line.Height = 50;
            b_color_line.Width = 200;
            b_color_line.Click += new EventHandler(b_color_line_Click);*/

            Paint += ParametrsForm_Paint;


            System.Windows.Forms.Button b_color_1 = new System.Windows.Forms.Button();
            b_color_1.Top = 5;
            b_color_1.Left = 10;
            b_color_1.Height = 20;
            b_color_1.Width = 20;
            b_color_1.BackColor = Color.Black;
            b_color_1.Click += new EventHandler(b_color_1_Click);
            System.Windows.Forms.Button b_color_2 = new System.Windows.Forms.Button();
            b_color_2.Top = 25;
            b_color_2.Left = 10;
            b_color_2.Height = 20;
            b_color_2.Width = 20;
            b_color_2.BackColor = Color.Blue;
            b_color_2.Click += new EventHandler(b_color_2_Click);
            System.Windows.Forms.Button b_color_3 = new System.Windows.Forms.Button();
            b_color_3.Top = 45;
            b_color_3.Left = 10;
            b_color_3.Height = 20;
            b_color_3.Width = 20;
            b_color_3.BackColor = Color.Yellow;
            b_color_3.Click += new EventHandler(b_color_3_Click);
            System.Windows.Forms.Button b_color_4 = new System.Windows.Forms.Button();
            b_color_4.Top = 65;
            b_color_4.Left = 10;
            b_color_4.Height = 20;
            b_color_4.Width = 20;
            b_color_4.BackColor = Color.Green;
            b_color_4.Click += new EventHandler(b_color_4_Click);
            System.Windows.Forms.Button b_color_5 = new System.Windows.Forms.Button();
            b_color_5.Top = 85;
            b_color_5.Left = 10;
            b_color_5.Height = 20;
            b_color_5.Width = 20;
            b_color_5.BackColor = Color.Purple;
            b_color_5.Click += new EventHandler(b_color_5_Click);
            System.Windows.Forms.Button b_color_6 = new System.Windows.Forms.Button();
            b_color_6.Top = 105;
            b_color_6.Left = 10;
            b_color_6.Height = 20;
            b_color_6.Width = 20;
            b_color_6.BackColor = Color.Pink;
            b_color_6.Click += new EventHandler(b_color_6_Click);
            System.Windows.Forms.Button b_color_7 = new System.Windows.Forms.Button();
            b_color_7.Top = 125;
            b_color_7.Left = 10;
            b_color_7.Height = 20;
            b_color_7.Width = 20;
            b_color_7.BackColor = Color.Red;
            b_color_7.Click += new EventHandler(b_color_7_Click);
            System.Windows.Forms.Button b_color_8 = new System.Windows.Forms.Button();
            b_color_8.Top = 145;
            b_color_8.Left = 10;
            b_color_8.Height = 20;
            b_color_8.Width = 20;
            b_color_8.BackColor = Color.Olive;
            b_color_8.Click += new EventHandler(b_color_8_Click);
            System.Windows.Forms.Button b_color_9 = new System.Windows.Forms.Button();
            b_color_9.Top = 165;
            b_color_9.Left = 10;
            b_color_9.Height = 20;
            b_color_9.Width = 20;
            b_color_9.BackColor = Color.Tan;
            b_color_9.Click += new EventHandler(b_color_9_Click);
            System.Windows.Forms.Button b_color_10 = new System.Windows.Forms.Button();
            b_color_10.Top = 185;
            b_color_10.Left = 10;
            b_color_10.Height = 20;
            b_color_10.Width = 20;
            b_color_10.BackColor = Color.Navy;
            b_color_10.Click += new EventHandler(b_color_10_Click);


            System.Windows.Forms.Button b_color_11 = new System.Windows.Forms.Button();
            b_color_11.Top = 5;
            b_color_11.Left = 60;
            b_color_11.Height = 20;
            b_color_11.Width = 20;
            b_color_11.BackColor = Color.Black;
            b_color_11.Click += new EventHandler(b_color_11_Click);
            System.Windows.Forms.Button b_color_12 = new System.Windows.Forms.Button();
            b_color_12.Top = 25;
            b_color_12.Left = 60;
            b_color_12.Height = 20;
            b_color_12.Width = 20;
            b_color_12.BackColor = Color.Blue;
            b_color_12.Click += new EventHandler(b_color_12_Click);
            System.Windows.Forms.Button b_color_13 = new System.Windows.Forms.Button();
            b_color_13.Top = 45;
            b_color_13.Left = 60;
            b_color_13.Height = 20;
            b_color_13.Width = 20;
            b_color_13.BackColor = Color.Yellow;
            b_color_13.Click += new EventHandler(b_color_13_Click);
            System.Windows.Forms.Button b_color_14 = new System.Windows.Forms.Button();
            b_color_14.Top = 65;
            b_color_14.Left = 60;
            b_color_14.Height = 20;
            b_color_14.Width = 20;
            b_color_14.BackColor = Color.Green;
            b_color_14.Click += new EventHandler(b_color_14_Click);
            System.Windows.Forms.Button b_color_15 = new System.Windows.Forms.Button();
            b_color_15.Top = 85;
            b_color_15.Left = 60;
            b_color_15.Height = 20;
            b_color_15.Width = 20;
            b_color_15.BackColor = Color.Purple;
            b_color_5.Click += new EventHandler(b_color_15_Click);
            System.Windows.Forms.Button b_color_16 = new System.Windows.Forms.Button();
            b_color_16.Top = 105;
            b_color_16.Left = 60;
            b_color_16.Height = 20;
            b_color_16.Width = 20;
            b_color_16.BackColor = Color.Pink;
            b_color_16.Click += new EventHandler(b_color_16_Click);
            System.Windows.Forms.Button b_color_17 = new System.Windows.Forms.Button();
            b_color_17.Top = 125;
            b_color_17.Left = 60;
            b_color_17.Height = 20;
            b_color_17.Width = 20;
            b_color_17.BackColor = Color.Red;
            b_color_17.Click += new EventHandler(b_color_17_Click);
            System.Windows.Forms.Button b_color_18 = new System.Windows.Forms.Button();
            b_color_18.Top = 145;
            b_color_18.Left = 60;
            b_color_18.Height = 20;
            b_color_18.Width = 20;
            b_color_18.BackColor = Color.Olive;
            b_color_18.Click += new EventHandler(b_color_18_Click);
            System.Windows.Forms.Button b_color_19 = new System.Windows.Forms.Button();
            b_color_19.Top = 165;
            b_color_19.Left = 60;
            b_color_19.Height = 20;
            b_color_19.Width = 20;
            b_color_19.BackColor = Color.Tan;
            b_color_19.Click += new EventHandler(b_color_19_Click);
            System.Windows.Forms.Button b_color_20 = new System.Windows.Forms.Button();
            b_color_20.Top = 185;
            b_color_20.Left = 60;
            b_color_20.Height = 20;
            b_color_20.Width = 20;
            b_color_20.BackColor = Color.Navy;
            b_color_20.Click += new EventHandler(b_color_20_Click);
            /*Controls.Add(b_color_point); */
            /*Controls.Add(b_color_line); */

            Controls.Add(b_color_1);
            Controls.Add(b_color_2);
            Controls.Add(b_color_3);
            Controls.Add(b_color_4);
            Controls.Add(b_color_5);
            Controls.Add(b_color_6);
            Controls.Add(b_color_7);
            Controls.Add(b_color_8);
            Controls.Add(b_color_9);
            Controls.Add(b_color_10);
            Controls.Add(b_color_11);
            Controls.Add(b_color_12);
            Controls.Add(b_color_13);
            Controls.Add(b_color_14);
            Controls.Add(b_color_15);
            Controls.Add(b_color_16);
            Controls.Add(b_color_17);
            Controls.Add(b_color_18);
            Controls.Add(b_color_19);
            Controls.Add(b_color_20);
        }

        private void b_color_1_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Black;
            parent.Refresh();
        }
        private void b_color_2_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Blue;
            parent.Refresh();
        }
        private void b_color_3_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Yellow;
            parent.Refresh();
        }
        private void b_color_4_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Green;
            parent.Refresh();
        }
        private void b_color_5_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Purple;
            parent.Refresh();
        }
        private void b_color_6_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Pink;
            parent.Refresh();
        }
        private void b_color_7_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Red;
            parent.Refresh();
        }
        private void b_color_8_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Olive;
            parent.Refresh();
        }
        private void b_color_9_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Tan;
            parent.Refresh();
        }
        private void b_color_10_Click(object sender, EventArgs e)
        {
            parent.pen_Line = Color.Navy;
            parent.Refresh();
        }
        private void b_color_11_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Black;
            parent.Refresh();
        }
        private void b_color_12_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Blue;
            parent.Refresh();
        }
        private void b_color_13_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Yellow;
            parent.Refresh();
        }
        private void b_color_14_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Green;
            parent.Refresh();
        }
        private void b_color_15_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Purple;
            parent.Refresh();
        }
        private void b_color_16_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Pink;
            parent.Refresh();
        }
        private void b_color_17_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Red;
            parent.Refresh();
        }
        private void b_color_18_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Olive;
            parent.Refresh();
        }
        private void b_color_19_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Tan;
            parent.Refresh();
        }
        private void b_color_20_Click(object sender, EventArgs e)
        {
            parent.brush_point = Color.Navy;
            parent.Refresh();
        }

        private void ParametrsForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
        }

        /*private void b_color_line_Click(object sender, EventArgs e)
        {
            ColorDialog line_color = new ColorDialog();
            line_color.AllowFullOpen = false;
            line_color.ShowHelp = true;


            if (line_color.ShowDialog() == DialogResult.OK)
                parent.pen_Line = line_color.Color;
            
            parent.Refresh();
        }*/

        /* private void b_color_point_Click(object sender, EventArgs e)
         {
             ColorDialog point_color = new ColorDialog();
             point_color.AllowFullOpen = false;
             point_color.ShowHelp = true;


             if (point_color.ShowDialog() == DialogResult.OK)
                 parent.brush_point = point_color.Color;

             parent.Refresh();
         }*/
        private void ParametrsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
        }

    }
}

