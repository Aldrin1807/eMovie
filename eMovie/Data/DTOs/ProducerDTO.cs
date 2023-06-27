using System.ComponentModel.DataAnnotations;

namespace eMovie.Data.DTOs
{
    public class ProducerDTO
    {
        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }
        [Display(Name = "FullName")]
        public string FullName { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
    }
}
