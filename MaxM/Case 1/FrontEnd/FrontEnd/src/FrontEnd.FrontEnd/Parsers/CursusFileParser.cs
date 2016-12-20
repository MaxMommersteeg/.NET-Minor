using System.Collections.Generic;
using FrontEnd.Agents.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using FrontEnd.Extensions;
using System;
using System.Globalization;
using FrontEnd.Agents;
using NuGet.Packaging;

namespace FrontEnd.Parsers
{
    public class CursusFileParser : ICursusFileParser
    {
        private const int LINES_PER_CURSUS = 4;
        private readonly CultureInfo nlNL = new CultureInfo("nl-NL");
        private readonly ICASService _casService;

        private int _fileLineNumber;
        private ParsedCursusFileResultContainer _parsedCursusFileResultContainer;

        public CursusFileParser(ICASService casService)
        {
            _casService = casService;
        }

        /// <summary>
        /// GetCursussenFromCursusFile
        /// Extracts IEnumerable of Cursus from the Cursusbestand (IFormFile)
        /// </summary>
        /// <param name="cursusFile">Cursusbestand IFormFile</param>
        /// <returns>IEnumerable of Cursus</returns>
        public ParsedCursusFileResultContainer GetCursussenFromCursusFile(IFormFile cursusFile)
        {
            return GetCursussenFromCursusFile(cursusFile, DateTime.MinValue, DateTime.MaxValue);
        }

        /// <summary>
        /// GetCursussenFromCursusFile
        /// Extracts IEnumerable of Cursus from the Cursusbestand (IFormFile)
        /// </summary>
        /// <param name="cursusFile">Cursusbestand IFormFile</param>
        /// <returns>IEnumerable of Cursus</returns>
        public ParsedCursusFileResultContainer GetCursussenFromCursusFile(IFormFile cursusFile, DateTime startDate, DateTime endDate)
        {
            _parsedCursusFileResultContainer = new ParsedCursusFileResultContainer();

            var cursusLineChunks = CursusFileToTextLinesChunks(cursusFile);

            if (cursusLineChunks.Count < 1)
            {
                _parsedCursusFileResultContainer.ErrorMessages.Add("Cursusbestand moet minimaal één cursus bevatten");
                return _parsedCursusFileResultContainer;
            }

            var parsedCursusFileResults = new List<ParsedCursusFileResult>();
            // Iterate over chunks
            foreach (var cursusLineChunk in cursusLineChunks)
            {
                try
                {
                    // Parse and add cursus to list
                    parsedCursusFileResults.Add(ParseTextLinesChunkToCursus(cursusLineChunk));
                    _fileLineNumber += LINES_PER_CURSUS + 1;
                }
                catch
                {
                    throw;
                }
            }

            // Store all error messages if any
            _parsedCursusFileResultContainer.ErrorMessages = parsedCursusFileResults.SelectMany(x => x.ErrorMessages).ToList();

            // Filter according to given range
            _parsedCursusFileResultContainer.DuplicateCursussen = _parsedCursusFileResultContainer.DuplicateCursussen.Where(x => CursusInRange(startDate, endDate, x)).ToList();
            _parsedCursusFileResultContainer.ParsedCursussen = _parsedCursusFileResultContainer.ParsedCursussen.Where(x => CursusInRange(startDate, endDate, x)).ToList();

            return _parsedCursusFileResultContainer;
        }

        public IList<List<string>> CursusFileToTextLinesChunks(IFormFile cursusFile)
        {
            var cursusFileLines = new List<string>();
            // Read each line and put in list<string>
            try
            {
                using (var streamReader = new StreamReader(cursusFile.OpenReadStream()))
                {
                    string currentLine;
                    while ((currentLine = streamReader.ReadLine()) != null)
                    {
                        cursusFileLines.Add(currentLine); // Add to list.
                    }
                }
            }
            catch
            {
                throw;
            }

            // Remove whitelines
            cursusFileLines = cursusFileLines.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();

            // Make chunks of 4 lines (4 lines represent a single Cursus)
            return cursusFileLines.ChunkBy(LINES_PER_CURSUS);
        }

