using EndlessSky.TradeRouteScanner.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EndlessSky.TradeRouteScanner.Common
{
    public class TradeMapBuilder
    {
        public const string NODE_NAME_SYSTEM = "system";
        public const string NODE_NAME_LINK = "link";
        public const string NODE_NAME_TRADE = "trade";

        public ProgressEventSource ProgressEvents = new ProgressEventSource();

        public TradeMap Build(DefNode rootNode)
        {
            //ProgressEvents.DoEvent(this, new ProgressEventArgs("Starting map load"));
            var map = CreateMap(rootNode);

            // TODO handle map with no systems

            ProgressEvents.DoEvent(this, new ProgressEventArgs(0, 0, ProgressEventStatus.Working, $"Completing links..."));
            CompleteLinks(map);

            ProgressEvents.DoEvent(this, new ProgressEventArgs(ProgressEventStatus.Complete, "Map building complete"));
            return map;
        }

        public TradeMap CreateMap(DefNode rootNode)
        {
            var map = new TradeMap();

            //foreach (var topNode in rootNode.ChildNodes)
            for (int iNode=0; iNode < rootNode.ChildNodes.Count; iNode++) 
            {
                ProgressEvents.DoEvent(this, new ProgressEventArgs(iNode, rootNode.ChildNodes.Count, ProgressEventStatus.Working, $"Reading node {iNode}"));
                var topNode = rootNode.ChildNodes[iNode];
                // Only care about "system" nodes
                if (topNode.Tokens.Count >= 2 && topNode.Tokens[0] == NODE_NAME_SYSTEM)
                {
                    // Is a system node
                    var newSystem = new TradeMapSystem();
                    newSystem.Name = topNode.Tokens[1];
                    // TODO handle blank system name

                    foreach (var subNode in topNode.ChildNodes)
                    {
                        if (subNode.Tokens.Count >= 2 && subNode.Tokens[0] == NODE_NAME_LINK)
                        {
                            // TODO handle blank system name in link
                            newSystem.Links.Add(new TradeMapSystemLink() { Name = subNode.Tokens[1] });
                        }

                        if (subNode.Tokens.Count >= 3 && subNode.Tokens[0] == NODE_NAME_TRADE)
                        {
                            int tradePrice;
                            if (!int.TryParse(subNode.Tokens[2], out tradePrice))
                            {
                                // TODO Handle bad number on trade price
                            }
                            else
                            {
                                // TODO handle empty comodity name
                                newSystem.Comodities.Add(new TradeMapComodity() { Name = subNode.Tokens[1], Price = tradePrice });
                            }
                        }
                    }

                    newSystem.Name = newSystem.Name.Trim();
                    map.Systems.Add(newSystem);
                }
                else
                {
                    // skipping node I don't care about, like "galaxy" or "planet"
                }
            }

            return map;
        }

        public TradeMap CompleteLinks(TradeMap map)
        {
            // Update the object links in system links

            foreach (var system in map.Systems)
            {
                foreach (var link in system.Links)
                {
                    if (!string.IsNullOrEmpty(link.Name) && link.System == null)
                    {
                        // If there's a name in the link, and this link hasn't been completed yet, update it.

                        // Search for the system
                        foreach (var fSystem in map.Systems)
                        {
                            if (link.Name == fSystem.Name)
                            {
                                // Found match
                                link.System = fSystem;

                                // Update the opposite link on the other system, while we're here
                                foreach (var fLink in fSystem.Links)
                                {
                                    if (fLink.Name == system.Name) fLink.System = system;
                                }
                            }
                        }
                    }
                }
            }

            return map;
        }
    }
}
