using System;
using System.Collections.Generic;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Handlers;
using BaltaStore.Domain.StoreContext.Queries;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BaltaStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpGet]
        [Route("v1/customers")]
        [ResponseCache(Duration = 60)] //Cache-Control: public, max-age=60
        public IEnumerable<ListCustomerOrdersQueryResult> Get()
        {
            return _repository.GetById();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetByDocument(Guid document)
        {
            return _repository.GetById(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrdersResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            return _handler.Handle(command) as CreateCustomerCommandResult;
        }

        //[HttpPut]
        //[Route("customers/{id}")]
        //public Customer Put([FromBody] CreateCustomerCommand command)
        //{
        //    var name = new Name(command.FirstName, command.LastName);
        //    var document = new Document(command.Document);
        //    var email = new Email(command.Email);
        //    var customer = new Customer(name, document, email, command.Phone);

        //    return customer;
        //}

        //[HttpDelete]
        //[Route("customers/{id}")]
        //public object Delete()
        //{
        //    return new {message ="Cliente removido com sucesso"};
        //}
    }
}