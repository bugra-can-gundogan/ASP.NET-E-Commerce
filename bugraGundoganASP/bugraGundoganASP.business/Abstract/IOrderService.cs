using bugraGundoganASP.entity;

namespace bugraGundoganASP.business.Abstract
{
    public interface IOrderService
    {
        void Create(Order entity);
        List<Order> GetOrders(string userId);
    }
}