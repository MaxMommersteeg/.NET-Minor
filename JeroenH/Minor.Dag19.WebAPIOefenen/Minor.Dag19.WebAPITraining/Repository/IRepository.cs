using System.Collections.Generic;
using Entities;

public interface IRepository<T, K>
{
    IEnumerable<T> FindAll();
    void Add(Monument monument);
    Monument Find(long monumentId);
    void Update(Monument dummyMonument);
    void Remove(long id);
}