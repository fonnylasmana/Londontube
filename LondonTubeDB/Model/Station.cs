using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace LondonTubeDB.Model
{
    [Table("Station")]
    public class Station
    {
        [Key]
        public int StationId { get; set; }

        [Display(Name = "Station Name")]
        public string StationName { get; set; }

        [Display(Name = "OS X")]
        public int? OSX { get; set; }

        [Display(Name = "OS Y")]
        public int? OSY { get; set; }

        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Zone{ get; set; }

        public string Postcode { get; set; }

    }
}

