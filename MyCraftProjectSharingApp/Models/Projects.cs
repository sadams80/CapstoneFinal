using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyCraftProjectSharingApp.Models
{
    public class Projects
    {
        public int Project_ID { get; set; }
        public int User_ID { get; set; }
        [Required(ErrorMessage = "Please choose a craft.")]
        [Display(Name = "Craft Type")]
        public int Craft_ID { get; set; }
        [Required(ErrorMessage = "Please enter a project name.")]
        [Display(Name = "Name:")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Please enter instructions.")]
        [MaxLength(100, ErrorMessage = "Must be no longer than 100 characters.")]
        [MinLength(10, ErrorMessage = "Must be 10 characters or longer.")]
        [Display(Name = "Instructions:")]
        public string ProjectBody { get; set; }
        [Required(ErrorMessage = "Please enter a difficulty level.")]
        [Display(Name = "Difficulty:")]
        public int Difficulty_ID { get; set; }
        [Display(Name = "Difficulty:")]
        public string DifficultyLevel { get; set; }
        public string Username { get; set; }
        public string CraftName { get; set; }
    }
}