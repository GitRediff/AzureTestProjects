using Microsoft.VisualStudio.TestTools.UnitTesting;
using HttpTrigger;
using Microsoft.AspNetCore.Mvc;

namespace HttpTriggerTest
{
    [TestClass]
    public class UtHTFunction
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                var output = HTFunction.Run(TestFactory.CreateHttpRequest("name", "PraBho"));
                Assert.AreEqual("Hello PraBho", ((OkObjectResult)output.Result).Value);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}