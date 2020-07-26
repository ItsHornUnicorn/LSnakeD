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
            GameController.GameLoopedWithoutParams += DrawFood;

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
            //DrawBackground();
        }

        public void DrawFood()
        {

            LevelController lc = GameController.gm.FindController<LevelController>();
            DrawRect(lc.Pickupable.Coords.X, lc.Pickupable.Coords.Y, 10, 10, Color.White);
            
        }

        public void DrawSnake(List<Point> snakeCoords)
        {
            
            foreach (var cell in snakeCoords)
            {
                DrawRect(cell.X, cell.Y, 10, 10, Color.White);
            }
        }

        private void DrawBackground()
        {
            byte r, g, b;
            Random random = new Random();
            r = (byte)random.Next(0, 255);
            g = (byte)random.Next(0, 255);
            b = (byte)random.Next(0, 255);
            var color = Color.FromArgb(r, g, b);

            DrawRect(0, 0, 1000, 1000, color);
        }

        private void DrawRect(int x, int y, int width, int height, Color color)
        {
            Graphics g = CreateGraphics();
            SolidBrush solidBrush = new SolidBrush(color);
            g.FillRectangle(solidBrush, new Rectangle(x, y, width, height));

            solidBrush.Dispose();
            g.Dispose();

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            GameController.GameLoopedWithoutParams -= DrawBackground;
            LevelController.FoodGenerated -= DrawFood;
            GameController.GameLooped -= DrawSnake;
        }
    }
}
