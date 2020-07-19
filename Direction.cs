using System.Collections.Generic;
using System.Drawing;

namespace Project
{
    public enum DirectionEnum
    {
        Left,
        Right,
        Up,
        Down
    }

    public static class Direction
    {

        public static Point CurrentSnakeDirection { get; set; }
        public static Dictionary<DirectionEnum, Point> DirectionValues { get; set; } 
            = new Dictionary<DirectionEnum, Point>();

        static Direction()
        {
            DirectionValues.Add(DirectionEnum.Left, new Point(-10, 0));
            DirectionValues.Add(DirectionEnum.Right, new Point(10, 0));
            DirectionValues.Add(DirectionEnum.Up, new Point(0, -10));
            DirectionValues.Add(DirectionEnum.Down, new Point(0, 10));
        }

    }
}
