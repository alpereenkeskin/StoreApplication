using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entites;
using StoreApp.Repositories.Concrete;
using StoreApp.Services.Concrete;

namespace StoreApp.Services
{
    public class OrderManager : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IQueryable<Order> Orders => _repositoryManager.OrderRepository.Orders;

        public int NumberOfInProcess => _repositoryManager.OrderRepository.NumberOfInProcess;

        public void Complete(int id)
        {
            _repositoryManager.OrderRepository.Complete(id);
            _repositoryManager.Save();
        }

        public Order? GetOneOrder(int id)
        {
            return _repositoryManager.OrderRepository.GetOneOrder(id);
        }

        public void SaveOrder(Order order)
        {
            _repositoryManager.OrderRepository.SaveOrder(order);
            _repositoryManager.Save();
        }
    }
}