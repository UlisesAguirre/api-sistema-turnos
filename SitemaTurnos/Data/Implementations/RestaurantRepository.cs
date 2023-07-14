using SistemaTurnos.Data.Interfaces;
using SitemaTurnos.DBContext;
using SitemaTurnos.Entities;

namespace SistemaTurnos.Data.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly UserDbContext _dbContext;
        public RestaurantRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Restaurant GetRestaurantData()
        {
            Restaurant restaurant = _dbContext.Restaurant.Find("Pizzeria Paradiso");
            return restaurant;
        }
    }
}
