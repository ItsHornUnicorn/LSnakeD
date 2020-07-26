using System.Windows.Forms;

namespace Project
{
    public class TimeController : IController
    {
        private Timer timer;

        public Timer Timer { get => timer; set => timer = value; }

        public void Init()
        {
            // Create a timer for the GameLoop method
            Timer = new Timer();
            Timer.Interval = 100;
            Timer.Start();
        }


    }
}
