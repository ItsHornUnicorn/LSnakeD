using System;
using System.Drawing;
using System.Windows.Forms;


namespace Project
{
    public class Pickupable
    {
        private Point coords;
        public Point Coords { get => coords; set => coords = value; }
    }

    class LevelController : IController
    {
        private Snake snake;
        public Snake Snake { get => snake; set => snake = value; }
        public Pickupable Pickupable { get => pickupable; set => pickupable = value; }
        private Pickupable pickupable;


        public static event Action FoodGenerated;

        public void Init()
        {
            Snake = new Snake();
            GenerateNewPickupable();
        }

        public void Update()
        {
            Snake.Move();
        }

        public void GenerateNewPickupable()
        {
            Pickupable = new Pickupable();
            Random rnd = new Random();

            Pickupable.Coords = new Point(rnd.Next(1, 9) * 10, rnd.Next(1, 9) * 10);

            OnFoodGenerated();
            
        }

        public void OnFoodGenerated()
        {
            FoodGenerated?.Invoke();
        }



    }
}
