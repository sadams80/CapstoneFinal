using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyCraftProjectSharingApp.Models
{
    public class Users
    {
        public int User_ID { get; set; }
        [MaxLength(20, ErrorMessage = "Must be no longer than 20 characters.")]
        [MinLength(3, ErrorMessage = "Must be longer than 3 characters.")]
        [RegularExpression(@"^[a-zA-Z-'\s]+$", ErrorMessage = "Numbers and symbols are not allowed.")]
        [Display(Name = "First Name:")]
        public string FirstName { get; set; }
        [MaxLength(25, ErrorMessage = "Must be no longer than 25 characters.")]
        [MinLength(3, ErrorMessage = "Must be longer than 3 characters.")]
        [RegularExpression(@"^[a-zA-Z-'\s]+$", ErrorMessage = "Numbers and symbols are not allowed.")]
        [Display(Name = "Last Name:")]
        public string LastName { get; set; }
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers allowed.")]
        [Display(Name = "Age:")]
        public int? Age { get; set; }
        [Display(Name = "Gender:")]
        public string Gender { get; set; }
        [MaxLength(100, ErrorMessage = "Must be no longer than 100 characters.")]
        [MinLength(10, ErrorMessage = "Must be 10 characters or longer.")]
        [EmailAddress]
        [RegularExpression(@"^([a-z0-9][-a-z0-9_\+\.]*[a-z0-9])@([a-z0-9][-a-z0-9\.]*[a-z0-9]\.(com|edu|net|org)|([0-9]{1,3}\.{3}[0-9]{1,3}))", ErrorMessage = "Only a valid extension can be input - .com, .net, .org ,.edu")]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter a username.")]
        [MaxLength(20, ErrorMessage = "Must be no longer than 20 characters.")]
        [MinLength(5, ErrorMessage = "Must be longer than 5 characters.")]
        [RegularExpression(@"^[a-zA-Z-'.\s]+$", ErrorMessage = "Numbers and symbols are not allowed.")]
        [Display(Name = "Username:")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password.")]
        [MaxLength(15, ErrorMessage = "Must be no longer than 15 characters.")]
        [MinLength(8, ErrorMessage = "Must be 8 characters or longer.")]
        [RegularExpression(@"^(?=.{8,})(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&+=]).*$", ErrorMessage = "You must have at least one uppercase and one special character.")]
        [Display(Name = "Password:")]
        public string Password { get; set; }
        [Display(Name = "House:")]
        public int House_ID { get; set; }
        public string HouseName { get; set; }
        [Display(Name = "User Type:")]
        public int Role_ID { get; set; }
        public string RoleName { get; set; }
    }
}