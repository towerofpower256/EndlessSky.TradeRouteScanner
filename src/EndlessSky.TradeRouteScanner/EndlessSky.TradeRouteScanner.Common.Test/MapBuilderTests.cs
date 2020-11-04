using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using EndlessSky.TradeRouteScanner.Common.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EndlessSky.TradeRouteScanner.Common.Test
{
    [TestClass]
    public class MapBuilderTests
    {
        [TestMethod]
        public void MapBuilder_SimpleRead()
        {
            var sampleDataRoot = new DefNode();

            var sampleDataSystem1 = new DefNode();
            sampleDataRoot.ChildNodes.Add(sampleDataSystem1);
            sampleDataSystem1.Tokens.Add("system").Add("Tarazed");
            sampleDataSystem1.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("belt").Add("1169") });
            sampleDataSystem1.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("link").Add("Enif") });
            sampleDataSystem1.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Clothing").Add("305") });
            sampleDataSystem1.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Electronics").Add("761") });
            sampleDataSystem1.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Equipment").Add("395") });
            sampleDataSystem1.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Food").Add("238") });

            var sampleDataSystem2 = new DefNode();
            sampleDataRoot.ChildNodes.Add(sampleDataSystem2);
            sampleDataSystem2.Tokens.Add("system").Add("Enif");
            sampleDataSystem2.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("belt").Add("1169") });
            sampleDataSystem2.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("link").Add("Tarazed") });
            sampleDataSystem2.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("link").Add("Sadalmelik") });
            sampleDataSystem2.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Clothing").Add("361") });
            sampleDataSystem2.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Electronics").Add("800") });
            sampleDataSystem2.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Equipment").Add("485") });
            sampleDataSystem2.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Food").Add("335") });

            var sampleDataSystem3 = new DefNode();
            sampleDataRoot.ChildNodes.Add(sampleDataSystem3);
            sampleDataSystem3.Tokens.Add("system").Add("Sadalmelik");
            sampleDataSystem3.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("belt").Add("1169") });
            sampleDataSystem3.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("link").Add("Enif") });
            sampleDataSystem3.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Clothing").Add("361") });
            sampleDataSystem3.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Electronics").Add("800") });
            sampleDataSystem3.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Equipment").Add("485") });
            sampleDataSystem3.ChildNodes.Add(new DefNode() { Tokens = new DefTokenCollection().Add("trade").Add("Food").Add("335") });

            var resultMap = new TradeMapBuilder().Build(sampleDataRoot, CancellationToken.None);

            var expectedMap = new TradeMap();

            var tradeSystem1 = new TradeMapSystem();
            expectedMap.Systems.Add(tradeSystem1);
            tradeSystem1.Name = "Tarazed";
            tradeSystem1.Comodities.Add(new TradeMapComodity { Name = "Clothing", Price = 305 });
            tradeSystem1.Comodities.Add(new TradeMapComodity { Name = "Electronics", Price = 761 });
            tradeSystem1.Comodities.Add(new TradeMapComodity { Name = "Equipment", Price = 395 });
            tradeSystem1.Comodities.Add(new TradeMapComodity { Name = "Food", Price = 238 });

            var tradeSystem2 = new TradeMapSystem();
            expectedMap.Systems.Add(tradeSystem2);
            tradeSystem2.Name = "Enif";
            tradeSystem2.Comodities.Add(new TradeMapComodity { Name = "Clothing", Price = 361 });
            tradeSystem2.Comodities.Add(new TradeMapComodity { Name = "Electronics", Price = 800 });
            tradeSystem2.Comodities.Add(new TradeMapComodity { Name = "Equipment", Price = 485 });
            tradeSystem2.Comodities.Add(new TradeMapComodity { Name = "Food", Price = 335 });

            var tradeSystem3 = new TradeMapSystem();
            expectedMap.Systems.Add(tradeSystem3);
            tradeSystem3.Name = "Sadalmelik";
            tradeSystem3.Comodities.Add(new TradeMapComodity { Name = "Clothing", Price = 361 });
            tradeSystem3.Comodities.Add(new TradeMapComodity { Name = "Electronics", Price = 800 });
            tradeSystem3.Comodities.Add(new TradeMapComodity { Name = "Equipment", Price = 485 });
            tradeSystem3.Comodities.Add(new TradeMapComodity { Name = "Food", Price = 335 });

            tradeSystem1.Links.Add(new TradeMapSystemLink() { Name = "Enif", System = tradeSystem2 });
            tradeSystem2.Links.Add(new TradeMapSystemLink() { Name = "Tarazed", System = tradeSystem1 });
            tradeSystem2.Links.Add(new TradeMapSystemLink() { Name = "Sadalmelik", System = tradeSystem3 });
            tradeSystem3.Links.Add(new TradeMapSystemLink() { Name = "Enif", System = tradeSystem2 });

            // TODO assert
        }

        [TestMethod]
        public void MapBuilder_FullRead()
        {
            var sampleDataStream = TestUtils.LoadResourceStream("TestData.MapBuilder_FullMapRead.txt");
            var dataRoot = new DefReader().LoadDataFromStream(sampleDataStream);
            var mapResult = new TradeMapBuilder().Build(dataRoot, CancellationToken.None);
        }
    }
}
