using System.ComponentModel.DataAnnotations;

namespace eMovie.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Profile Picture")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }

        //Relationships
        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
