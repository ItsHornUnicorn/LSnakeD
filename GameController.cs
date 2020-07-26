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
        public static event Action GameLoopedWithoutParams;
        public static GameController gm { get; set; }

        public GameController()
        {
            Init();
        }

        public void Init()
        {
            gm = this;
            mainForm = Form1.MainForm;

            Controllers.Add(new LevelController());
            Controllers.Add(new TimeController());

            foreach (var controller in Controllers)
            {
                controller.Init();
            }

            TimeController timeController = FindController<TimeController>();
            timeController.Timer.Tick += GameLoop;
            

            
        }


        private void GameLoop(object sender, System.EventArgs e)
        {

            LevelController lc = FindController<LevelController>();
            lc.Update();




            OnGameLoopedWithoutParams();
            OnGameLooped();
        }

        protected void OnGameLooped()
        {

            List<Point> snakeCoords = null;
            LevelController lc = FindController<LevelController>();

            snakeCoords = lc.Snake.SnakeCoords;

            

            GameLooped?.Invoke(snakeCoords);
        }

        protected void OnGameLoopedWithoutParams()
        {
            GameLoopedWithoutParams?.Invoke();
        }

        public T FindController<T>() where T: class  
        {
            foreach (var controller in Controllers)
            {
                if (controller is T)
                {
                    return (controller as T);
                }
            }

            return null;


        }
    }
}
