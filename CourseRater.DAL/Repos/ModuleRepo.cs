using CourseRater.DAL.DBO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseRater.DAL.Repos
{
    public class ModuleRepo : BaseRepo, IRepo<Module>
    {
        public ModuleRepo(CourseRaterDbContext context) : base(context)
        {

        }
        public async Task Create(Module entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var module = await _context.Modules.FindAsync(id);
            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();
        }

        public bool Exists(int id)
        {
            return _context.Modules.Any(e => e.Id == id);
        }

        public async Task<List<Module>> GetAll()
        {
            return await _context.Modules.ToListAsync();
        }

        public async Task<Module> GetById(int id)
        {
            return await _context.Modules
                 .FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task Update(Module entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
