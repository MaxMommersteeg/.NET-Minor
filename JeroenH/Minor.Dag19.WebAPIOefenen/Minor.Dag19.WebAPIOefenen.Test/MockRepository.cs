using System;
using System.Collections.Generic;
using Entities;
using System.Linq;

namespace Minor.Dag19.WebAPIOefenen.Test
{
    internal class MockRepository : IRepository<Monument,long>
    {


        public int NumberOfTimesFindAllCalled { get; set; }
        public List<Monument> MonumentList { get; set; }
        public int NumberOfTimesAddCalled { get;  set; }
        public int NumberOfTimesRemoveCalled { get;  set; }
        public int NumberOfTimesFindCalled { get;  set; }
        public int NumberOfTimesUpdateCalled { get; private set; }

        public MockRepository()
        {
            MonumentList = new List<Monument>();
        }

        public MockRepository(List<Monument> monumentenList)
        {
            MonumentList = monumentenList;
        }
        public void Add(Monument monument)
        {
            NumberOfTimesAddCalled++;
            MonumentList.Add(monument);
        }

        public IEnumerable<Monument> FindAll()
        {
            NumberOfTimesFindAllCalled++;
            return MonumentList;
        }

        public void Remove(long id)
        {
            NumberOfTimesRemoveCalled++;
            MonumentList = MonumentList.Where(monument => monument.Id != id).ToList();
        }

        public Monument Find(long monumentId)
        {
            NumberOfTimesFindCalled++;
            return MonumentList.Find(monument => monument.Id == monumentId);
        }

        public void Update(Monument dummyMonument)
        {
            NumberOfTimesUpdateCalled++;
            var index = MonumentList.FindIndex(monument => monument.Id == dummyMonument.Id);
            MonumentList[index] = dummyMonument;
        }
    }
}