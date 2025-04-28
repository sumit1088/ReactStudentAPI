using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentForm.Data;
using StudentForm.Models;

namespace StudentForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SchoolsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Schools
        [HttpGet]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            return await _context.Schools.Where(s => !s.IsDeleted).ToListAsync();
        }

        // GET: api/Schools/5
        [HttpGet("{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null || school.IsDeleted)
            {
                return NotFound();
            }

            return school;
        }

        // POST: api/Schools
        [HttpPost]
        public async Task<ActionResult<School>> CreateSchool(School school)
        {
            school.Created = DateTime.UtcNow;
            school.IsDeleted = false;
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, school);
        }

        // PUT: api/Schools/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSchool(int id, School updatedSchool)
        {
            if (id != updatedSchool.Id)
            {
                return BadRequest();
            }

            var school = await _context.Schools.FindAsync(id);
            if (school == null || school.IsDeleted)
            {
                return NotFound();
            }

            // Update fields
            school.Name = updatedSchool.Name;
            school.Address = updatedSchool.Address;
            school.SchoolId = updatedSchool.SchoolId;
            school.CenterId = updatedSchool.CenterId;
            school.DistrictId = updatedSchool.DistrictId;
            school.TehsilId = updatedSchool.TehsilId;
            school.State = updatedSchool.State;
            school.PinCode = updatedSchool.PinCode;
            school.TeacherName = updatedSchool.TeacherName;
            school.ContactNo1 = updatedSchool.ContactNo1;
            school.ContactNo2 = updatedSchool.ContactNo2;
            school.Email = updatedSchool.Email;
            school.Password = updatedSchool.Password;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // DELETE: api/Schools/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null || school.IsDeleted)
            {
                return NotFound();
            }

            // Soft delete
            school.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
