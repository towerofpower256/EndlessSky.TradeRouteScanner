using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using EndlessSky.TradeRouteScanner.Common;
using EndlessSky.TradeRouteScanner.Common.Models;

namespace EndlessSky.TradeRouteScanner.WinForms.Forms
{
    public partial class MainForm : Form
    {
        public char STARTSYSTEMS_DELIM = ',';

        BindingList<string> _defFiles = new BindingList<string>();
        CancellationTokenSource _operationCtSource;
        Task _routeScannerTask;

        public MainForm()
        {
            InitializeComponent();

            lbDefFiles.DataSource = _defFiles;
            ImportRouteScannerOptions(new RouteScannerOptions());
        }

        private void ImportRouteScannerOptions(RouteScannerOptions options)
        {
            txtRunMaxJumps.Text = options.RunMaxJumps.ToString();
            txtRouteMaxStops.Text = options.RouteMaxStops.ToString();
            txtMinProfitPerUnit.Text = options.MinProfitPerUnit.ToString();
            txtMinRouteScore.Text = options.MinRouteScore.ToString();
            cbSingleRoutePerStartSystem.Checked = options.SingleRoutePerStartSystem;
            txtStartSystems.Text = string.Join(STARTSYSTEMS_DELIM.ToString(), options.StartSystems);
        }

        private RouteScannerOptions ExportRouteScannerOptions()
        {
            var options = new RouteScannerOptions();

            options.RunMaxJumps = ParseIntField("RunMaxJumps", txtRunMaxJumps.Text);
            options.RouteMaxStops = ParseIntField("RouteMaxStops", txtRouteMaxStops.Text);
            options.MinProfitPerUnit = ParseIntField("MinProfitPerUnit", txtMinProfitPerUnit.Text);
            options.MinRouteScore = ParseIntField("MinRouteScore", txtMinRouteScore.Text);

            options.StartSystems.Clear();
            var startSystemsArr = txtStartSystems.Text.Split(STARTSYSTEMS_DELIM);
            foreach (var startSystem in startSystemsArr)
            {
                options.StartSystems.Add(startSystem.Trim().ToLower());
            }

            options.SingleRoutePerStartSystem = cbSingleRoutePerStartSystem.Checked;

            return options;
        }

        private int ParseIntField(string fieldName, string input)
        {
            int value;
            if (!int.TryParse(input, out value)) throw new ArgumentOutOfRangeException(fieldName);
            return value;
        }

        private void GenericErrorAlert(string msg, string caption)
        {
            MessageBox.Show(msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public delegate void SetOutputDelegate(string msg);
        public void SetOutput(string msg)
        {
            if (txtOutput.InvokeRequired)
            {
                txtOutput.Invoke(new SetOutputDelegate(SetOutput), new object []{ msg });
                return;
            }

            txtOutput.Text = msg;
        }

        private void AddDefFile(string defFile)
        {
            if (!_defFiles.Contains(defFile)) _defFiles.Add(defFile);
        }

        private void AddDefFiles(IEnumerable<string> defFiles)
        {
            _defFiles.RaiseListChangedEvents = false;
            foreach (var defFile in defFiles)
            {
                if (!_defFiles.Contains(defFile)) _defFiles.Add(defFile);
            }
            _defFiles.RaiseListChangedEvents = true;

            _defFiles.ResetBindings();
        }

        private void RemoveDefFile(string defFile)
        {
            _defFiles.Remove(defFile);
        }

        private void ClearDefFiles()
        {
            _defFiles.Clear();
        }

        private void RemoveSelectedDefFiles()
        {
            RemoveDefFile((string)lbDefFiles.SelectedItem);
        }

        private void AddDefFileDialog()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "Def file|*.txt";
            ofd.Multiselect = true;
            ofd.Title = "Select Endless Sky def file(s)...";
            ofd.CheckFileExists = true;
            ofd.RestoreDirectory = true;
            ofd.ValidateNames = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                AddDefFiles(ofd.FileNames);
            }
        }

