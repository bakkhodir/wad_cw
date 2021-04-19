using CourseRater.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseRater.DAL
{
    public class CourseRaterDbContext : DbContext
    {
        public CourseRaterDbContext(DbContextOptions<CourseRaterDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Tutor> Tutors { get; set; }

    }
}
