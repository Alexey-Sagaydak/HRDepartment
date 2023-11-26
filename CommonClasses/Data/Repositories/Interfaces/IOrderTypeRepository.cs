using System.Collections.Generic;

namespace CommonClasses
{
    public interface IOrderTypeRepository
    {
        OrderType AddOrderType(string orderType);
        void DeleteOrderType(OrderType orderType);
        List<OrderType> GetOrderTypes();
        List<OrderType> GetOrderTypesLike(string pattern);
        void SaveChanges();
    }
}