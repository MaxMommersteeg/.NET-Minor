using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LINQLijst
{
    public class LinqQueries
    {
        private List<string> _lijst;

        public LinqQueries(List<string> lijst)
        {
            _lijst = lijst;
        }

        public string First()
        {
            return _lijst[0];
        }

        public List<char> FirstLetters()
        {
            var firstLettersLijstQuery = from naam in _lijst
                                         select naam[0];
            return firstLettersLijstQuery.ToList();
        }

        public List<char> FirstLettersContaining(string teZoekenLetter)
        {
            var firstLettersLijstQuery = from naam in _lijst
                                         where naam.Contains(teZoekenLetter.ToLower()) || naam.Contains(teZoekenLetter.ToUpper())
                                         select naam[0];
            
            return firstLettersLijstQuery.ToList();
        }

        public List<char> FirstLettersContainingLambdaMethod(string teZoekenLetter)
        {
            return _lijst
                        .Where(naam => naam.Contains(teZoekenLetter.ToLower()) || naam.Contains(teZoekenLetter.ToUpper()))
                        .Select(naam => naam[0])
                        .ToList();
        }

        public List<int> GroupCountStartingWithDesc(char teZoekenLetter)
        {
            var groupCountStartingWithQuery = 
                                        from naam in _lijst
                                        where naam[0] == teZoekenLetter
                                        orderby naam.Length descending
                                        select naam.Length
                                         ;
            return groupCountStartingWithQuery.ToList();
        }

        public List<int> GroupCountStartingWithDescLambda(char teZoekenLetter)
        {
            return _lijst
                        .Where(naam => naam[0] == teZoekenLetter)
                        .OrderByDescending(naam => naam.Length)
                        .Select(naam => naam.Length)
                        .ToList();
        }

        public List<int> GroupNameLength()
        {
            var groupNameLengthQuery =
                                     from naam in _lijst
                                     orderby naam.Length
                                     group naam by naam.Length into naamLengteGroep
                                     select naamLengteGroep.Count()
                                     ;
            return groupNameLengthQuery.ToList();
        }

        public List<int> GroupNameLengthLambda()
        {
            return _lijst
                    .OrderBy(naam => naam.Length)
                    .GroupBy(naam => naam.Length)
                    .Select(naam => naam.Count())
                    .ToList();
        }

        public List<string> ListShortestNames()
        {
            var groupNameShortestNamesQuery =
                                    from naam in _lijst
                                    orderby naam.Length
                                    group naam by naam.Length into naamLengteGroep
                                    select naamLengteGroep;

            return groupNameShortestNamesQuery.First().ToList();

        }

        public List<string> ListShortestNames(string teZoekenLetter)
        {
            var groupNameShortestNamesQuery =
                        from naam in _lijst
                        orderby naam.Length, naam
                        group naam by naam.Length into naamLengteGroep
                        select naamLengteGroep;

            return groupNameShortestNamesQuery
                .First()
                .Where(
                    naam => !naam.Contains(teZoekenLetter.ToUpper()) 
                    && !naam.Contains(teZoekenLetter.ToLower())
                    )
                .ToList();

        }

        public List<string> ListShortestNamesLambda(string teZoekenLetter)
        {
            return _lijst
                .OrderBy(naam => naam.Length)
                .ThenBy(naam => naam)
                .GroupBy(naam => naam.Length)
                .First()
                .Where(naam => !naam.Contains(teZoekenLetter.ToUpper()) && !naam.Contains(teZoekenLetter.ToLower()))
                
                .ToList();
        }
    }
}
