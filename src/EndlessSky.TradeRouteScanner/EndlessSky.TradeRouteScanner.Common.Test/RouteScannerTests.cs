using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EndlessSky.TradeRouteScanner.Common.Test
{
    [TestClass]
    public class RouteScannerTests
    {
        [TestMethod]
        public void FullScan()
        {
            var sampleDataStream = TestUtils.LoadResourceStream("TestData.MapBuilder_FullMapRead.txt");
            var dataRoot = new DefReader().LoadDataFromStream(sampleDataStream);
            var mapResult = new TradeMapBuilder().Build(dataRoot);

            var routeScanner = new RouteScanner();
            routeScanner.SetLogging(TestUtils.GetTraceLogger());
            var scanResult = routeScanner.Scan(mapResult);
        }
    }
}
