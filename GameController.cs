using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{

    class GameController : IController
    {
        public List<IController> Controllers { get; set; } = new List<IController>();
        private Form mainForm;

        public static event Action<List<Point>> GameLooped;


        public GameController()
        {
            MessageBox.Show("Game Controller started");

            Init();
            StartTimer();
        }

        public void Init()
        {
            mainForm = Form1.MainForm;
            Controllers.Add(new LevelController());

            foreach (var controller in Controllers)
            {
                controller.Init();
            }
        }


        private void StartTimer()
        {
            // Create a timer for the GameLoop method
            var timer = new Timer();
            timer.Tick += GameLoop;
            timer.Interval = 1000;
            timer.Start();
        }
        private void GameLoop(object sender, System.EventArgs e)
        {
            foreach (var controller in Controllers)
            {
                if (controller is LevelController)
                {
                    ((LevelController)controller).Update();
                }
            }


            OnGameLooped();
        }

        public void OnGameLooped()
        {

            List<Point> snakeCoords = null;

            foreach (var controller in Controllers)
            {
                if (controller is LevelController)
                {
                    snakeCoords = ((LevelController)controller).Snake.SnakeCoords;
                }
            }

            GameLooped?.Invoke(snakeCoords);
        }
    }
}
