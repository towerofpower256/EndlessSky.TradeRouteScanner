using EndlessSky.TradeRouteScanner.Common;
using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndlessSky.TradeRouteScanner.WinForms
{
    public class ScanWorker
    {
        public ScanWorkerState State { get; private set; } = ScanWorkerState.Idle;

        RouteScannerOptions _options;
        IEnumerable<string> _defFiles;

        public event EventHandler<ProgressEventArgs> ProgressEvent;

        public ScanWorker(IEnumerable<string> defFiles, RouteScannerOptions options)
        {
            _defFiles = defFiles;
            _options = options;
        }

        public Task<RouteScannerResults> Scan()
        {
            State = ScanWorkerState.Working;
            try
            {
                // Make the root node
                var rootNode = new DefNode();

                // Read def files
                var defReader = new DefReader();
                defReader.ProgressEvents.ProgressEvent += new EventHandler<ProgressEventArgs>((sender, args) => {
                    DoProgressEvent(sender, args);
                });
                foreach (var filepath in _defFiles)
                    defReader.LoadDataFromFile(filepath, rootNode);

                // Build map
                var mapBuilder = new TradeMapBuilder();
                mapBuilder.ProgressEvents.ProgressEvent += new EventHandler<ProgressEventArgs>((sender, args) => {
                    DoProgressEvent(sender, args);
                });
                var map = mapBuilder.Build(rootNode);

                // Scan for runs & routes
                var tradeScanner = new RouteScanner();
                tradeScanner.ProgressEvents.ProgressEvent += new EventHandler<ProgressEventArgs>((sender, args) => {
                    DoProgressEvent(sender, args);
                });
                var results = tradeScanner.Scan(map, _options);

                DoProgressEvent(this, new ProgressEventArgs(ProgressEventStatus.Complete, "Route scanning complete"));

                // Done
                return Task.FromResult(results);
            }
            catch (Exception ex)
            {
                DoProgressEvent(this, new ProgressEventArgs(ProgressEventStatus.Error, $"An error occurred: {ex.GetType().ToString()}\n{ex.Message}"));
                return Task.FromResult(new RouteScannerResults() { Successful = false });
            }
            finally
            {
                State = ScanWorkerState.Idle;
            }
        }

        private void DoProgressEvent(object sender, ProgressEventArgs args)
        {
            ProgressEvent?.Invoke(sender, args);
        }
    }

    public enum ScanWorkerState
    {
        Idle,
        Working
    }
}
