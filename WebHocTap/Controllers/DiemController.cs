using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Models;

namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemController : ControllerBase
    {
        private readonly AppDbContext _context;
        public DiemController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Diem>>> GetDiems()
        {
            if (_context.Diems == null)
            {
                return NotFound();
            }
            return await _context.Diems.ToListAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Diem>> GetDiem(int id)
        {
            if (_context.Diems == null)
            {
                return NotFound();
            }
            var diem = await _context.Diems.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }

            return diem;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiem(int id, Diem diem)
        {
            if (id != diem.diemId)
            {
                return BadRequest();
            }
            _context.Entry(diem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiemExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Diem>> PostDiem(Diem diem)
        {
            if (_context.Diems == null)
            {
                return Problem("Entity set 'Context.Diems' is null");
            }
            _context.Diems.Add(diem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiem", new { id = diem.diemId }, diem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiem(int id)
        {
            if (_context.Diems == null)
            {
                return NotFound();
            }
            var diem = await _context.Diems.FindAsync(id);
            if (diem == null)
            {
                return NotFound();
            }

            _context.Diems.Remove(diem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DiemExists(int id)
        {
            return (_context.Diems?.Any(e => e.diemId == id)).GetValueOrDefault();
        }
    }
}
