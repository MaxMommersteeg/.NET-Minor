public interface IOrderRepository
{
    void Insert(Order order);
    Order FindOrderByID(long id);
}