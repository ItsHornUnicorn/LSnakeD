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
            //DrawSnake();
        }


        public void DrawSnake(List<Point> snakeCoords)
        {
            foreach (var cell in snakeCoords)
            {
                DrawRect(cell.X, cell.Y, Color.Green);
            }
        }

        private void DrawRect(int x, int y, Color color)
        {
            Graphics g = CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(color);
            g.FillRectangle(solidBrush, new Rectangle(x, y, 10, 10));

            solidBrush.Dispose();
            g.Dispose();

        }
    }
}
