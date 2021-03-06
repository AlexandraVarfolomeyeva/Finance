namespace Finance
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FinancesDBContext : DbContext
    {
        public FinancesDBContext()
            : base("name=Model1")
        {
            Source_of_income.Load();
            Category.Load();
            Necessity.Load();
            Income.Load();
            Expenses.Load();
            PlanExpenses.Load();
            PlanIncome.Load();
            Purchase.Load();
        }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Necessity> Necessity { get; set; }
        public virtual DbSet<PlanExpenses> PlanExpenses { get; set; }
        public virtual DbSet<PlanIncome> PlanIncome { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Source_of_income> Source_of_income { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Expenses>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Necessity>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.Necessity1)
                .HasForeignKey(e => e.Necessity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PlanExpenses>()
                .Property(e => e.Expenses)
                .IsUnicode(false);

            modelBuilder.Entity<PlanIncome>()
                .Property(e => e.Income)
                .IsUnicode(false);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Source_of_income>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Source_of_income>()
                .HasMany(e => e.Income)
                .WithRequired(e => e.Source_of_income)
                .HasForeignKey(e => e.Source);

            modelBuilder.Entity<Source_of_income>()
                .HasMany(e => e.PlanIncome)
                .WithRequired(e => e.Source_of_income)
                .HasForeignKey(e => e.SourceId);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.LoginId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Income)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.LoginId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}