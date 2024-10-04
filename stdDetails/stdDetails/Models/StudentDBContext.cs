using Microsoft.EntityFrameworkCore;

namespace stdDetails.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext(DbContextOptions options) : base(options) 
        {
            
        }

        public DbSet<Students> SecondStudents { get; set; }
    }
}
