using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class ExpensesModel
    {
        [Key]
        public int Expenses_PK { get; set; }

        [StringLength(255)]
        public string Name_expenses { get; set; }

        public double Sum_expenses { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_purchase { get; set; }

        public int Necessity { get; set; }

        [Column("Categoty_FK")]
        public int Category_FK { get; set; }

        [Required]
        [StringLength(30)]
        public string Login_FK { get; set; }
    }
}
