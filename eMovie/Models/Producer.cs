﻿using System.ComponentModel.DataAnnotations;

namespace eMovie.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Profile Picture URL")]
        public string ProfilePictureURL { get; set; }
        [Display(Name ="FullName")]
        public string FullName { get; set; }
        [Display(Name ="Biography")]
        public string Bio { get; set; }

        //Relationships
        public List<Movie> Movies { get; set; }
    }
}
