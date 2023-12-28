using WindowBlazor_Models;

namespace WindowBlazor_Client.Service.IService
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAll(string? userId);
        public Task<OrderDTO> Get(int orderId);
        public Task<OrderDTO> Create(OrderProcessingDTO orderProcessingDTO);
    }
}
