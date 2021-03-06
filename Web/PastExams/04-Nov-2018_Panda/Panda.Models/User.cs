﻿namespace Panda.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.Packages = new HashSet<Package>();
            this.Receipts = new HashSet<Receipt>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [MaxLength(20)]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public virtual ICollection<Package> Packages { get; set; }

        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
