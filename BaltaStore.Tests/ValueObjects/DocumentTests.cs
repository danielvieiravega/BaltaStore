using BaltaStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BaltaStore.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        private readonly Document _validDocument = new Document("43477062272");
        private readonly Document _invalidDocument = new Document("fsfsafefaewg");

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsNotValid()
        {
            Assert.AreEqual(false, _invalidDocument.IsValid);
        }

        [TestMethod]
        public void ShouldReturnNoNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, _validDocument.IsValid);
            Assert.AreEqual(0, _validDocument.Notifications.Count);
        }
    }
}
