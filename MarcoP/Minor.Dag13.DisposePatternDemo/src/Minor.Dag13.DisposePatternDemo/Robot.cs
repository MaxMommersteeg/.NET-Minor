using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag13.DisposePatternDemo
{
    public class Robot : IDisposable
    {
        private RobotArm _left;
        private RobotArm _right;

        public Robot()
        {
            _left = new RobotArm();
            _right = new RobotArm();
        }

        public void Dispose()
        {
            _left?.Dispose();
            _right?.Dispose();
        }
    }
}
