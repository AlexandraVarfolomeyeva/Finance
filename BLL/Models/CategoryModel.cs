using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class CategoryModel
    {
        [Key]
        public int Category_PK { get; set; }

        [Required]
        [StringLength(255)]
        public string Category_name { get; set; }
    }
}
