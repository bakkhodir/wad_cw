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
    public class TutorsController : ControllerBase
    {
        private readonly IRepo<Tutor> _tutorRepo;

        public TutorsController(IRepo<Tutor> tutorRepo)
        {
            _tutorRepo = tutorRepo;

        }

        // GET: api/Tutors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tutor>>> GetTutors()
        {
            return await _tutorRepo.GetAll();
        }

        // GET: api/Tutors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tutor>> GetTutor(int id)
        {
            var tutor = await _tutorRepo.GetById(id);

            if (tutor == null)
            {
                return NotFound();
            }

            return tutor;
        }

        // PUT: api/Tutors/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTutor(int id, Tutor tutor)
        {
            if (id != tutor.Id)
            {
                return BadRequest();
            }

           

            try
            {
                await _tutorRepo.Update(tutor);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_tutorRepo.Exists(id))
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

        // POST: api/Tutors
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Tutor>> PostTutor(Tutor tutor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _tutorRepo.Create(tutor);

            return CreatedAtAction("GetTutor", new { id = tutor.Id }, tutor);
        }

        // DELETE: api/Tutors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Tutor>> DeleteTutor(int id)
        {
            var tutor = await _tutorRepo.GetById(id);
            if (tutor == null)
            {
                return NotFound();
            }

            //_context.Reviews.Remove(review);
            //await _context.SaveChangesAsync();
            await _tutorRepo.Delete(id);

            return NoContent();
        }

       
    }
}
