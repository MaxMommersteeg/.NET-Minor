using System;

public class Order
{
    private IOrderRepository _repo;

    public long Ordernumber { get; set; }


    public Order(IOrderRepository repo)
    {
        _repo = repo;
    }

    public Order()
    {
    }

    public void Create(CreateOrderCommand coc)
    {
        Order order = _repo.FindOrderByID(coc.Ordernumber);
        if (order != null)
        {
            throw new DuplicateOrderException();
        }

        Ordernumber = coc.Ordernumber;
        _repo.Insert(this);
    }
}