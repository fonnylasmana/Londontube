using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LondonTube.Models
{
    public class StationModel
    {
        public string TubeLineName { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
    }
}