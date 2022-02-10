using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace GenericsHomework.Tests
{
    [TestClass]
    public class NodeTests
    {

        [TestMethod]
        public void ToString_ReturnsStringValue()
        {
            Node<string> node = new("value");
            var result = node.ToString();
            if (result == null) result = "null";
            Assert.AreEqual<string>("value", result);
        }

        [TestMethod]
        public void Append_GivenNewValues_Success()
        {
            Node<string> node = GetNodes();

            Assert.IsTrue(node.Exists("Baggy"));
        }

        [TestMethod]
        public void Append_GivenDuplicateValue_ThrowsException()
        {
            Node<int> node = new(1);

            Assert.ThrowsException<ArgumentException>(() =>
            {
                node.Append(1);
            });
        }

        [TestMethod]
        public void Clear_GivenOneNode_DoesNothing()
        {
            Node<string> node = new("node");

            node.Clear();

            Assert.IsTrue(node.Exists("node"));
        }

        [TestMethod]
        public void Clear_GivenThreeNodes_Success()
        {
            Node<string> node = GetNodes();

            node.Clear();

            Assert.IsFalse(node.Exists("value2"));
            Assert.IsFalse(node.Exists("Baggy"));
            Assert.IsFalse(node.Exists("hi"));
            Assert.IsTrue(node.Exists("value"));
        }

        private static Node<string> GetNodes()
        {
            Node<string> node = new("value");

            node.Append("value2");
            node.Append("Baggy");
            node.Append("hi");
            return node;
        }
    }
}