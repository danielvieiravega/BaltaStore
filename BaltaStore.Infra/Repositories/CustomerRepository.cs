using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.DataContext;

namespace BaltaStore.Infra.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BaltaDataContext _context;

        public CustomerRepository(BaltaDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            throw new System.NotImplementedException();
        }

        public bool CheckEmail(string email)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {
            throw new System.NotImplementedException();
        }
    }
}
