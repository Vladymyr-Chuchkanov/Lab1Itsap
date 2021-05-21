using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TWeb1
{
    public partial class DBLab1Context : DbContext
    {
        public DBLab1Context()
        {
        }

        public DBLab1Context(DbContextOptions<DBLab1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Admition> Admitions { get; set; }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionTeam> CompetitionTeams { get; set; }
        public virtual DbSet<Complexity> Complexities { get; set; }
        public virtual DbSet<Obstacle> Obstacles { get; set; }
        public virtual DbSet<ObstacleCompetition> ObstacleCompetitions { get; set; }
        public virtual DbSet<Partisipant> Partisipants { get; set; }
        public virtual DbSet<Rank> Ranks { get; set; }
        public virtual DbSet<RankPartisipant> RankPartisipants { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sex> Sexes { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TeamPartisipant> TeamPartisipants { get; set; }
        public virtual DbSet<Type> Types { get; set; }
        public virtual DbSet<FilesTBL> FilesTbl { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server= DESKTOP-JBASPA1\\SQLEXPRESS; Database=DBLab1; Trusted_Connection=True; ");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<FilesTBL>(entity =>
            {
                entity.HasKey(e => e.FileId);
                entity.Property(e => e.FileInsurance).HasColumnType("image");

            });

            modelBuilder.Entity<Account>(entity =>
            {
                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.IdRole).HasColumnName("id_Role");
                entity.Property(e => e.RoleName).HasColumnName("RoleName");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("FK_Accounts_Roles");
            });

            modelBuilder.Entity<Admition>(entity =>
            {
                entity.HasKey(e => e.AdmittedId);

                entity.Property(e => e.AdmittedId).HasColumnName("Admitted_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Competition>(entity =>
            {
                entity.HasIndex(e => e.IdComplexity, "IX_Competitions_id_Complexity");

                entity.HasIndex(e => e.IdType, "IX_Competitions_id_Type");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_id");

                entity.Property(e => e.Description).IsRequired()
                    .HasMaxLength(999)
                    .IsFixedLength(true);

                entity.Property(e => e.IdComplexity).HasColumnName("id_Complexity");
                entity.Property(e => e.IdFile).HasColumnName("IdFile");

                entity.Property(e => e.IdType).HasColumnName("id_Type");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Place)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsFixedLength(true);

                entity.Property(e => e.StartTax)
                    .HasColumnName("Start_tax");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_time");

                entity.HasOne(d => d.IdComplexityNavigation)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.IdComplexity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competitions_Complexities");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Competitions)
                    .HasForeignKey(d => d.IdType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competition_Types");
            });

            modelBuilder.Entity<CompetitionTeam>(entity =>
            {
                entity.ToTable("CompetitionTeam");

                entity.HasIndex(e => e.AdmittedId, "IX_CompetitionTeam_Admitted_id");

                entity.HasIndex(e => e.CompetitionId, "IX_CompetitionTeam_Competition_id");

                entity.HasIndex(e => e.TeamId, "IX_CompetitionTeam_Team_id");

                entity.Property(e => e.CompetitionTeamId).HasColumnName("CompetitionTeam_id");

                entity.Property(e => e.AdmittedId).HasColumnName("Admitted_id");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_id");

                entity.Property(e => e.Penalty).HasColumnName("Penalty");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ResultTime)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
                entity.Property(e => e.ClearTime)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.TeamId).HasColumnName("Team_id");

                entity.HasOne(d => d.Admitted)
                    .WithMany(p => p.CompetitionTeams)
                    .HasForeignKey(d => d.AdmittedId)
                    .HasConstraintName("FK_CompetitionTeam_Admitions");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.CompetitionTeams)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competition/Team_Competitions");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.CompetitionTeams)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Competition/Team_Teams");
            });

            modelBuilder.Entity<Complexity>(entity =>
            {
                entity.Property(e => e.ComplexityId).HasColumnName("Complexity_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Obstacle>(entity =>
            {
                entity.Property(e => e.ObstacleId).HasColumnName("Obstacle_id");

                entity.Property(e => e.AdditionalDescription)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");

                

                entity.Property(e => e.ConditionsOvercoming)
                    .HasMaxLength(300)
                    .IsFixedLength(true);

                entity.Property(e => e.EquipmentObstacle)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.EquipmentStart)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.EquipmentTarget)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.MovementFirst)
                    .HasMaxLength(300)
                    .IsFixedLength(true);
                entity.Property(e => e.OptTime)
                    .HasMaxLength(100)
                    .IsFixedLength(true);
                entity.Property(e => e.CriticalTime)
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<ObstacleCompetition>(entity =>
            {
                entity.ToTable("ObstacleCompetition");
                entity.Property(e => e.IsDeleted).HasColumnName("IsDeleted");

                entity.HasIndex(e => e.CompetitionId, "IX_ObstacleCompetition_Competition_id");

                entity.HasIndex(e => e.ObstacleId, "IX_ObstacleCompetition_Obstacle_id");

                entity.Property(e => e.ObstacleCompetitionId).HasColumnName("ObstacleCompetition_id");

                entity.Property(e => e.CompetitionId).HasColumnName("Competition_id");


                entity.Property(e => e.ObstacleId).HasColumnName("Obstacle_id");

                entity.HasOne(d => d.Competition)
                    .WithMany(p => p.ObstacleCompetitions)
                    .HasForeignKey(d => d.CompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Obstacle/competition_Competition");

                entity.HasOne(d => d.Obstacle)
                    .WithMany(p => p.ObstacleCompetitions)
                    .HasForeignKey(d => d.ObstacleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Obstacle/competition_Obstacles");
            });

            modelBuilder.Entity<Partisipant>(entity =>
            {
                entity.HasKey(e => e.ParticipantId);
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasIndex(e => e.IdRole, "IX_Partisipants_id_Role");

                entity.HasIndex(e => e.IdSex, "IX_Partisipants_id_Sex");

                entity.Property(e => e.ParticipantId)
                    
                    .HasColumnName("Participant_id");

                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_birth");

               

                entity.Property(e => e.IdAccount).HasColumnName("id_Account");

                entity.Property(e => e.IdRole).HasColumnName("id_Role");

                entity.Property(e => e.IdSex).HasColumnName("id_Sex");
                entity.Property(e => e.IdFile).HasColumnName("FileId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsFixedLength(true);

                entity.Property(e => e.Phone_number).IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdAccountNavigation)
                    .WithMany(p => p.Partisipants)
                    .HasForeignKey(d => d.IdAccount)
                    .HasConstraintName("FK_Partisipants_Account");

                entity.HasOne(d => d.IdSexNavigation)
                    .WithMany(p => p.Partisipants)
                    .HasForeignKey(d => d.IdSex)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Partisipants_Sexes");
            });

            modelBuilder.Entity<Rank>(entity =>
            {
                entity.Property(e => e.RankId).HasColumnName("Rank_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<RankPartisipant>(entity =>
            {
                entity.ToTable("RankPartisipant");

                entity.HasIndex(e => e.PartisipantId, "IX_RankPartisipant_Partisipant_id");

                entity.HasIndex(e => e.RankId, "IX_RankPartisipant_Rank_id");

                entity.Property(e => e.RankPartisipantId).HasColumnName("RankPartisipant_id");

                entity.Property(e => e.DateOfAchievement)
                    .HasColumnType("date")
                    .HasColumnName("Date_of_achievement");

                entity.Property(e => e.PartisipantId).HasColumnName("Partisipant_id");

                entity.Property(e => e.RankId).HasColumnName("Rank_id");

                entity.HasOne(d => d.Partisipant)
                    .WithMany(p => p.RankPartisipants)
                    .HasForeignKey(d => d.PartisipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rank/partisipant_Partisipants");

                entity.HasOne(d => d.Rank)
                    .WithMany(p => p.RankPartisipants)
                    .HasForeignKey(d => d.RankId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rank/partisipant_Ranks");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.HasIndex(e => e.ObstacleCompetitionId, "IX_Results_ObstacleCompetition_id");

                entity.HasIndex(e => e.PartisipantId, "IX_Results_Partisipant_id");

                entity.Property(e => e.ResultId).HasColumnName("Result_id");

                entity.Property(e => e.ObstacleCompetitionId).HasColumnName("ObstacleCompetition_id");

                entity.Property(e => e.PartisipantId).HasColumnName("Partisipant_id");

                entity.Property(e => e.Penalty).HasColumnName("Penalty");

                entity.Property(e => e.Time).IsRequired()
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.HasOne(d => d.ObstacleCompetition)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.ObstacleCompetitionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Obstacle/competition");

                entity.HasOne(d => d.Partisipant)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.PartisipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Results_Partisipants");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.RolesId)
                    .HasName("PK_Statuses");

                entity.Property(e => e.RolesId).HasColumnName("Roles_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Sex>(entity =>
            {
                entity.Property(e => e.SexId).HasColumnName("Sex_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.Property(e => e.TeamId).HasColumnName("Team_id");

                entity.Property(e => e.DocId).HasColumnName("DocId");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Comment)
                    .IsRequired()
                    .HasColumnType("ntext");

                entity.Property(e => e.FileDocument).HasColumnType("image");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            modelBuilder.Entity<TeamPartisipant>(entity =>
            {
                entity.ToTable("TeamPartisipant");
                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.HasIndex(e => e.PartisipantId, "IX_TeamPartisipant_Partisipant_id");

                entity.HasIndex(e => e.TeamId, "IX_TeamPartisipant_Team_id");

                entity.Property(e => e.TeamPartisipantId).HasColumnName("TeamPartisipant_id");

                entity.Property(e => e.Participated).HasColumnName("Participated");
                    

                entity.Property(e => e.PartisipantId).HasColumnName("Partisipant_id");

                entity.Property(e => e.TeamId).HasColumnName("Team_id");

                entity.HasOne(d => d.Partisipant)
                    .WithMany(p => p.TeamPartisipants)
                    .HasForeignKey(d => d.PartisipantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team/partisipant_Partisipants");

                entity.HasOne(d => d.Team)
                    .WithMany(p => p.TeamPartisipants)
                    .HasForeignKey(d => d.TeamId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Team/partisipant_Teams");
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.Property(e => e.TypeId).HasColumnName("Type_id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("ntext");
            });

            OnModelCreatingPartial(modelBuilder);
        }
        

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
