namespace DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Plan")]
    public partial class Plan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
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

        public virtual Category Category { get; set; }

        public virtual Source_of_income Source_of_income { get; set; }

        public virtual User User { get; set; }
    }
}
