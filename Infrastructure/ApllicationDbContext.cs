using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApllicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApllicationDbContext(DbContextOptions<ApllicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Domain.ToDoTask> Tasks { get; set; }
        public DbSet<TaskFile> TaskFiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ConfigureToDoTask(modelBuilder);
            ConfigureTaskFile(modelBuilder);
            ConfigureCategory(modelBuilder);
            ConfigureApplicationUser(modelBuilder);
        }

        private void ConfigureToDoTask(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Description)
                .IsRequired()
                .HasMaxLength(800);

            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.Status)
                .HasConversion<int>()
                .IsRequired()
                .HasDefaultValue(ToDoTask.TaskStatus.Pending);


            modelBuilder.Entity<ToDoTask>()
                .HasOne(t => t.User)
                .WithMany(u => u.Tasks)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ToDoTask>()
                .HasOne(t => t.Category)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ToDoTask>()
                .HasMany(t => t.TaskFiles)
                .WithOne(tf => tf.Task)
                .HasForeignKey(tf => tf.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ToDoTask>()
                .Property(t => t.IsCompleted)
                .HasDefaultValue(false);

        }

        private void ConfigureTaskFile(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskFile>()
                .Property(tf => tf.FileName)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<TaskFile>()
                .Property(tf => tf.FilePath)
                .IsRequired()
                .HasMaxLength(500);

            modelBuilder.Entity<TaskFile>()
                .HasOne(tf => tf.Task)
                .WithMany(t => t.TaskFiles)
                .HasForeignKey(tf => tf.TaskId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        private void ConfigureCategory(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Tasks)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureApplicationUser(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.FirstName)
                .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.LastName)
                .HasMaxLength(100);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.ProfilePictureUrl)
                .HasMaxLength(500);

            modelBuilder.Entity<ApplicationUser>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
