namespace Finance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Income")]
    public partial class Income
    {
        public int Id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public double Sum { get; set; }

        public int Source { get; set; }

        public int LoginId { get; set; }

        public virtual Source_of_income Source_of_income { get; set; }

        public virtual User User { get; set; }
    }
}
