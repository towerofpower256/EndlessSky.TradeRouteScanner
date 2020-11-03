using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EndlessSky.TradeRouteScanner.Common.Test
{
    [TestClass]
    public class RouteScannerTests
    {
        [TestMethod]
        public void FullScan()
        {
            var sampleDataStream = TestUtils.LoadResourceStream("TestData.MapBuilder_PartialMapRead.txt");
            var dataRoot = new DefReader().LoadDataFromStream(sampleDataStream, CancellationToken.None);
            var mapResult = new TradeMapBuilder().Build(dataRoot, CancellationToken.None);

            var routeScanner = new RouteScanner();
            routeScanner.SetLogging(TestUtils.GetTraceLogger());
            var scanResult = routeScanner.Scan(mapResult, new RouteScannerOptions(), CancellationToken.None);
        }
    }
}
