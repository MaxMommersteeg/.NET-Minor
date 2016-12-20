using FrontEnd.Agents.Models;
using System.Collections.Generic;

namespace FrontEnd.Parsers
{
    public class ParsedCursusFileResultContainer
    {
        /// <summary>
        /// ParsedCursusFileContainer Constructor
        /// </summary>
        public ParsedCursusFileResultContainer()
        {
            ParsedCursussen = new List<Cursus>();
            DuplicateCursussen = new List<Cursus>();
            ErrorMessages = new List<string>();
        }

        public IList<Cursus> ParsedCursussen { get; set; }

        public IList<string> ErrorMessages { get; set; }

        public IList<Cursus> DuplicateCursussen { get; set; }
    }
}
