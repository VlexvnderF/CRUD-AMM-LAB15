using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Database2022.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ProductId { get; set; } 
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Stock { get; set; }
        public double Price { get; set; }

        
    }
}
