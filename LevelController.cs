using System.Windows.Forms;


namespace Project
{
    class LevelController : IController
    {
        private Snake snake;
        public Snake Snake { get => snake; set => snake = value; }

        public void Init()
        {
            Snake = new Snake();
        }

        public void Update()
        {
            Snake.Move();
        }
    }
}
