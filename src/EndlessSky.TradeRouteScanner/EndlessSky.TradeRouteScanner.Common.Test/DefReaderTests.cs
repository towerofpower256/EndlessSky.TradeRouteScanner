using Microsoft.VisualStudio.TestTools.UnitTesting;
using EndlessSky.TradeRouteScanner.Common;
using EndlessSky.TradeRouteScanner.Common.Models;

namespace EndlessSky.TradeRouteScanner.Common.Test
{
    [TestClass]
    public class DefReaderTests
    {
        [TestMethod]
        public void SimpleRead()
        {
            var sampleData = string.Format("{0}\n\t{1}\n\t{2}",
                "level1 t1 \"t2\" `t3`",
                "level2 \"t1\" t2 `t3`",
                "level2 t1 `t2` \"t3\""
                );


            var result = new DefReader().LoadDataFromString(sampleData);

            var expectedRootNode = new DefNode();
            var l1node = new DefNode();
            l1node.Tokens = new DefTokenCollection().Add("level1").Add("t1").Add("t2").Add("t3");
            l1node.ChildNodes.Add(new DefNode()
            {
                Tokens = new DefTokenCollection().Add("level2").Add("t1").Add("t2").Add("t3")
            });
            l1node.ChildNodes.Add(new DefNode()
            {
                Tokens = new DefTokenCollection().Add("level2").Add("t1").Add("t2").Add("t3")
            });
            expectedRootNode.ChildNodes.Add(l1node);

            var expectedResult = TestUtils.JsonSerialize(expectedRootNode);
            var actualResult = TestUtils.JsonSerialize(result);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void SomeComments()
        {
            var sampleData = string.Format("{0}\n{1}\n\t{2}\n\t{3}",
                "#This is a comment",
                "node1 t1 t2 #this is another comment",
                "#this is yet another comment",
                "node2 t1 t2"
                );

            var result = new DefReader().LoadDataFromString(sampleData);

            var expectedResult = new DefNode();
            var node1 = new DefNode();
            node1.Tokens.Add("node1").Add("t1").Add("t2");
            expectedResult.ChildNodes.Add(node1);
            var node2 = new DefNode();
            node2.Tokens.Add("node2").Add("t1").Add("t2");
            node1.ChildNodes.Add(node2);

            Assert.AreEqual(TestUtils.JsonSerialize(expectedResult), TestUtils.JsonSerialize(result));
        }
    }
}
