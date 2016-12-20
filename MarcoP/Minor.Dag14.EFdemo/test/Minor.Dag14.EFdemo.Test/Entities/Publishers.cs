using System;
using System.Collections.Generic;

namespace Minor.Dag14.EFdemo.Test
{
    public partial class Publishers
    {
        public Publishers()
        {
            Employee = new HashSet<Employee>();
            Titles = new HashSet<Boek>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual ICollection<Employee> Employee { get; set; }
        public virtual PubInfo PubInfo { get; set; }
        public virtual ICollection<Boek> Titles { get; set; }
    }
}
