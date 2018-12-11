namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Income")]
    public partial class Income
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

        public virtual Source_of_income Source_of_income { get; set; }

        public virtual User User { get; set; }
    }
}
