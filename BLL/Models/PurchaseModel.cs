using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
  public  class PurchaseModel
    {
        [Key]
        public int Purchase_PK { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(30)]
        public string Login_FK { get; set; }
    }
}
