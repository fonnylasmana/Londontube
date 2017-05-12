using LondonTubeDB.Context;
using LondonTubeDB.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace LondonTube.Helper
{
    public class HTMLHelper
    {
        public List<CustomListItem> GetStations()
        {
            LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);
            IEnumerable<Station> ss = new List<Station>();
            ss = (from sts in dc.Stations
                  select sts).ToList();
            List<CustomListItem> cli = new List<CustomListItem>();
            foreach (var e in ss)
            {
                CustomListItem c = new CustomListItem();
                c.text = e.StationName;
                c.value = e.StationId;
                cli.Add(c);
            }
            return cli.OrderBy(cl => cl.text).ToList();
        }

        public List<CustomListItem> GetTubeLines()
        {
            LTContext dc = new LTContext(ConfigurationManager.ConnectionStrings["LondonTube"].ConnectionString);
            IEnumerable<TubeLine> ts = new List<TubeLine>();
            ts = (from tls in dc.TubeLines
                  orderby tls.TubeLineName
                  select tls).ToList();
            List<CustomListItem> cli = new List<CustomListItem>();
            foreach (var e in ts)
            {
                CustomListItem c = new CustomListItem();
                c.text = e.TubeLineName;
                c.value = e.TubeLineId;
                cli.Add(c);
            }
            return cli.OrderBy(cl => cl.text).ToList();
        }

        public class CustomListItem
        {
            public int value { get; set; }
            public string text { get; set; }
        }
    }
}