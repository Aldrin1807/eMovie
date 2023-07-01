using eMovie.Models;

namespace eMovie.Data.Services
{
    
        public interface IOrdersService
        {
            Task MakeOrder(List<ShoppingCartItem> items, string userId, string userEmailAddress);
            Task<List<Order>> GetOrdersByUserIdAndRole(string userId, string userRole);
        }
    
}
