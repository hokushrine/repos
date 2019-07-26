using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithModel.Models
{
    public class SurveyModel
    {
        [Required]
        [MinLength(2, ErrorMessage="Name must be 2 or more characters")]
        public string Name {get; set;}

        [Required]
        public string Favorite {get; set;}

        [Required]
        public string Location {get; set;}
        [MaxLength(20, ErrorMessage="Comment cannot be longer than 20 characters")]
        public string Comment {get; set;}
    }
}