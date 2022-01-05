﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CW2.Shared
{
    public class User
    {
        [Key]
        public int UserId { get; set; } = 0;

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The User Name should be 3-30 characters.")]
        public string UserName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "The User Name should be 3-10 characters.")]
        public string Password { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The First Name should be 3-30 characters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The Last Name should be 3-30 characters.")]
        public string LastName { get; set; }

        [EmailAddress]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "The User Name should be 3-30 characters.")]
        public string UserEmail { get; set; }

        [Phone]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "The User Phone number should have 10 digits.")]
        public string UserPhoneNo { get; set; }

        [Required(ErrorMessage = "Select the User Type")]
        public string UserType { get; set; }

        [Required(ErrorMessage = "Enter the correct company name")]
        public string CompanyName { get; set; }

        //public Company Company { get; set; }
    }
}
