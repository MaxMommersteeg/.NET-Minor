using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Minor.Dag21.CAS.FrontEnd.FrontEnd.ViewModels
{
    public class CursusCreateMessageViewModel
    {
        public int SuccesInsertCount { get; set; }
        public int ErrorAtLine { get; set; }
        public int TotalInsertCount { get; internal set; }
    }
}
