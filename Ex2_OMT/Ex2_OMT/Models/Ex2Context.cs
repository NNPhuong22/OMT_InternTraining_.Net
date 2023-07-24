using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ex2_OMT.Models
{
    public partial class Ex2Context : DbContext
    {
        public Ex2Context()
        {
        }

        public Ex2Context(DbContextOptions<Ex2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CommentPost> CommentPosts { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<ReplyPost> ReplyPosts { get; set; }
        public virtual DbSet<SubReply> SubReplies { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = Ex2;uid=sa;pwd=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CommentPost>(entity =>
            {
                entity.HasKey(e => e.CmtId);

                entity.ToTable("CommentPost");

                entity.Property(e => e.CmtContent)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.CommentPosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_CommentPost_Post");

                entity.HasOne(d => d.ReplierNavigation)
                    .WithMany(p => p.CommentPosts)
                    .HasForeignKey(d => d.Replier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CommentPost_User");
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable("Post");

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.PostContent).IsRequired();

                entity.Property(e => e.PostName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_Category");

                entity.HasOne(d => d.CreatedNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Created)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Post_User");
            });

            modelBuilder.Entity<ReplyPost>(entity =>
            {
                entity.HasKey(e => e.ReplyId);

                entity.ToTable("ReplyPost");

                entity.Property(e => e.ReplyContent)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.ReplyPosts)
                    .HasForeignKey(d => d.PostId)
                    .HasConstraintName("FK_ReplyPost_Post");

                entity.HasOne(d => d.ReplierNavigation)
                    .WithMany(p => p.ReplyPosts)
                    .HasForeignKey(d => d.Replier)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ReplyPost_User");
            });

            modelBuilder.Entity<SubReply>(entity =>
            {
                entity.HasKey(e => e.SubId);

                entity.ToTable("SubReply");

                entity.Property(e => e.SubContent).IsRequired();

                entity.HasOne(d => d.ReplierNavigation)
                    .WithMany(p => p.SubReplies)
                    .HasForeignKey(d => d.Replier)
                    .HasConstraintName("FK_SubReply_User");

                entity.HasOne(d => d.Reply)
                    .WithMany(p => p.SubReplies)
                    .HasForeignKey(d => d.ReplyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubReply_ReplyPost");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(16);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
