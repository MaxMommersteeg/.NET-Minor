using FrontEnd.Agents.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace FrontEnd.Parsers
{
    public interface ICursusFileParser
    {
        /// <summary>
        /// CursusFileToTextLinesChunks
        /// Read a cursusFile, extracts lines per Cursus object
        /// Returns list in chunks
        /// </summary>
        /// <param name="cursusFile"></param>
        /// <returns></returns>
        IList<List<string>> CursusFileToTextLinesChunks(IFormFile cursusFile);

        /// <summary>
        /// GetCursussenFromCursusFile
        /// Extracts a list of Cursus objects from a IFormFile (Cursusbestand)
        /// Between range DateTime.MinValue and DateTime.MaxValue
        /// </summary>
        /// <param name="cursusFile">IFormFile (Cursusbestand)</param>
        /// <returns>IEnumerable(Cursus)</returns>
        ParsedCursusFileResultContainer GetCursussenFromCursusFile(IFormFile cursusFile);

        /// <summary>
        /// GetCursussenFromCursusFile
        /// Extracts a list of Cursus objects from a IFormFile (Cursusbestand)
        /// Between given range (startDate, endDate)
        /// </summary>
        /// <param name="cursusFile">IFormFile (Cursusbestand)</param>
        /// <param name="startDate">DateTime First acceptable Cursus</param>
        /// <param name="endDate">DateTime Last acceptable Cursus</param>
        /// <returns>IEnumerable(Cursus)</returns>
        ParsedCursusFileResultContainer GetCursussenFromCursusFile(IFormFile cursusFile, DateTime startDate, DateTime endDate);

        /// <summary>
        /// ParseTextLinesChunkToCursus
        /// Parses required textlines from Cursusbestand to a Cursus object and returns the Cursus
        /// </summary>
        /// <param name="textLines">List of required textLines from Cursusbestand for a single Cursus object</param>
        /// <returns>Cursus</returns>
        ParsedCursusFileResult ParseTextLinesChunkToCursus(List<string> textLines);

        /// <summary>
        /// CursusInRange
        /// Checks if Cursus is valid for given range
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="cursus"></param>
        /// <returns>Wether the cursus is in range</returns>
        bool CursusInRange(DateTime startDate, DateTime endDate, Cursus cursus);
    }
}
