namespace Finance
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Necessity")]
    public partial class Necessity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Necessity()
        {
            Expenses = new HashSet<Expenses>();
        }

        public int Id { get; set; }

        [Column("Necessity")]
        [Required]
        [StringLength(50)]
        public string Necessity1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Expenses> Expenses { get; set; }
    }
}
