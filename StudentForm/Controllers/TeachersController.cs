using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentForm.Data;
using StudentForm.Models;
using System.ComponentModel.DataAnnotations;

namespace StudentForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TeachersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Teachers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Teachers>>> GetTeachers()
        {
            return await _context.Teachers.ToListAsync();
        }

        // GET: api/Teachers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teachers>> GetTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
                return NotFound();

            return teacher;
        }

        // POST: api/Teachers
        [HttpPost]
        public async Task<ActionResult<Teachers>> PostTeacher(Teachers teacher)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTeacher), new { id = teacher.Id }, teacher);
        }


        // PUT: api/Teachers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTeacher(int id, Teachers teacher)
        {
            if (id != teacher.Id)
                return BadRequest();

            _context.Entry(teacher).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeacherExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/Teachers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);
            if (teacher == null)
                return NotFound();

            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Teachers/Bulk
        [HttpPost("Bulk")]
        public async Task<ActionResult> BulkInsertTeachers(List<Teachers> teachers)
        {
            foreach (var teacher in teachers)
            {
                var context = new ValidationContext(teacher);
                var results = new List<ValidationResult>();
                if (!Validator.TryValidateObject(teacher, context, results, true))
                {
                    return BadRequest(new { error = "Validation failed", teacher, errors = results });
                }
            }

            _context.Teachers.AddRange(teachers);
            await _context.SaveChangesAsync();

            return Ok(new { count = teachers.Count, message = "Bulk insert successful" });
        }


        private bool TeacherExists(int id)
        {
            return _context.Teachers.Any(e => e.Id == id);
        }
    }

}
