﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chart
{
    public class industry
    {
        public class indusrtyChart
        {            
            public string name { get; set; }
            public string y { get; set; }
            public int SiteID { get; set; }
        }
        public class MixChart
        {
            public string DepositTodayPercent { get; set; }
            public string TopFiveStockTodayPercent { get; set; }
            public string CashTodayPercent { get; set; }
            public string OtherAssetTodayPercent { get; set; }
            public string BondTodayPercent { get; set; }
            public string OtherStock { get; set; }
            public string JalaliDate { get; set; }
        }
        public class NAVchart
        {
            public string JalaliDate { get; set; }
            public string PurchaseNAVPerShare { get; set; }
            public string SellNAVPerShare { get; set; }
            public string StatisticalNAVPerShare { get; set; }
        }
        public class PureChart
        {
            public string NAV { get; set; }
            public string JalaliDate { get; set; }
            public string PurchaseNAVPerShare { get; set; }
        }
        public class Site
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Href { get; set; }
           
        }

    }
}
