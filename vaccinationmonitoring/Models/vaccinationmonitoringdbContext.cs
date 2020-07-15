using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace vaccinationmonitoring.Models
{
    public partial class vaccinationmonitoringdbContext : DbContext
    {
        public vaccinationmonitoringdbContext()
        {
        }

        public vaccinationmonitoringdbContext(DbContextOptions<vaccinationmonitoringdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Area { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Compaign> Compaign { get; set; }
        public virtual DbSet<CompaignAreaHouse> CompaignAreaHouse { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<House> House { get; set; }
        public virtual DbSet<Province> Province { get; set; }
        public virtual DbSet<User> User { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=HAFIZHASSAN\\SQLEXPRESS;Database=vaccinationmonitoringdb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("area");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CityId).HasColumnName("city_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("city");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.ProvinceId).HasColumnName("province_id");
            });

            modelBuilder.Entity<Compaign>(entity =>
            {
                entity.ToTable("compaign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.AssignedBy).HasColumnName("assigned_by");

                entity.Property(e => e.AssignedTo).HasColumnName("assigned_to");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.EndDate)
                    .HasColumnName("end_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .HasColumnName("start_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<CompaignAreaHouse>(entity =>
            {
                entity.ToTable("compaign_area_house");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CompaignId).HasColumnName("compaign_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.HouseId).HasColumnName("house_id");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("country");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("feedback");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CompaignId).HasColumnName("compaign_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Feedback1).HasColumnName("feedback");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("date");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<House>(entity =>
            {
                entity.ToTable("house");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.HouseNo)
                    .HasColumnName("house_no")
                    .HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Province>(entity =>
            {
                entity.ToTable("province");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CountryId).HasColumnName("country_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AreaId).HasColumnName("area_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("created_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnName("modified_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
