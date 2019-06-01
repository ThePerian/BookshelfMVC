using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookshelfDALEF.Models
{
    [Table("Inventory")]
    public partial class Inventory : EntityBase
    {
        [Key]
        public int BookId { get; set; }

        [StringLength(50, ErrorMessage = "Please enter a value less than 50 characters long.")]
        public string Author { get; set; }

        [StringLength(50)]
        public string BookName { get; set; }

        [Required]
        public bool ReadStatus { get; set; }
    }
}
