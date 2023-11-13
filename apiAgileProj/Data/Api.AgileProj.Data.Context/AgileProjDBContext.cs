using System;
using System.Collections.Generic;
using Api.AgileProj.Data.Entity.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.AgileProj.Data.Entity;

public partial class AgileProjDBContext : DbContext
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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;database=simpl_AgileProj;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.2.0-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("accounts");

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

            entity.ToTable("actions");

            entity.HasIndex(e => e.Idtasks, "fk_have_tasks");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Idtasks).HasColumnName("idtasks");
            entity.Property(e => e.IsCompleted).HasColumnName("is_completed");
            entity.Property(e => e.TitleAction)
                .HasMaxLength(100)
                .HasColumnName("title_action");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("projects");

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
            entity.HasKey(e => new { e.Idaccounts, e.Idprojects })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity.ToTable("take_part");

            entity.HasIndex(e => e.Idprojects, "fk_takepart_projects");

            entity.Property(e => e.Idaccounts).HasColumnName("idaccounts");
            entity.Property(e => e.Idprojects).HasColumnName("idprojects");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tasks");

            entity.HasIndex(e => e.Idaccounts, "fk_beResponsible_accounts");

            entity.HasIndex(e => e.Idprojects, "fk_possess_projects");

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
            entity.Property(e => e.Idaccounts).HasColumnName("idaccounts");
            entity.Property(e => e.Idprojects).HasColumnName("idprojects");
            entity.Property(e => e.StatusTask).HasColumnName("status_task");
            entity.Property(e => e.TitleTask)
                .HasMaxLength(100)
                .HasColumnName("title_task");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
