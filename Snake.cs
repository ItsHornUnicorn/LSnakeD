using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
    public class Snake
    {
        
        private List<Point> snakeCoords = new List<Point>();
        public List<Point> SnakeCoords { get => snakeCoords; set => snakeCoords = value; }


        public Snake()
        {
            SnakeCoords.Add(new Point(100, 100));
        }


        public void Move()
        {
            // Calc a new position of the head
            Point newHeadPosition = new Point(
                SnakeCoords[0].X + Direction.CurrentSnakeDirection.X,
                SnakeCoords[0].Y + Direction.CurrentSnakeDirection.Y
            );

            // Insert new position in the beginning of the snake list
            SnakeCoords.Insert(0, newHeadPosition);

            // Remove the last element
            SnakeCoords.RemoveAt(SnakeCoords.Count - 1);
        }

    }
}
