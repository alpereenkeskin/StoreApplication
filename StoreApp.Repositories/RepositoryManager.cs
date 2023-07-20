using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Repositories.Concrete;

namespace StoreApp.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly RepositoryDbContext _context;
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;


        public RepositoryManager(RepositoryDbContext context, IProductRepository productRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository OrderRepository => _orderRepository;

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}