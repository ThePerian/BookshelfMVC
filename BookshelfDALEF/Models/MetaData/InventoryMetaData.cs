using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookshelfDALEF.Models.MetaData
{
    public class InventoryMetaData
    {
        [Display(Name = "Name")]
        public string BookName;

        [Display(Name = "Read Status")]
        public bool ReadStatus;
    }
}
