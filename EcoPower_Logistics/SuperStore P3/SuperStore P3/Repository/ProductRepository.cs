using Data;
using Models;

namespace EcoPower_Logistics.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        //This creates the product repository
        public ProductRepository(SuperStoreContext context) : base(context)
        {

        }

    }

}