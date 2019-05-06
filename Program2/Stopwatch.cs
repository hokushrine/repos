using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Stopwatch
    {
        // declare private variables
        private DateTime StartTime { get; set; }
        private TimeSpan PassedTimeSpan { get; set; }
        private bool _isStopWatchRunning;


        public void Start()
        {
            if(!_isStopWatchRunning) // if stopwatch is not running
            {
                StartTime = DateTime.Now;
                _isStopWatchRunning = true;
            }
            else { throw new InvalidOperationException("Stopwatch is already running"); }
        }

        public void Stop()
        {
            PassedTimeSpan = DateTime.Now - StartTime;
        }

        public string DisplayTimeSpan()
        {
            return PassedTimeSpan.ToString();
        }


    }
}
