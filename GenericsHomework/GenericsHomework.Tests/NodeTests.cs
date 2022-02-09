using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void ToString_ReturnsStringValue()
        {
            Node<string> node = new("value");
            Assert.AreEqual("value", node.ToString());
        }
    }
}