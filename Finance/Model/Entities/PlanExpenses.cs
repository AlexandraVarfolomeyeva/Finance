namespace Finance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PlanExpenses
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Expenses { get; set; }

        public double? Sum { get; set; }

        public DateTime? Date { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }
    }
}
