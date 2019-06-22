﻿namespace FDMC.App.Models
{
    using System.ComponentModel.DataAnnotations;

    public class CreateCatInputModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public string Breed { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
