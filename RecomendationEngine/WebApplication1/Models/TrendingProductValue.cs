using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class TrendingProductValue
    {
        public int websiteTraffic { get; set; }
        public int internalRank { get; set; }
        public string website { get; set; }
        public string imageLink { get; set; }
        public float rating { get; set; }
        public int numberOfBuys { get; set; }
        public int numberOfTimesGoogleSearched { get; set; }
        public double totalValue { get; set; }


        public double findTotalValue(int websiteTraffic, int internalRank, float rating, int numberOfBuys, int numberOfTimesGoogleSearched)
        {
            int websiteRank = 501 - websiteTraffic;
            double totalValue = (((double)websiteRank / 500) * 100) * 50 + (((double)(11-internalRank) / 10) * 100) * 50;
            return totalValue;
        }
    }
}