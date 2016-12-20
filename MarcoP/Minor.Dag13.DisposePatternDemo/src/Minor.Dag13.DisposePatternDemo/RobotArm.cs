using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag13.DisposePatternDemo
{
    public class RobotArm : IDisposable
    {
        private IntPtr _robotArm;

        public RobotArm()
        {
            _robotArm = UnmanagedLibrary.Create();
        }

        public void TurnLeft(int degrees)
        {
            UnmanagedLibrary.TurnLeft(_robotArm);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }

        protected virtual void Dispose(bool deProgrammeurDeedHet)
        {
            UnmanagedLibrary.SetInSafeState(_robotArm);
            if (deProgrammeurDeedHet)
            {
                // Roep recursief Dispose aan op alle componenten
            }
        }

        ~RobotArm()
        {
            Dispose(false);
        }
    }
}
