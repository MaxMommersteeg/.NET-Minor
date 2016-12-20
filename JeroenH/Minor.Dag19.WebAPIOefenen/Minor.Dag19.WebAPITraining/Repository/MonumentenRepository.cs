using Entities;
using System.Collections.Generic;
using System.Linq;

public class MonumentenRepository : IRepository<Monument, long>
{
    private List<Monument> _MonumentList = new List<Monument>()
    {
        new Monument { Id=10, MonumentNaam="Dom" },
        new Monument { Id=11, MonumentNaam="Martinitoren" },
        new Monument { Id=12, MonumentNaam="Don Jon" }

    };


    public void Add(Monument monument)
    {
        _MonumentList.Add(monument);
    }

    public Monument Find(long monumentId)
    {
        return _MonumentList.Find(monument => monument.Id == monumentId);
    }

    public IEnumerable<Monument> FindAll()
    {
        return _MonumentList;
    }

    public void Remove(long id)
    {
        _MonumentList = _MonumentList.Where(monument => monument.Id != id).ToList();     
    }

    public void Update(Monument dummyMonument)
    {
        var index = _MonumentList.FindIndex(monument => monument.Id == dummyMonument.Id);
        _MonumentList[index] = dummyMonument;

    }
}