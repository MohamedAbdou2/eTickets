using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);

        Task<List<Order>> GetOrderByIdAndRoleAsync(string userId, string userRole);


    }
}
