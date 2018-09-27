using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShare.Models
{
    public class FruitViewModel : BaseEntity
    {
        [Required( ErrorMessage = "You must enter a fruit, in order to share fruit.")]
        [MinLength(2)]
        [Display(Prompt = "Name of Fruit, such as Cherries, Apples, Plums, etc.")]
        public string FruitName { get; set; }

        [Required( ErrorMessage = "Please let us know exactly what type of fruit you're sharing, or at least a basic description.")]
        [MinLength(2)]
        [Display(Prompt = "Type of Fruit, such as Bing, Granny Smith, Dark, Red, etc.")]
        public string FruitType { get; set; }

        [Required( ErrorMessage = "Please give some information about the fruit.")]
        [MinLength(5)]
        [Display(Prompt = "Tell us about the fruit you're sharing, and maybe why you're sharing.")]
        public string FruitNotes { get; set; }
    }
}