using FrontEnd.Agents.Models;
using System.Collections.Generic;

namespace FrontEnd.Parsers
{
    public class ParsedCursusFileResult
    {
        /// <summary>
        /// ParsedCursusFileResult Constructor
        /// </summary>
        public ParsedCursusFileResult()
        {
            ErrorMessages = new List<string>();
        }

        public Cursus ParsedCursus { get; set; }
        public Cursus DuplicateCursus { get; set; }

        public bool IsIncorrectFormat { get; set; }

        public IList<string> ErrorMessages { get; set; }
    }
}
