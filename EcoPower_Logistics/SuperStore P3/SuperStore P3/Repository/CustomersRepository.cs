using Data;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EcoPower_Logistics.Repository
{
    public class CustomersRepository : GenericRepository<Customer>, ICustomerRepository
    {
        //This creates the customer repository
        public CustomersRepository(SuperStoreContext context) : base(context)
        {
        }
    }
}