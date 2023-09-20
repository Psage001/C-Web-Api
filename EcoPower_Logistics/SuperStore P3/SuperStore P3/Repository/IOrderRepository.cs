using Models;

namespace EcoPower_Logistics.Repository
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        //this retrieves the orders
        Task<List<Order>>GetAllOrders();

        //This gets the order details
        Task<Order>GetOrderDetails(int orderId);
    }
}