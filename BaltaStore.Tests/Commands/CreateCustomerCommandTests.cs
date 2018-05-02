using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.Commands
{
    [TestClass]
    public class CreatecustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidateWhencommandIsValid()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Daniel",
                LastName = "Daniel",
                Document = "16552251033",
                Email = "daniel@vega.com",
                Phone = "11565622626"
            };

            Assert.AreEqual(true, command.Valid());
        }
    }
}
