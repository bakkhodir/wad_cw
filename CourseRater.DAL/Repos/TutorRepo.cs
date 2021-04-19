using CourseRater.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRater.DAL.Repos
{
    public class TutorRepo : BaseRepo, IRepo<Tutor>
    {
        public TutorRepo(CourseRaterDbContext context) : base(context)
        {

        }
        public async Task Create(Tutor entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var tutor = await _context.Tutors.FindAsync(id);
            _context.Tutors.Remove(tutor);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Tutors.Any(e => e.Id == id);
        }

        public async Task<List<Tutor>> GetAll()
        {
            return await _context.Tutors.ToListAsync();
        }

        public async Task<Tutor> GetById(int id)
        {
            return await _context.Tutors
                  .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(Tutor entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
