using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace LondonTubeDB.Model
{
    [Table("TubeLine")]
    public class TubeLine
    {
        [Key]
        public int TubeLineId { get; set;}

        [Display(Name = "Tube Line Name")]
        public string TubeLineName { get; set; }

        [Display(Name = "From Station")]
        public string FromStation { get; set; }

        [Display(Name = "To Station")]
        public string ToStation { get; set; }

        [Display(Name = "Express")]
        public bool Express { get; set; }

    }
}


