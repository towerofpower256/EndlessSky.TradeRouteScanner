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

        public new string ToString()
        {
            return $"{StartSystem}, Runs:{Runs.Count}, PPR:{ProfitPerRun}, Score:{Score}";
        }

        public void Update()
        {
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
    }
}
