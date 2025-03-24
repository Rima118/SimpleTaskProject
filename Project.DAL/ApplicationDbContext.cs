using Microsoft.EntityFrameworkCore;
using Project.Common.TaskItemModel;
using System.Collections.Generic;

namespace Project.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=EntityCourse");
        }

        public DbSet<TaskModel> TaskModels { get; set; }
    }
}
