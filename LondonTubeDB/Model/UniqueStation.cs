using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;


namespace LondonTubeDB.Model
{
    [Table("UniqueStation")]
    public class UniqueStation
    {
        [Key]
        public int UniqueStationId { get; set; }

        [Display(Name = "Unique Station Name")]
        public string UniqueStationName { get; set; }
    }
}