using System;
using System.Collections.Generic;
using System.Text;

namespace CourseRater.DAL.Repos
{
    public abstract class BaseRepo
    {
        protected readonly CourseRaterDbContext _context;

        protected BaseRepo(CourseRaterDbContext context)
        {
            _context = context;
        }
    }
}
