using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;

namespace BaltaStore.Tests.Fakes
{
    /// <summary>
    /// Depender sempre de abstração e nunca de implementação!!!
    /// </summary>
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }

        public CustomerOrdersCountResult GetCustomerOrderesCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetById()
        {
            throw new NotImplementedException();
        }

        public GetCustomerQueryResult GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
