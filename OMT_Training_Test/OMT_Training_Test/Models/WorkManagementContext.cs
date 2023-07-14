using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OMT_Training_Test.Models
{
    public partial class WorkManagementContext : DbContext
    {
        public WorkManagementContext()
        {
        }

        public WorkManagementContext(DbContextOptions<WorkManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = WorkManagement;uid=sa;pwd=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("Tag");

                entity.Property(e => e.FinishNumber).HasColumnName("FInishNumber");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.FinishDate).HasColumnType("datetime");

                entity.Property(e => e.TaskDescription)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TaskName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.TagId)
                    .HasConstraintName("FK_Task_Tag");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
