using bugraGundoganASP.entity;

namespace bugraGundoganASP.data.Abstract
{
    public interface IOrderRepository : IRepository<Order>
    {
        List<Order> GetOrders(string userId);
    }
}