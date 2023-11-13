using System;
using System.Collections.Generic;
using Api.AgileProj.Data.Context.Contract;
using Api.AgileProj.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;
using Action = Api.AgileProj.Data.Entity.Model.Action;
using Task = Api.AgileProj.Data.Entity.Model.Task;

namespace Api.AgileProj.Data.Entity;

public partial class AgileProjDBContext : DbContext, IAgileProjDBContext
{
    public AgileProjDBContext()
    {
    }

    public AgileProjDBContext(DbContextOptions<AgileProjDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Action> Actions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<TakePart> TakeParts { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("account");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Action>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("action");

            entity.HasIndex(e => e.Idtask, "fk_have_tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idtask).HasColumnName("idtask");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.TitleAction)
                .HasMaxLength(100)
                .HasColumnName("title_action");

            entity.HasOne(d => d.IdtaskNavigation).WithMany(p => p.Actions)
                .HasForeignKey(d => d.Idtask)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_have_tasks");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAtProject)
                .HasColumnType("datetime")
                .HasColumnName("created_at_project");
            entity.Property(e => e.NameProject)
                .HasMaxLength(100)
                .HasColumnName("name_project");
        });

        modelBuilder.Entity<TakePart>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("take_part");

            entity.HasIndex(e => e.Idaccount, "fk_takepart_account");

            entity.HasIndex(e => e.Idproject, "fk_takepart_projects");

            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idproject).HasColumnName("idproject");

            entity.HasOne(d => d.IdaccountNavigation).WithMany()
                .HasForeignKey(d => d.Idaccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_takepart_account");

            entity.HasOne(d => d.IdprojectNavigation).WithMany()
                .HasForeignKey(d => d.Idproject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_takepart_projects");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("task");

            entity.HasIndex(e => e.Idaccount, "fk_beResponsible_account");

            entity.HasIndex(e => e.Idproject, "fk_possess_project");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAtTask)
                .HasColumnType("datetime")
                .HasColumnName("created_at_task");
            entity.Property(e => e.DescriptionTask)
                .HasColumnType("text")
                .HasColumnName("description_task");
            entity.Property(e => e.EndAtTask)
                .HasColumnType("datetime")
                .HasColumnName("end_at_task");
            entity.Property(e => e.Idaccount).HasColumnName("idaccount");
            entity.Property(e => e.Idproject).HasColumnName("idproject");
            entity.Property(e => e.StatusTask).HasColumnName("status_task");
            entity.Property(e => e.TitleTask)
                .HasMaxLength(100)
                .HasColumnName("title_task");

            entity.HasOne(d => d.IdaccountNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Idaccount)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_beResponsible_account");

            entity.HasOne(d => d.IdprojectNavigation).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.Idproject)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_possess_project");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