        /// <summary>
        /// ParseTextLinesToCursus
        /// Uses .NET libraries to parse multiple textlines to a single Cursus object
        /// </summary>
        /// <param name="textLines">Cursusbestand textlines for a single Cursus object</param>
        /// <returns>Cursus</returns>
        public ParsedCursusFileResult ParseTextLinesChunkToCursus(List<string> textLines)
        {
            var parsedCursusFileResult = new ParsedCursusFileResult();

            // set CurrentLineNumber to keep track of error line number. Add 1, since we want to start at 1-index.
            int currentLineNumber = _fileLineNumber + 1;

            // Title
            var title = textLines[0]?.Replace("Titel:", "").Trim();
            if (string.IsNullOrEmpty(title))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Titel bestaat niet, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }
            currentLineNumber++;

            // Cursuscode
            var cursusCode = textLines[1]?.Replace("Cursuscode:", "").Trim();
            if (string.IsNullOrEmpty(cursusCode))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Cursuscode bestaat niet, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }
            currentLineNumber++;

            // Duur
            var duur = textLines[2]?.Replace("Duur:", "").Trim();
            if (!duur.Contains("dagen"))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Verwacht hier het 'Duur' veld. Deze inhoud moet zijn 'nummer'[spatie]'dagen', regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }
            duur = duur.FirstOrDefault().ToString();
            // Check for empty char
            if (duur.FirstOrDefault() == '\0')
            {
                parsedCursusFileResult.ErrorMessages.Add($"Duur bestaat niet, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }
            if (string.IsNullOrEmpty(duur))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Duur is leeg, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }
            
            // Try to parse string to int
            int parsedDuur;
            if (!int.TryParse(duur, out parsedDuur))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Duur is geen geldig getal, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }
            currentLineNumber++;

            // Startdatum
            var startDatum = textLines[3]?.Replace("Startdatum:", "").Trim();
            if (string.IsNullOrEmpty(startDatum))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Startdatum bestaat niet, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }
            // See if StartDatum contains illegal '-', '/' should be used
            if (startDatum.Contains("-"))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Startdatum formaat klopt niet, moet dd/mm/jjjj zijn, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }

            // Try to parse Date string to valid DateTime object using nl-NL CultureInfo
            DateTime parsedDate;
            if (!DateTime.TryParse(startDatum, nlNL, DateTimeStyles.None, out parsedDate))
            {
                parsedCursusFileResult.ErrorMessages.Add($"Startdatum is geen geldige datum, regel: {currentLineNumber}");
                parsedCursusFileResult.IsIncorrectFormat = true;
                return parsedCursusFileResult;
            }

            // Create new Cursus object for parsed fields
            var cursus = new Cursus
            {
                Title = title,
                AmountOfDays = parsedDuur,
                StartDate = parsedDate,
                CursusCode = cursusCode
            };

            // Check if we have local duplicates
            var cursusIsLocalDuplicate = _parsedCursusFileResultContainer.ParsedCursussen
            .Select
            (
                x => new
                {
                    x.CursusCode,
                    x.StartDate
                })
                .Any
                (
                    x => x.CursusCode == cursus.CursusCode &&
                    x.StartDate == cursus.StartDate
            );

            if (cursusIsLocalDuplicate)
            {
                _parsedCursusFileResultContainer.DuplicateCursussen.Add(cursus);
                return parsedCursusFileResult;
            }

            object serverDuplicateResult;
            try
            {
                // Check if cursus is Server Duplicate
                serverDuplicateResult = _casService.ApiV1CursusByCursuscodeByYearByMonthByDayGet(cursusCode, parsedDate.Year, parsedDate.Month, parsedDate.Day);
            }
            catch
            {
                throw;
            }

            // Casting object to bool: http://stackoverflow.com/a/1974969/1661209
            if (serverDuplicateResult is bool)
            {
                if ((bool)serverDuplicateResult)
                {
                    // Duplicate
                    _parsedCursusFileResultContainer.DuplicateCursussen.Add(cursus);
                    return parsedCursusFileResult;
                }
            }

            // TextLines were successfully parsed to Cursus object
            _parsedCursusFileResultContainer.ParsedCursussen.Add(cursus);
            return parsedCursusFileResult;
        }

        public bool CursusInRange(DateTime startDate, DateTime endDate, Cursus cursus)
        {
            // Full cursus before range
            if(cursus.StartDate < startDate && cursus.StartDate.AddDays(cursus.AmountOfDays) < startDate)
            {
                return false;
            }

            // Cursus overlaps with range (includes even if later than EndDate)
            if (cursus.StartDate.AddDays(cursus.AmountOfDays) >= cursus.StartDate)
            {
                return true;
            }

            // Cursus StartDate between StartDate and EndDate
            if (cursus.StartDate >= startDate && cursus.StartDate < endDate)
            {
                return true;
            }
            return false;
        }
    }
}
