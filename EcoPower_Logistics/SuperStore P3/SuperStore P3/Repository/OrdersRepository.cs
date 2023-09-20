using Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class OrdersRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrdersRepository(SuperStoreContext context) : base(context)
        {

        }


        public async Task<List<Order>>GetAllOrders()
        {
            return await _context.Orders.Include(o => o.Customer).ToListAsync();
        }



        public async Task<Order> GetOrderDetails(int orderId)
        {
            return await _context.Orders.Include(o => o.Customer).FirstOrDefaultAsync(m => m.OrderId == orderId);
        }

    }

}
