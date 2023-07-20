using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entites;
using StoreApp.Repositories.Concrete;

namespace StoreApp.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(RepositoryDbContext context) : base(context)
        {
        }

        public IQueryable<Order> Orders => _context.Orders
        .Include(x => x.CartLines)
        .ThenInclude(x => x.Product)
        .OrderBy(x => x.Shipped)
        .ThenByDescending(x => x.OrderId);

        public int NumberOfInProcess =>
        _context.Orders.Count(x => x.Shipped.Equals(false));

        public void Complete(int id)
        {
            var order = FindByCondition(x => x.OrderId == id, true);
            if (order is null)
                throw new Exception("Order could not found");
            order.Shipped = true;
        }

        public Order? GetOneOrder(int id)
        {
            return FindByCondition(x => x.OrderId == id, false);
        }

        public void SaveOrder(Order order)
        {
            _context.AttachRange(order.CartLines.Select(x => x.Product));
            if (order.OrderId == 0)
                _context.Orders.Add(order);
            //_context.AttachRange(...) Bu kısım, önceki adımda seçilen "Product" nesnelerini "_context" adlı DbContext nesnesine eklemeyi sağlar. "AttachRange" yöntemi, verilen nesneleri takip etmeye alır ve onları veritabanı değişiklikleriyle senkronize eder. Ancak, değişiklikleri otomatik olarak kaydetmez.Sonuç olarak, _context.AttachRange(order.CartLines.Select(x => x.Product)); ifadesi, bir siparişin "CartLines" koleksiyonundaki "Product" nesnelerini veritabanına bağlamak için kullanılır. Bu, ilişkili "Product" nesnelerini değişiklikleri takip etmek ve diğer veritabanı işlemleri için hazır hale getirmek için önemlidir. Ancak, bu işlemle yapılan değişikliklerin veritabanına kaydedilmesi için ayrıca _context.SaveChanges(); yöntemi kullanılmalıdır.
        }
    }
}