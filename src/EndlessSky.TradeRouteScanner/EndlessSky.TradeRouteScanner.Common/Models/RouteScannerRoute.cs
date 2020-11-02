using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common.Models
{
    public class RouteScannerRoute
    {
        private const int SCORE_RUN_COUNT_PENALTY = 5;

        public TradeMapSystem StartSystem { get; set; }

        public RouteScannerRunCollection Runs { get; set; } = new RouteScannerRunCollection();

        public int TotalProfit { get; set; }

        public int TotalJumps { get; set; }

        public int TotalStops => Runs.Count;

        public float ProfitPerRun { get; set; }

        public float ProfitPerJump { get; set; }

        public float Score { get; set; }

        public string Hash { get; set; } // Hash summary of route. Used to try to detect if 2 routes are the same, but starting from different systems.

        public new string ToString()
        {
            return $"{StartSystem}, Runs:{Runs.Count}, PPR:{ProfitPerRun}, Score:{Score}";
        }

        public void Update()
        {
            GenerateHash();

            int totalProfit = 0;
            int totalJumps = 0;
            float pps = 0.0f;
            float ppj = 0.0f;
            foreach (var run in this.Runs)
            {
                totalProfit += run.Profit;
                totalJumps += run.Jumps;
            }

            pps = totalProfit / Runs.Count;
            ppj = totalProfit / totalJumps;

            TotalProfit = totalProfit;
            TotalJumps = totalJumps;
            ProfitPerRun = pps;
            ProfitPerJump = ppj;

            CalculateScore();
        }

        // This is my attempt at prioritising some routes over others.
        // Originally, I wanted shorter but very profitable routes to be more sought after than longer and not as profitable routes.
        private void CalculateScore()
        {
            Score = ProfitPerRun - (SCORE_RUN_COUNT_PENALTY * Runs.Count);
        }

        private void GenerateHash()
        {
            // Generate a hash of the runs in the route.
            // A route that has the same runs but in a different order should result in the same hash.

            // Create the string
            var runs = new List<string>();
            foreach (var run in Runs)
            {
                runs.Add($"{run.StartSystemName},{run.EndSystemName},{run.Comodity}");
            }
            runs.Sort();

            // MD5 it
            using (var md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(string.Join("|", runs));
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                var sb = new StringBuilder();
                for (int i=0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }

                Hash = sb.ToString();
            }
        }
    }
}
