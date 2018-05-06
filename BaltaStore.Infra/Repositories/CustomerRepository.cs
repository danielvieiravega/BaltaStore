using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Infra.DataContext;
using Dapper;

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
            return _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new {Document = document},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        //public bool CheckDocumentSelectPuro(string document)
        //{
        //    return _context
        //        .Connection
        //        .Query<bool>(
        //            "select * from customer where document=@document",
        //            new { document })
        //        .FirstOrDefault();
        //}

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return _context
                .Connection
                .Query<CustomerOrdersCountResult>(
                    "spGetCustomerOrdersCount",
                    new { Document = document },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email },
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
                new
                {
                    Id = customer.Id,
                    FirstName = customer.Name.FirstName,
                    LastName = customer.Name.LastName,
                    Document = customer.Document.Number,
                    Email = customer.Email.Address,
                    Phone = customer.Phone
                }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                    new
                    {
                        Id = address.Id,
                        CustomerId = customer.Id,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        State = address.State,
                        Country = address.Country,
                        ZipCode = address.ZipCode,
                        Type = address.Type,
                    }, commandType: CommandType.StoredProcedure);
            }
        }

        public CustomerOrdersCountResult GetCustomerOrderesCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrdersQueryResult> GetById()
        {
            return _context
                .Connection
                .Query<ListCustomerOrdersQueryResult>(
                    "select [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Document], [Email] from [customer]", new {});
        }

        public GetCustomerQueryResult GetById(Guid id)
        {
            return _context
                .Connection
                .Query<GetCustomerQueryResult>(
                    "select [Id], CONCAT([FirstName], ' ', [LastName]) AS [Name], [Document], [Email] from [customer] WHERE [Id] =@id", new { id = id})
                .FirstOrDefault();
        }

        public IEnumerable<ListCustomerOrdersResult> GetOrders(Guid id)
        {
            return _context
                .Connection
                .Query<ListCustomerOrdersResult>(
                    "", new { id = id });
        }
    }
}