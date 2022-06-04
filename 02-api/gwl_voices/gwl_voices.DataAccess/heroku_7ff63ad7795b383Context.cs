using gwl_voices.DataAccess.gwl_Context;
using Microsoft.EntityFrameworkCore;

namespace gwl_voices.DataAccess
{
    public partial class heroku_7ff63ad7795b383Context : DbContext
    {
        public heroku_7ff63ad7795b383Context()
        {
        }

        public heroku_7ff63ad7795b383Context(DbContextOptions<heroku_7ff63ad7795b383Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<TbiUserEvent> TbiUserEvents { get; set; } = null!;
        public virtual DbSet<TbiUserWgroup> TbiUserWgroups { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<WorkingGroup> WorkingGroups { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=eu-cdbr-west-02.cleardb.net;port=3306;database=heroku_7ff63ad7795b383;uid=b1d373e3ed89be;pwd=39b4412b", ServerVersion.Parse("5.6.50-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8_general_ci")
                .HasCharSet("utf8");

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.End).HasColumnName("end");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Place)
                    .HasMaxLength(100)
                    .HasColumnName("place");

                entity.Property(e => e.Start).HasColumnName("start");
            });

            modelBuilder.Entity<TbiUserEvent>(entity =>
            {
                entity.ToTable("tbi_user_events");

                entity.HasIndex(e => e.EventsId, "fk_event_id_idx");

                entity.HasIndex(e => e.UserId, "fk_user_id_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.EventsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("events_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Events)
                    .WithMany(p => p.TbiUserEvents)
                    .HasForeignKey(d => d.EventsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_events");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbiUserEvents)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_user");
            });

            modelBuilder.Entity<TbiUserWgroup>(entity =>
            {
                entity.ToTable("tbi_user_wgroup");

                entity.HasIndex(e => e.UserId, "FK_USER_ID_idx");

                entity.HasIndex(e => e.WorkingGrId, "FK_WG_ID_idx");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");

                entity.Property(e => e.WorkingGrId)
                    .HasColumnType("int(11)")
                    .HasColumnName("working_gr_id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TbiUserWgroups)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_USER_ID");

                entity.HasOne(d => d.WorkingGr)
                    .WithMany(p => p.TbiUserWgroups)
                    .HasForeignKey(d => d.WorkingGrId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WG_ID");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.Id, "id_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username, "username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Adress)
                    .HasMaxLength(100)
                    .HasColumnName("adress");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.Img).HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(45)
                    .HasColumnName("phone");

                entity.Property(e => e.Rol)
                    .HasColumnType("enum('admin','user')")
                    .HasColumnName("rol");

                entity.Property(e => e.Surname)
                    .HasMaxLength(60)
                    .HasColumnName("surname");

                entity.Property(e => e.UrlGwl)
                    .HasMaxLength(100)
                    .HasColumnName("urlGWL");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<WorkingGroup>(entity =>
            {
                entity.ToTable("working_groups");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(45)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
