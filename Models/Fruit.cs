using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FruitShare.Models
{
    public class Fruit : BaseEntity
    {
        public int FruitId { get; set; }
        public string FruitName { get; set; }
        public string FruitNotes { get; set; }
        public string FruitType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        [ForeignKey("CreatedBy")]
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public List<FruitLover> FruitLovers { get; set; }

        public Fruit ()
        {
            FruitLovers = new List<FruitLover>();
        }
    }
}