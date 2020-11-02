using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EndlessSky.TradeRouteScanner.Common;
using EndlessSky.TradeRouteScanner.Common.Models;

namespace EndlessSky.TradeRouteScanner.WinForms.Forms
{
    public partial class MainForm : Form
    {
        BindingList<string> _defFiles = new BindingList<string>();

        public MainForm()
        {
            InitializeComponent();

            lbDefFiles.DataSource = _defFiles;
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
            if (_defFiles.Count == 0)
            {
                MessageBox.Show("No def files to read", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var progForm = new ProgressForm();
            progForm.Text = "Scanning for routes";
            progForm.Show(this);

            var scannerOptions = new RouteScannerOptions();
            scannerOptions.StartSystems.Add("Algorel");
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

            bgWorkerScanner.RunWorkerAsync(scanner);
            //var results = scanner.Scan(_defFiles, new RouteScannerOptions()).ContinueWith((taskResult) => HandleScanResults(taskResult)); // TODO generate options

            
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

            var scanner = ((ScanWorker)e.Argument);
            var result = await scanner.Scan();
            e.Result = result;
        }

        private void bgWorkerScanner_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            HandleScanResults(e.Result as RouteScannerResults);
        }
    }
}
