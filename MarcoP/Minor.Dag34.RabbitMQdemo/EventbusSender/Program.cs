using Minor.WSA.Common;
using Minor.WSA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventbusSender
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var publisher = new EventPublisher())
            {
                publisher.Publish(new HoopVanZegenEvent() { Name = "Kniertje" });
            }
        }
    }
}
