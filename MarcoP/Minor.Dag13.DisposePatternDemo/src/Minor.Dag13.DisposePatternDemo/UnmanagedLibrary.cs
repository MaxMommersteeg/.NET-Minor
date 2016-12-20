using System;

namespace Minor.Dag13.DisposePatternDemo
{
    internal class UnmanagedLibrary
    {
        internal static IntPtr Create()
        {
            throw new NotImplementedException();
        }

        internal static void SetInSafeState(IntPtr _robotArm)
        {
            throw new NotImplementedException();
        }

        internal static void TurnLeft(IntPtr _robotArm)
        {
            throw new NotImplementedException();
        }
    }
}