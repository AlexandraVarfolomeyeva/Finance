namespace DAL
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
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Expenses> Expenses { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Source_of_income> Source_of_income { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Plan)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.Category_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Expenses>()
                .Property(e => e.Name_expenses)
                .IsUnicode(false);

            modelBuilder.Entity<Expenses>()
                .Property(e => e.Login_FK)
                .IsUnicode(false);

            modelBuilder.Entity<Income>()
                .Property(e => e.Login_FK)
                .IsUnicode(false);

            modelBuilder.Entity<Plan>()
                .Property(e => e.Login_FK)
                .IsUnicode(false);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Purchase>()
                .Property(e => e.Login_FK)
                .IsUnicode(false);

            modelBuilder.Entity<Source_of_income>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Source_of_income>()
                .HasMany(e => e.Income)
                .WithRequired(e => e.Source_of_income)
                .HasForeignKey(e => e.Source_of_the_income_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Source_of_income>()
                .HasMany(e => e.Plan)
                .WithRequired(e => e.Source_of_income)
                .HasForeignKey(e => e.Source_of_income_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login_PK)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Expenses)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Login_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Income)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Login_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Plan)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Login_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Purchase)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.Login_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
