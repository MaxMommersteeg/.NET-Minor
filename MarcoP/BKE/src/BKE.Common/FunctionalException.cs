using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BKE.Common
{
    public class FunctionalException : Exception
    {
        public List<FunctionalError> FunctionalErrors { get; set; }

        public FunctionalException()
        {
            FunctionalErrors = new List<FunctionalError>();
        }

        public FunctionalException(FunctionalError error) : this()
        {
            this.Add(error);
        }

        public void Add(FunctionalError error)
        {
            FunctionalErrors.Add(error);
        }
 
    }
}
