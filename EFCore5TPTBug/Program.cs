using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace EFCore5TPTBug
{
    public class Referral
    {
        public Guid Id { get; set; }
    }

    public class UserReferral : Referral
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class ReferralEntityConfiguration : IEntityTypeConfiguration<Referral>
    {
        public void Configure(EntityTypeBuilder<Referral> builder)
        {
            // This causes all derived classes to use the same key name and PostgreSQL does not like that
            // PostgreSQL error 42P07: relation "referral_pkey" already exists
            builder.HasKey(p => p.Id).HasName("referral_pkey");

            builder.ToTable("referral");
        }
    }

    public class UserReferralEntityConfiguration : IEntityTypeConfiguration<UserReferral>
    {
        public void Configure(EntityTypeBuilder<UserReferral> builder)
        {
            // Trying to change the key name for a derived type will get you this exception
            // System.InvalidOperationException: A key cannot be configured on 'UserReferral' because it is a derived type. The key must be configured on the root type 'Referral'.

            //builder.HasKey(p => p.Id).HasName("user_referral_pkey");

            builder.ToTable("user_referral");
        }
    }


    public class TestDbContext : DbContext
    {
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<UserReferral> UserReferrals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=efcore5tptbug;Username=postgres;Password=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestDbContext).Assembly);
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
