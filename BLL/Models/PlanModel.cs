using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Models
{
   public class PlanModel
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Plan_PK { get; set; }

        public double Income { get; set; }

        public double Expenses { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_From { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_To { get; set; }

        [Required]
        [StringLength(30)]
        public string Login_FK { get; set; }

        public int Category_FK { get; set; }

        public int Source_of_income_FK { get; set; }
    }
}
