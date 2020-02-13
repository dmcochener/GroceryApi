using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApi.Models
{
    public class GroceryItem
    {
        [Key]
        public int GroceryId { get; set; }
        public string ItemName { get; set; }
        public int QuantityNeeded { get; set; } = 1;
        public Enums.Measurements Measurement { get; set; }
        public Enums.Stores Location { get; set; }
        public bool Purchased { get; set; } = false;
    }

}
