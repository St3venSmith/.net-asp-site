using System.ComponentModel.DataAnnotations;

namespace InClass6s.Models
{
    public class Activitys
    {
        [Key]
        public int activityID { get; set; }
        public string activityName { get; set; }
        public string activityDescription { get; set; }
        public string activityLocation { get; set; }
        public string activityType { get; set; }

        [Range(1, 6, ErrorMessage = "Difficulty must be between 1 and 6.")]
        public int fireteamSize { get; set; }

        
        public string difficulty { get; set; }

        public bool isMatchMade { get; set; }
    }
}
