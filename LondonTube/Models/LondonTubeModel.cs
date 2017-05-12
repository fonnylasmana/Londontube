using LondonTubeDB.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LondonTube.Models
{
    public class LondonTubeModel
    {

        [Required(ErrorMessage = "Please select station")]
        public int StationId { get; set; }
        [Required(ErrorMessage = "Please insert number of station")]
        public int NoOfStation { get; set; }
        public List<StationModel> StationModelList { get; set; }
    }
}