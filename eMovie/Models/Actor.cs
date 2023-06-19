using System.ComponentModel.DataAnnotations;

namespace eMovie.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        public string ProfilePictureURL { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }

        //Relationships
        //Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
