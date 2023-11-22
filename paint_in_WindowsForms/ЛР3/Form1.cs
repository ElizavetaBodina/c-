using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ЛР3
{
    public partial class Form1 : Form
    {
        List<Point> arPoints = new List<Point>();//лист с точкам
 
 
        bool bPoints = false;    // флаг рисования точки  
        bool bcurv = false;      //флаг кривой
        bool bpolygon = false;   //флаг ломанной
        bool bbez = false;       //флаг кривой Безье
        bool bfill = false;      //флаг заполнения
        bool bDrag = false;      //флаг перемещения точки
        bool bMove = false;      //флаг движения точек
        bool bSave = false;      //Флаг сохранения
        List<Point> savePoints = new List<Point>();

        private Timer moveTimer = new Timer();

        public Color pen_Line = Color.Black;
        public Color brush_point = Color.Red;
        public Form1()
        {
            
            InitializeComponent();

            KeyPreview = true;
            KeyDown += new KeyEventHandler(Form1_KeyDown);

            MouseClick += new MouseEventHandler(Form1_MouseClick);
            Width = 500;
            Height = 600;

            Button b_points = new Button();
            b_points.Text = "Точки";
            b_points.Top = 0;
            b_points.Click += new EventHandler(b_points_Click);
            Button b_parametrs = new Button();
            b_parametrs.Text = "Параметры";
            b_parametrs.Top = 30;
            b_parametrs.Click += new EventHandler(b_parametrs_Click);
            Button b_curve = new Button();
            b_curve.Text = "Кривая";
            b_curve.Top = 60;
            b_curve.Click += new EventHandler(b_curve_Click);
            Button b_polygon = new Button();
            b_polygon.Text = "Ломаная";
            b_polygon.Top = 90;
            b_polygon.Click += new EventHandler(b_polygon_Click);
            Button b_beziers = new Button();
            b_beziers.Text = "Безье";
            b_beziers.Top = 120;
            b_beziers.Click += new EventHandler(b_beziers_Click);
            Button b_fill = new Button();
            b_fill.Text = "Заполненая";
            b_fill.Top = 150;
            b_fill.Click += new EventHandler(b_fill_Click);
            Button b_move = new Button();
            b_move.Text = "Движение";
            b_move.Top = 180;
            b_move.Click += new EventHandler(b_move_Click);
            Button b_clear = new Button();
            b_clear.Text = "Очистить";
            b_clear.Top = 210;
            b_clear.Click += new EventHandler(b_clear_Click);
            Button b_Save = new Button();
            b_Save.Text = "Сохранение";
            b_Save.Top = 240;
            b_Save.Click += new EventHandler(b_Save_Click);

            Paint += Form1_Paint;

            Controls.Add(b_points);
            Controls.Add(b_parametrs);
            Controls.Add(b_curve); 
            Controls.Add(b_polygon);
            Controls.Add(b_beziers);
            Controls.Add(b_fill);
            Controls.Add(b_move);
            Controls.Add(b_clear);
            Controls.Add(b_Save);

            moveTimer.Interval = 30;
            moveTimer.Tick += TimerTickHandler;


        }


        void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush br = new SolidBrush(color:brush_point);
            Pen p = new Pen(color: pen_Line, width: 4);

            if (bSave)
            {               
                    foreach (var point in savePoints)
                        g.FillEllipse(br, point.X, point.Y, 8, 8);
                               
                    g.DrawClosedCurve(p, savePoints.ToArray());
                                
            }
            if (bPoints)
            {
                foreach (var point in arPoints)
                    g.FillEllipse(br, point.X, point.Y, 8, 8);

            }
            
            
            if (bcurv)
            {
                g.DrawClosedCurve(p, arPoints.ToArray());

            }
            if (bpolygon)
            {
                g.DrawPolygon(p, arPoints.ToArray());

            }
            if (bbez)
            {
                g.DrawBeziers(p, arPoints.ToArray());
                bbez = false;
            }
            if (bfill)
            {
                g.FillClosedCurve(Brushes.SkyBlue, arPoints.ToArray());
                bfill= false;
                bcurv = false;               
            }

        }
        void b_points_Click(object sender, EventArgs e)
        {

            bPoints = true;
            bDrag = false;
            bMove = false;
            if(!bSave)
            {
                Refresh();
            }
                

        }
        void b_parametrs_Click(object sender, EventArgs e)
        {
            ParametrsForm new_form = new ParametrsForm(this);
            new_form.Show();

        }
        void b_curve_Click(object sender, EventArgs e)
        {
            if (arPoints.Count > 0)
            {

               bcurv = true;
               bpolygon = false;
               Refresh();
            }
        }
        void b_polygon_Click(object sender, EventArgs e)
        {
            if (arPoints.Count > 0)
            {
                bcurv = false;
                bpolygon = true;
                Refresh();
            }
        }
        void b_beziers_Click(object sender, EventArgs e)
        {
            if (arPoints.Count == 4)
            {
                bpolygon = false;
                bcurv = false;
                bbez = true;
                Refresh();
            }
        }
        void b_fill_Click(object sender, EventArgs e)
        {
            if (arPoints.Count > 2)
            {
                bpolygon = false;
                bfill = true;
                bcurv = true;
                Refresh();
            }
        }
        void b_move_Click(object sender, EventArgs e)
        {
            bMove = !bMove;
            moveTimer.Start();

            if (!bMove) { moveTimer.Stop(); }

        }
        void b_clear_Click(object sender, EventArgs e)
        {
                arPoints.Clear();
                bPoints = false;
                bcurv = false;
                bpolygon = false;
                bbez = false;
                bfill = false;
                bDrag = false;
                bMove = false;
                pen_Line = Color.Black;
                brush_point = Color.Red;
                Refresh();
            
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && bPoints)
            {
                // Сохраняем координаты курсора мышки
                Point p = e.Location;
                // Добавляем в коллекцию точек
                arPoints.Add(p);
                // Генерируем событие Paint для перерисовки точек
                Refresh();
            }

        }
        void TimerTickHandler(object sender, EventArgs e)
        {
            MovePoints();
            Refresh();
        }

        private void MovePoints()
        {
            if(arPoints.Count > 0)
            {
                Random rn = new Random();
                
                int DeltaX = 0, DeltaY = 0;

                for (int i = 0; i < arPoints.Count;i++ )
                {
                    if(arPoints[i].X > 300 ) //Доп. Обработка границ движения
                        DeltaX = DeltaX - 10;
                    else if(arPoints[i].X < 100)
                        DeltaX = DeltaX + 10 ;
                    else if (arPoints[i].Y > 300)
                        DeltaY = DeltaY - 10;
                    else if (arPoints[i].Y < 50)
                        DeltaY = DeltaY + 10;
                    else
                    {
                        DeltaX = rn.Next(-20, 20);
                        DeltaY = rn.Next(-20, 20);
                    }
                    arPoints[i] = new Point(arPoints[i].X + DeltaX, arPoints[i].Y + DeltaY);
                    
                }
            }
        }
        void b_Save_Click(object sender, EventArgs e)
        {
            bSave = true;
            bPoints = false;
            bcurv = false;
            bpolygon = false;
            bbez = false;
            bfill = false;
            bDrag = false;
            bMove = false;


            savePoints.Clear();
            foreach (Point p in arPoints)
            {
                savePoints.Add(p);

            }
            arPoints.Clear();                      
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case (Keys.Space): moveTimer.Stop(); e.Handled = true; break;
                case (Keys.Escape):b_clear_Click(sender, e);e.Handled = true; break;
                case (Keys.Oemplus): moveTimer.Interval = 10; e.Handled = true; break;
                case (Keys.OemMinus): moveTimer.Interval = 50; e.Handled = true; break;
                default: e.Handled = true; break;
            }

        }
        protected override bool ProcessCmdKey(ref Message msg,Keys keyData)
        {
            bool IsHandled = true;
            switch (keyData)
            {
                case Keys.Up:
                    if (bMove)
                    {
                        for (int i = 1; i < arPoints.Count; i++)
                        {
                            if (arPoints[i].Y < arPoints[i - 1].Y)
                            {
                                moveTimer.Interval = 10;
                            }                           
                        }
                        Refresh();
                    }
                    break;
                case Keys.Down:
                    if (bMove)
                    {
                        for (int i = 1; i < arPoints.Count; i++)
                        {
                            if (arPoints[i].Y > arPoints[i - 1].Y)
                            {
                                moveTimer.Interval = 50;
                            }                          
                        }
                        Refresh();
                    }
                    break;
                case Keys.Left:
                    if (bMove)
                    {

                        for (int i = 1; i < arPoints.Count; i++)
                        {
                            if (arPoints[i].X < arPoints[i - 1].X)
                            {
                                moveTimer.Interval = 10;
                            }
                        }
                        Refresh();
                    }
                    break;
                case Keys.Right:
                    if (bMove)
                    {
                        for (int i = 1; i < arPoints.Count; i++)
                        {
                            if (arPoints[i].X > arPoints[i - 1].X)
                            {
                                moveTimer.Interval = 50;
                            }
                        }
                        Refresh();
                    }
                    break;
                default:
                    IsHandled = false;
                    break;
            }
            return IsHandled;
        }
    }
}
