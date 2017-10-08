using DXCoreSampleApp.Common.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DXCoreSample.Common.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateNewContact()
        {
            var contact = new Contact
            {
                FirstName = "Anish",
                LastName = "Martin",
                Mobile = "559 555 5599",
                Email = "Anish@test.com",
                TenantId = 1
            };
        }
    }
}
