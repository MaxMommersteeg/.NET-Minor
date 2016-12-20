using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Case2.MaRoWo.RDW.IntegrationService.Infrastructure.IO
{
    /// <summary>
    /// String writer with an encoding you can set yourself
    /// </summary>
    public sealed class StringWriterWithEncoding : StringWriter
    {
        private readonly Encoding encoding;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="encoding"></param>
        public StringWriterWithEncoding(Encoding encoding)
        {
            this.encoding = encoding;
        }

        /// <summary>
        /// 
        /// </summary>
        public override Encoding Encoding
        {
            get { return encoding; }
        }
    }
}
