using System;
using System.Collections.Generic;
using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            new ValidationContract()
                .HasLen(Customer.ToString(), 36, nameof(Customer), "O identificador do cliente é inválido")
                .IsGreaterThan(OrderItems.Count, 0, nameof(OrderItems), "Nenhum item do pedido encontrado");

            return IsValid;
        }
    }
}
