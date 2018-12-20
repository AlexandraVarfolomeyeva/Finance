namespace Finance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PlanIncome")]
    public partial class PlanIncome
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Income { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int SourceId { get; set; }

        public int UserId { get; set; }

        public virtual Source_of_income Source_of_income { get; set; }

        public virtual User User { get; set; }
    }
}
