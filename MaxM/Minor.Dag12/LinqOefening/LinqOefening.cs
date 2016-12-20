using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqOefening
{
    public class LinqOefening
    {
        private List<string> _personList = new List<string>
        {
            "Yael", "Rouke", "Wesley", "Simon", "Martin", "Jelle",
            "Martijn", "Robert-Jan", "Rob", "Pim", "Vincent", "Wouter",
            "Misha", "Steven", "Jeroen", "Max", "Menno", "Rory",
            "Jan", "Jan-Paul", "Michiel", "Gert", "Lars", "Joery"
        };
        public List<string> PersonList
        {
            private get { return _personList; }
            set { _personList = value; }
        }

        public IEnumerable<char> Vraag1()
        {
            return _personList.Where(x => x.Contains('R') || x.Contains('r'))
                              .Select(x => x[0]);
        }

        public IEnumerable<char> Vraag1Comprehension()
        {
            return from person in _personList
                   where person.Contains('R') || person.Contains('r')
                   select person[0];
        }

        public IEnumerable<int> Vraag2()
        {
            return _personList.Where(x => x[0] == 'J')
                              .OrderBy(x => x.Length)
                              .Select(x => x.Length);
        }

        public IEnumerable<int> Vraag2Comprehension()
        {
            return from person in _personList
                   where person[0] == 'J'
                   orderby person.Length
                   select person.Length;
        }

        public IEnumerable<int> Vraag3()
        {
            return _personList
                .GroupBy(x => x.Length)
                .Select(group => new
                {
                    CountInGroup = group.Count()
                })
                .Select(x => x.CountInGroup);
        }

        public IEnumerable<int> Vraag3Comprehension()
        {
            return new List<int>();
        }

        public IEnumerable<string> Vraag4()
        {
            return _personList.OrderBy(x => x.Length)
                               .ThenBy(x => x)
                               .GroupBy(x => x.Length)
                               .First()
                               .Where(x => !x.Contains("a") && !x.Contains("A"));
        }

        public IEnumerable<string> Vraag4Comprehension()
        {
            return new List<string>();
        }
    }
}
