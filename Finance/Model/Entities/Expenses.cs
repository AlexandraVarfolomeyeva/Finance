namespace Finance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Expenses
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string Name { get; set; }

        public double Sum { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int Necessity { get; set; }

        public int CategoryId { get; set; }

        public int LoginId { get; set; }

        public virtual Category Category { get; set; }

        public virtual Necessity Necessity1 { get; set; }

        public virtual User User { get; set; }
    }
}
