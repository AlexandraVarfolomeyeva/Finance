namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Expenses
    {
        [Key]
        public int Expenses_PK { get; set; }

        [StringLength(255)]
        public string Name_expenses { get; set; }

        public double Sum_expenses { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_purchase { get; set; }

        public int Necessity { get; set; }

        [Column ("Categoty_FK")]
        public int Category_FK { get; set; }

        [Required]
        [StringLength(30)]
        public string Login_FK { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
