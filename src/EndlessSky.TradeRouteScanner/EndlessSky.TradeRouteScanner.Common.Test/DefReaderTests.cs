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

            var expectedResult = new DefNode();
            var topNode = new DefNode();
            topNode.Tokens = new DefTokenCollection().Add("level1").Add("t1").Add("t2").Add("t3");
            topNode.ChildNodes.Add(new DefNode()
            {
                Tokens = new DefTokenCollection().Add("level2").Add("t1").Add("t2").Add("t3")
            });
            topNode.ChildNodes.Add(new DefNode()
            {
                Tokens = new DefTokenCollection().Add("level2").Add("t1").Add("t2").Add("t3")
            });
            expectedResult.ChildNodes.Add(topNode);

            Assert.AreEqual(TestUtils.BinarySerialize(expectedResult), TestUtils.BinarySerialize(result));
        }

        [TestMethod]
        public void SomeComments()
        {
            var sampleData = string.Format("{0}\n{1}\n\t{2}\n\t{3}",
                "#This is a comment",
                "level1 t1 t2 #this is another comment",
                "#this is yet another comment",
                "level2 t1 t2"
                );

            var result = new DefReader().LoadDataFromString(sampleData);

            var expectedResult = new DefNode();
            expectedResult.ChildNodes.Add(new DefNode()
            {
                Tokens = new DefTokenCollection().Add("level1").Add("t1").Add("t2")
            });
            expectedResult.ChildNodes.Add(new DefNode()
            {
                Tokens = new DefTokenCollection().Add("level2").Add("t1").Add("t2")
            });

            Assert.AreEqual(TestUtils.BinarySerialize(expectedResult), TestUtils.BinarySerialize(result));
        }
    }
}
