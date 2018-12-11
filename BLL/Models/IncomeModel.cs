using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class IncomeModel
    {
        [Key]
        public int Income_PK { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public double Sum { get; set; }

        public int Source_of_the_income_FK { get; set; }

        [Required]
        [StringLength(30)]
        public string Login_FK { get; set; }
    }
}
