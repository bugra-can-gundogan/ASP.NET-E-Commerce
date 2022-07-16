using bugraGundoganASP.business.Abstract;
using bugraGundoganASP.data.Abstract;
using bugraGundoganASP.entity;

namespace bugraGundoganASP.business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void Create(Order entity)
        {
            _orderRepository.Create(entity);
        }

        public List<Order> GetOrders(string userId)
        {
            return _orderRepository.GetOrders(userId);
        }
    }
}