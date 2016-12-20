using EventbusSender;
using Minor.WSA.Infrastructure;
using System;

namespace EventbusReceiver
{
    internal class MyReciever : EventDispatcher
    {
        public void HoopvanZegen(HoopVanZegenEvent ev)
        {
            Console.WriteLine($"\"Op hoop van zegen,\" zegt {ev.Name}");
        }
        public void AllHopeIsLost(AllHopeIsLostEvent ev)
        {
            Console.WriteLine($"\"All hope is lost,\" says {ev.Name}");
        }
    }
}