using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentForm.Data;
using StudentForm.Models;

namespace StudentForm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CentersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CentersController(AppDbContext context)
        {
            _context = context;
        }

        // -------------------- Centers --------------------
        // GET: api/Centers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CenterDto>>> GetCenters()
        {
            var centers = await _context.Centers
                .Where(c => !c.IsDeleted)
                .Include(c => c.District)
                .Include(c => c.Tehsil)
                .Select(c => new CenterDto
                {
                    Id = c.Id,
                    CenterId = c.CenterId,
                    Name = c.Name,
                    Address = c.Address,
                    DistrictName = c.District != null ? c.District.Name : null,
                    TehsilName = c.Tehsil != null ? c.Tehsil.Name : null,
                    Created = c.Created
                })
                .ToListAsync();

            return Ok(centers);
        }


        // GET: api/Centers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Center>> GetCenter(int id)
        {
            var center = await _context.Centers.FindAsync(id);

            if (center == null || center.IsDeleted)
            {
                return NotFound();
            }

            return center;
        }

        // POST: api/Centers
        [HttpPost]
        public async Task<ActionResult<Center>> PostCenter(Center center)
        {
            center.Created = DateTime.UtcNow;
            _context.Centers.Add(center);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCenter), new { id = center.Id }, center);
        }

        // PUT: api/Centers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCenter(int id, Center center)
        {
            if (id != center.Id)
            {
                return BadRequest();
            }

            _context.Entry(center).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CenterExists(id))
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

        // DELETE: api/Centers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCenter(int id)
        {
            var center = await _context.Centers.FindAsync(id);
            if (center == null)
            {
                return NotFound();
            }

            center.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CenterExists(int id)
        {
            return _context.Centers.Any(e => e.Id == id);
        }
    

        // -------------------- Districts --------------------
        [HttpGet("districts")]
        public async Task<ActionResult<IEnumerable<DistrictsMasters>>> GetDistricts()
        {
            return await _context.Districts.ToListAsync();
        }

        [HttpGet("districts/{id}")]
        public async Task<ActionResult<DistrictsMasters>> GetDistrict(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            if (district == null) return NotFound();
            return district;
        }

        [HttpPost("districts")]
        public async Task<ActionResult<DistrictsMasters>> CreateDistrict(DistrictsMasters district)
        {
            district.Created = DateTime.UtcNow;
            _context.Districts.Add(district);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetDistrict), new { id = district.Id }, district);
        }

        [HttpPut("districts/{id}")]
        public async Task<IActionResult> UpdateDistrict(int id, DistrictsMasters district)
        {
            if (id != district.Id) return BadRequest();
            _context.Entry(district).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("districts/{id}")]
        public async Task<IActionResult> DeleteDistrict(int id)
        {
            var district = await _context.Districts.FindAsync(id);
            if (district == null) return NotFound();
            _context.Districts.Remove(district);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        // -------------------- Tehsils --------------------
        [HttpGet("tehsils")]
        public async Task<ActionResult<IEnumerable<TehsilsMasters>>> GetTehsils()
        {
            return await _context.Tehsils.ToListAsync();
        }

        [HttpGet("tehsils/{id}")]
        public async Task<ActionResult<TehsilsMasters>> GetTehsil(int id)
        {
            var tehsil = await _context.Tehsils.FindAsync(id);
            if (tehsil == null) return NotFound();
            return tehsil;
        }

        [HttpPost("tehsils")]
        public async Task<ActionResult<TehsilsMasters>> CreateTehsil(TehsilsMasters tehsil)
        {
            tehsil.Created = DateTime.UtcNow;
            _context.Tehsils.Add(tehsil);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTehsil), new { id = tehsil.Id }, tehsil);
        }

        [HttpPut("tehsils/{id}")]
        public async Task<IActionResult> UpdateTehsil(int id, TehsilsMasters tehsil)
        {
            if (id != tehsil.Id) return BadRequest();
            _context.Entry(tehsil).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("tehsils/{id}")]
        public async Task<IActionResult> DeleteTehsil(int id)
        {
            var tehsil = await _context.Tehsils.FindAsync(id);
            if (tehsil == null) return NotFound();
            _context.Tehsils.Remove(tehsil);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
