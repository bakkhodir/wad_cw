using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CourseRater.DAL;
using CourseRater.Models;
using CourseRater.DAL.DBO;
using CourseRater.DAL.Repos;

namespace CourseRater.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IRepo<Module> _moduleRepo;

        public ModulesController(IRepo<Module> moduleRepo)
        {
            _moduleRepo = moduleRepo;

        }

        // GET: api/Modules
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
            return await _moduleRepo.GetAll();
        }

        // GET: api/Modules/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(int id)
        {
            var module = await _moduleRepo.GetById(id);

            if (module == null)
            {
                return NotFound();
            }

            return module;
        }

        // PUT: api/Modules/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(int id, Module @module)
        {
            if (id != module.Id)
            {
                return BadRequest();
            }
       
            try
            {
                await _moduleRepo.Update(module);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_moduleRepo.Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Modules
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module @module)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _moduleRepo.Create(module);

            return CreatedAtAction("GetModule", new { id = module.Id }, module);
        }

        // DELETE: api/Modules/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Module>> DeleteModule(int id)
        {
            var module = await _moduleRepo.GetById(id);
            if (module == null)
            {
                return NotFound();
            }

            //_context.Reviews.Remove(review);
            //await _context.SaveChangesAsync();
            await _moduleRepo.Delete(id);

            return NoContent();
        }

        
    }
}
