using EndlessSky.TradeRouteScanner.Common;
using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        //public Task<RouteScannerResults> Scan(CancellationToken ct)
        public RouteScannerResults Scan(CancellationToken ct)
        {
            State = ScanWorkerState.Working;
            try
            {
                ct.ThrowIfCancellationRequested();

                // Make the root node
                var rootNode = new DefNode();

                // Read def files
                var defReader = new DefReader();
                defReader.ProgressEvents.ProgressEvent += new EventHandler<ProgressEventArgs>((sender, args) => {
                    DoProgressEvent(sender, args);
                });
                foreach (var filepath in _defFiles)
                {
                    ct.ThrowIfCancellationRequested();
                    defReader.LoadDataFromFile(filepath, rootNode, ct);
                }
                    

                // Build map
                var mapBuilder = new TradeMapBuilder();
                mapBuilder.ProgressEvents.ProgressEvent += new EventHandler<ProgressEventArgs>((sender, args) => {
                    DoProgressEvent(sender, args);
                });
                ct.ThrowIfCancellationRequested();
                var map = mapBuilder.Build(rootNode, ct);

                // Check that there are systems in the map
                if (map.Systems.Count == 0)
                {
                    DoProgressEvent(this, new ProgressEventArgs(ProgressEventStatus.Error, "No systems were found. Are the correct def files selected?"));
                    //return Task.FromResult(new RouteScannerResults() { Successful = false });
                    return new RouteScannerResults() { Successful = false };
                }

                // Scan for runs & routes
                var tradeScanner = new RouteScanner();
                tradeScanner.ProgressEvents.ProgressEvent += new EventHandler<ProgressEventArgs>((sender, args) => {
                    DoProgressEvent(sender, args);
                });
                ct.ThrowIfCancellationRequested();
                var results = tradeScanner.Scan(map, _options, ct);

                DoProgressEvent(this, new ProgressEventArgs(ProgressEventStatus.Complete, "Route scanning complete"));

                // Done
                //return Task.FromResult(results);
                return results;
            }
            catch (OperationCanceledException)
            {
                // Operation was cancelled. Stop gracefully.

                DoProgressEvent(this, new ProgressEventArgs(ProgressEventStatus.Complete, "Cancelled"));
                //return Task.FromResult(new RouteScannerResults() { Successful = false });
                return new RouteScannerResults() { Successful = false };
            }
            catch (Exception ex)
            {
                DoProgressEvent(this, new ProgressEventArgs(ProgressEventStatus.Error, $"An error occurred: {ex.GetType().ToString()}\n{ex.Message}"));
                //return Task.FromResult(new RouteScannerResults() { Successful = false });
                return new RouteScannerResults() { Successful = false };
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
