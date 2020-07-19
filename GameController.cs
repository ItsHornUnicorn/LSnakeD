using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project
{

    class GameController: IController
    {
        List<IController> controllers = new List<IController>();

        public GameController()
        {
            MessageBox.Show("Game Controller started");

            Init();
        }

        public void Init()
        {
            controllers.Add(new LevelController());


            foreach (var controller in controllers)
            {
                controller.Init();
            }
        }
    }
}
