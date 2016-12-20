using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag39.SpelbeheerServiceBackend.Outgoing
{
    public class SpelGestartEvent
    {
        public int SpelId { get; set; }
        public int[] SpelerIds { get; set; }

    }
}

