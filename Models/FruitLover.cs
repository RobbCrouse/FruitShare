using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShare.Models
{
    public class FruitLover : BaseEntity
    {
        [Key]
        public int FruitLoverId { get; set; }

        [ForeignKey("User")]
        public int users_UserId { get; set; }

        [ForeignKey("Fruit")]
        public int fruits_FruitId { get; set; }

        public User User { get; set; }
        public Fruit Fruit { get; set; }
    }
}