using System.ComponentModel.DataAnnotations;

namespace eMovie.Data.DTOs
{
    public class CinemaDTO
    {
        [Display(Name = "Logo")]
        public string Logo { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
    }
}
