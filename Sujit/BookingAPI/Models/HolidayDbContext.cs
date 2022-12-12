using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BookingAPI.Models;

public partial class HolidayDbContext : DbContext
{
    public HolidayDbContext()
    {
    }

    public HolidayDbContext(DbContextOptions<HolidayDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<UserDetail> UserDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=HolidayDB;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PK__Booking__5DE3A5B1E90B5123");

            entity.ToTable("Booking");

            entity.Property(e => e.BookingId)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasComputedColumnSql("(right('BKID00'+CONVERT([varchar](7),[user_id]),(7)))", true)
                .HasColumnName("booking_id");
            entity.Property(e => e.BookingDate)
                .HasColumnType("date")
                .HasColumnName("booking_date");
            entity.Property(e => e.BookingStatus)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("booking_status");
            entity.Property(e => e.CheckIn)
                .HasColumnType("date")
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasColumnType("date")
                .HasColumnName("check_out");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Booking__user_id__3D5E1FD2");
        });

        modelBuilder.Entity<UserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserDeta__B9BE370F5CB89B7A");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.AdharNumber)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("adhar_number");
            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Mobile)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mobile");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
