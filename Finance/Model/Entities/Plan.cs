namespace Finance
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
        public int Plan_PK { get; set; }

        public double Income { get; set; }

        public double Expenses { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_From { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date_To { get; set; }

        public int LoginId { get; set; }

        public int CategoryId { get; set; }

        public int SourceId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Source_of_income Source_of_income { get; set; }

        public virtual User User { get; set; }
    }
}
