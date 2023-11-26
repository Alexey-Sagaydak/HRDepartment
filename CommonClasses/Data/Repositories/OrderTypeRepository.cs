using CommonClasses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonClasses
{
    public class OrderTypeRepository : Repository<Division>, IOrderTypeRepository
    {
        private DBContext DBContext => Context as DBContext;

        public OrderTypeRepository(DBContext dBContext) : base(dBContext) { }

        public List<OrderType> GetOrderTypes()
        {
            return DBContext.types_of_orders.ToList();
        }

        public List<OrderType> GetOrderTypesLike(string pattern)
        {
            return DBContext.types_of_orders.Where(data => data.Name.Contains(pattern)).ToList();
        }

        public OrderType AddOrderType(string orderType)
        {
            int maxId = DBContext.types_of_orders.Any() ? DBContext.types_of_orders.Max(s => s.Id) : 0;

            OrderType newOrderType = new OrderType
            {
                Id = maxId + 1,
                Name = orderType
            };

            DBContext.types_of_orders.Add(newOrderType);

            return newOrderType;
        }

        public void DeleteOrderType(OrderType orderType)
        {
            DBContext.types_of_orders.Remove(orderType);
        }

        public void SaveChanges()
        {
            DBContext.SaveChanges();
        }
    }
}