        private void DoScan()
        {
            // Validation
            if (_defFiles.Count == 0)
            {
                MessageBox.Show("No def files to read", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            RouteScannerOptions scannerOptions;
            try
            {
                scannerOptions = ExportRouteScannerOptions();
            }
            catch (Exception ex)
            {
                GenericErrorAlert($"Error reading options: {ex.GetType().Name}\n{ex.Message}", "Error reading options");
                return;
            }

            if (scannerOptions.StartSystems.Count == 0 && MessageBox.Show(
                "Specifying no route start systems will scan for routes starting from ALL systems, and will take quite some time. Are you sure you want to do this?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
            {
                return;
            }

            var progForm = new ProgressForm();
            progForm.Text = "Scanning for routes";
            progForm.Show(this);

            //var scannerOptions = new RouteScannerOptions();
            //scannerOptions.StartSystems.Add("Algorel");
            
            var scanner = new ScanWorker(_defFiles, scannerOptions);
            scanner.ProgressEvent += new EventHandler<ProgressEventArgs>((sender, args) =>
            {
                if (args.StatusUpdate && args.Status == ProgressEventStatus.Error)
                {
                    // Something went wrong, show an error message & close the progress form
                    progForm.CloseSafe();
                    MessageBox.Show(args.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } 
                else if (args.StatusUpdate && args.Status == ProgressEventStatus.Complete)
                {
                    // Done here, just close the status
                    progForm.CloseSafe();
                }
                else
                {
                    if (args.ValueUpdate) progForm.SetProgress(args.Value, args.MaxValue);
                    progForm.SetMessage(args.Message);
                }
            });

            //bgWorkerScanner.RunWorkerAsync(scanner);
            //var results = scanner.Scan(_defFiles, new RouteScannerOptions()).ContinueWith((taskResult) => HandleScanResults(taskResult)); // TODO generate options

            _operationCtSource = new CancellationTokenSource();
            progForm.OnCancel += new EventHandler<EventArgs>((sender, args) => _operationCtSource?.Cancel());
            _routeScannerTask = new Task(() =>
            {
                var result = scanner.Scan(_operationCtSource.Token);
                HandleScanResults(result);

            }, _operationCtSource.Token);
            _routeScannerTask.Start();
        }

        private void HandleScanResults(RouteScannerResults results)
        {
            //var results = taskResult.Result;
            if (!results.Successful)
            {
                // Something went wrong
            }
            else
            {
                var orderedRoutes = results.AllRoutes.OrderByDescending(r => r.Score);

                var sb = new StringBuilder();
                sb.AppendLine("=== Top 50 routes ===");
                int i = 0;
                var routeLimit = 50;
                foreach (var route in orderedRoutes)
                {
                    if (i >= routeLimit) break;
                    sb.AppendLine();
                    sb.AppendLine("===========");
                    sb.AppendLine();
                    sb.AppendLine($"Score: {route.Score}");
                    sb.AppendLine($"Start: {route.StartSystem.Name}");
                    sb.AppendLine($"Stops: {route.TotalStops}");
                    sb.AppendLine($"Total profit: {route.TotalProfit}");
                    sb.AppendLine($"Profit per jump: {route.ProfitPerJump}");
                    sb.AppendLine($"Profit per stop: {route.ProfitPerRun}");
                    foreach (var run in route.Runs)
                    {
                        sb.AppendLine($"{run.StartSystemName} -> {run.EndSystem} ({run.Jumps} jumps), {run.Comodity} ${run.Profit} profit");
                    }
                    i++;
                }

                SetOutput(sb.ToString());
            }
        }

        private void btnAddDefFile_Click(object sender, EventArgs e)
        {
            AddDefFileDialog();
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            DoScan();
        }

        private void btnRemoveDefFile_Click(object sender, EventArgs e)
        {
            RemoveSelectedDefFiles();
        }

        private void lbDefFiles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RemoveSelectedDefFiles();
        }

        private async void bgWorkerScanner_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
            var scanner = ((ScanWorker)e.Argument);
            bgWorkerScanner.Cancel
            var result = await scanner.Scan();
            e.Result = result;
            */
        }

        private void bgWorkerScanner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HandleScanResults(e.Result as RouteScannerResults);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _operationCtSource?.Cancel();
        }
    }
}
