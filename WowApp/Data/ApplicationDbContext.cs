using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using WowApp.EntityModels;

namespace WowApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<ServiceClient> ServiceClients => Set<ServiceClient>();
        public DbSet<Portfolio> Portfolios => Set<Portfolio>();
        public DbSet<Review> Reviews => Set<Review>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
                     
            modelBuilder.ApplyConfiguration(new AppointmentConfig());
            modelBuilder.ApplyConfiguration(new ServiceClientConfig());
            modelBuilder.ApplyConfiguration(new PortfolioConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
        }

        public class AppointmentConfig : IEntityTypeConfiguration<Appointment>
        {
            public void Configure(EntityTypeBuilder<Appointment> b)
            {
                b.ToTable("Appointments");

                b.HasKey(x => x.Id);

                b.Property(x => x.ClientName)
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property(x => x.ClientPhone)
                    .IsRequired()
                    .HasMaxLength(13); 

                b.Property(x => x.Message)
                    .HasMaxLength(2000); 

                b.Property(x => x.IsCulture)
                    .HasDefaultValue(false);
                               
                b.Property(x => x.AppointmentDate)
                    .HasColumnType("date");
                             
                b.HasOne(x => x.User)
                    .WithMany()                
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.SetNull);
                                
                b.HasMany(x => x.ServiceClients)
                    .WithOne(x => x.Appointment)
                    .HasForeignKey(x => x.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade);
                              
                b.HasMany(x => x.Portfolios)
                    .WithOne(x => x.Appointment)
                    .HasForeignKey(x => x.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade);
                               
                b.HasMany(x => x.Reviews)
                    .WithOne(x => x.Appointment)
                    .HasForeignKey(x => x.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }

        public class ServiceClientConfig : IEntityTypeConfiguration<ServiceClient>
        {
            public void Configure(EntityTypeBuilder<ServiceClient> b)
            {
                b.ToTable("ServiceClients");

                b.HasKey(x => x.Id);

                b.Property(x => x.TitleCard)
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property(x => x.DescriptionCard)
                    .HasMaxLength(2000);

                b.Property(x => x.ImgPath)
                    .HasMaxLength(500);

                b.Property(x => x.LessonTime)
                    .HasMaxLength(100);

                b.Property(x => x.Group)
                    .HasMaxLength(100);

                b.Property(x => x.Pice)
                    .HasColumnType("decimal(18,2)");

                b.Property(x => x.IsCulture)
                    .HasDefaultValue(false);

                b.Property(x => x.AppointmentId)
                    .IsRequired();

                b.HasOne(x => x.Appointment)
                    .WithMany(a => a.ServiceClients)
                    .HasForeignKey(x => x.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }

        public class PortfolioConfig : IEntityTypeConfiguration<Portfolio>
        {
            public void Configure(EntityTypeBuilder<Portfolio> b)
            {
                b.ToTable("Portfolios");

                b.HasKey(x => x.Id);

                b.Property(x => x.TitleCard)
                    .IsRequired()
                    .HasMaxLength(200);

                b.Property(x => x.DescriptionCard)
                    .HasMaxLength(2000);

                b.Property(x => x.Group)
                    .HasMaxLength(100);

                b.Property(x => x.ImgPath).HasMaxLength(500);
                b.Property(x => x.ImgTeacherPath).HasMaxLength(500);
                b.Property(x => x.VideoPath).HasMaxLength(500);

                b.Property(x => x.IsCulture)
                    .HasDefaultValue(false);

                b.Property(x => x.AppointmentId)
                    .IsRequired(false);

                b.HasOne(x => x.Appointment)
                 .WithMany()
                 .HasForeignKey(x => x.AppointmentId)
                 .OnDelete(DeleteBehavior.SetNull);
            }
        }

        public class ReviewConfig : IEntityTypeConfiguration<Review>
        {
            public void Configure(EntityTypeBuilder<Review> b)
            {
                b.ToTable("Reviews");

                b.HasKey(x => x.Id);

                b.Property(x => x.ClientName)
                    .IsRequired()
                    .HasMaxLength(100);

                b.Property(x => x.Content)
                    .IsRequired()
                    .HasMaxLength(180);

                b.Property(x => x.ReviewDate)
                    .HasColumnType("date");

                b.Property(x => x.DiscussionLink)
                    .HasMaxLength(50);

                b.Property(x => x.IsCulture)
                    .HasDefaultValue(false);

                b.Property(x => x.AppointmentId)
                    .IsRequired();

                b.HasOne(x => x.Appointment)
                    .WithMany(a => a.Reviews)
                    .HasForeignKey(x => x.AppointmentId)
                    .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
