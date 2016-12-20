using Backend.DAL;
using Backend.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Test.Mock
{
    public class KoffieRepositoryMock : IRepository<Koffie, int>
    {
        public int DeleteCalled { get; private set; } 
        public int LastDeletedId { get; private set; }

        public int FindAllCalled { get; private set; }
        public IEnumerable<Koffie> LastFindAllCollection { get; private set; }

        public int GetAllCalled { get; private set; }
        public IEnumerable<Koffie> LastGetAllCollection { get; private set; }

        public int GetByIdCalled { get; private set; }
        public Koffie LastGetByIdKoffie { get; private set; }

        public int InsertCalled { get; private set; }
        public Koffie LastInsertKoffie { get; private set; }

        public int UpdateCalled { get; private set; }
        public Koffie LastUpdateKoffie { get; private set; }

        private List<Koffie> _koffieList;

        public KoffieRepositoryMock()
        {
            _koffieList = new List<Koffie>
            {
                new Koffie { Id = 1, Naam = "Bonen" },
                new Koffie { Id = 2, Naam = "Poeder" },
                new Koffie { Id = 3, Naam = "Cappucino" },
                new Koffie { Id = 4, Naam = "Latte Machiato" }
            };
        }

        public void Delete(int id)
        {
            DeleteCalled++;
            LastDeletedId = id;
            _koffieList = _koffieList.Where(x => x.Id != id).ToList();
        }

        public IEnumerable<Koffie> GetAll()
        {
            GetAllCalled++;
            LastGetAllCollection = _koffieList;
            return LastGetAllCollection;
        }

        public Koffie GetById(int id)
        {
            GetByIdCalled++;
            LastGetByIdKoffie = _koffieList.Where(x => x.Id == id).FirstOrDefault();
            return LastGetByIdKoffie;
        }

        public void Insert(Koffie item)
        {
            InsertCalled++;
            LastInsertKoffie = item;
            _koffieList.Add(LastInsertKoffie);
        }

        public void Update(Koffie item)
        {
            UpdateCalled++;
            LastUpdateKoffie = item;

            var existingItem = GetById(item.Id);
            if (existingItem == null)
            {
                return;
            }
            int indexToUpdate = 0;
            for (var i = 0; i < _koffieList.Count; i++)
            {
                if (_koffieList[i].Id != existingItem.Id)
                {
                    continue;
                }
                indexToUpdate = i;
                break;
            }
            _koffieList[indexToUpdate] = item;
        }
    }
}
