using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{
    public partial class Form1 : Form
    {
        public static Form MainForm { get; set; }
        GameController gameController;

        public Form1()
        {
            InitializeComponent();
            MainForm = this;

            GameController.GameLoopedWithoutParams += DrawBackground;
            GameController.GameLooped += DrawSnake;

            gameController = new GameController();

        }

        

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'w':
                    Direction.CurrentSnakeDirection =
                        Direction.DirectionValues[DirectionEnum.Up];
                    break;
                case 'a':
                    Direction.CurrentSnakeDirection =
                        Direction.DirectionValues[DirectionEnum.Left];
                    break;
                case 's':
                    Direction.CurrentSnakeDirection =
                        Direction.DirectionValues[DirectionEnum.Down];
                    break;
                case 'd':
                    Direction.CurrentSnakeDirection =
                        Direction.DirectionValues[DirectionEnum.Right];
                    break;
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawBackground();
        }


        public void DrawSnake(List<Point> snakeCoords)
        {
            
            foreach (var cell in snakeCoords)
            {
                DrawRect(cell.X, cell.Y, Color.White);
            }
        }

        private void DrawBackground()
        {
            byte r, g, b;
            Random random = new Random();
            r = (byte)random.Next(0, 255);
            g = (byte)random.Next(0, 255);
            b = (byte)random.Next(0, 255);


            Graphics graphics = CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(Color.FromArgb(r, g, b));
            graphics.FillRectangle(solidBrush, new Rectangle(0, 0, 1000, 1000));

            solidBrush.Dispose();
            graphics.Dispose();
        }

        private void DrawRect(int x, int y, Color color)
        {
            Graphics g = CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(color);
            g.FillRectangle(solidBrush, new Rectangle(x, y, 10, 10));

            solidBrush.Dispose();
            g.Dispose();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameController.GameLoopedWithoutParams -= DrawBackground;
            GameController.GameLooped -= DrawSnake;
        }
    }
}
