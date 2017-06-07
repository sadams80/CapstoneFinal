using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyCraftProjectSharingApp.Models
{
    public class Crafts
    {
        public int Craft_ID { get; set; }
        [Required(ErrorMessage = "Please enter a craft name.")]
        [MaxLength(30, ErrorMessage = "Must be no longer than 30 characters.")]
        [MinLength(3, ErrorMessage = "Must be 3 characters or longer.")]
        [Display(Name = "Craft Name")]
        public string CraftName { get; set; }
        [Required(ErrorMessage = "Please enter a description.")]
        [MaxLength(200, ErrorMessage = "Must be no longer than 200 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; }
        public int User_ID { get; set; }
        public string Username { get; set; }
    }
}