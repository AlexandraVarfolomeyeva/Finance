using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
    public class SourceModel
    {
        [Key]
        public int Source_of_income_PK { get; set; }

        [Required]
        [StringLength(255)]
        public string Name_Source_of_income { get; set; }
    }
}
