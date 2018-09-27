using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShare.Models
{
    public class UserViewModel : BaseEntity
    {
        [Required( ErrorMessage = "A First Name is Required.")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Prompt = "First Name")]
        public string FirstName { get; set; }


        [Required( ErrorMessage = "A Last Name is Required.")]
        [MinLength(2)]
        [RegularExpression(@"^[a-zA-Z]+$")]
        [Display(Prompt = "Last Name")]
        public string LastName { get; set; }


        [Required( ErrorMessage = "A User Name is Required.")]
        [MinLength(2)]
        [Display(Prompt = "User Name")]
        public string UserName { get; set; }


        [Display(Prompt = "Email")]
        [Required( ErrorMessage = "An Email is Required.")]
        [EmailAddress]
        public string Email { get; set; }


        [Required( ErrorMessage = "A Password is Required.")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Password must contain at least 1 number, 1 letter, and 1 special character.")]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password and Confirmation must match.")]
        //[RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$", ErrorMessage = "Password must contain at least 1 number, 1 letter, and 1 special character.")]
        [Display(Prompt = "Confirm Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }


        [Required( ErrorMessage = "A City is Required.")]
        [MinLength(2)]
        [Display(Prompt = "City")]
        public string City { get; set; }


        [Required( ErrorMessage = "A State is Required.")]
        [MinLength(2)]
        [Display(Prompt = "State")]
        public string State { get; set; }

    }
}