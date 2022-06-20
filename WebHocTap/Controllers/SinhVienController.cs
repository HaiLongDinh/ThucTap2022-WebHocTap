 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Models;

namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly AppDbContext _context;
        public SinhVienController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinhVien>>> getSinhVien()
        {
            if(_context.SinhViens == null)
            {
                return NotFound();
            }
            return await _context.SinhViens.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVien>> getSinhVien(string id)
        {
            if(_context.SinhViens == null)
            {
                return NotFound();
            }
            var SinhVien = await _context.SinhViens.FindAsync(id);
            
            if (SinhVien == null)
            {
                return NotFound();
            }

            return SinhVien;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhVien (string id, SinhVien sinhvien)
        {
            if(id != sinhvien.sinhvienId)
            {
                return BadRequest();
            }
            _context.Entry(sinhvien).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!SinhVienExists(id))
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
        public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVien sinhvien)
        {
            if (_context.SinhVien == null)
            {
                return Problem("Entity set 'Context.SinhViens' is null ");
            }
            _context.SinhVien.Add(sinhvien);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (SinhVienExists(sinhvien))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetSinhVien", new { id = sinhvien.sinhvienId }, sinhvien);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSinhVien(string id)
        {
            if (_context.SinhViens == null)
            {
                return NoContent();
            }
            var sinhvien = await _context.SinhViens.FindAsync(id);
            if (sinhvien == null)
            {
                return NotFound();
            }

            _context.SinhViens.Remove(sinhvien);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SinhVienExists(string id)
        {
            return (_context.SinhViens?.Any(e => e.sinhvienId == id)).GetValueOrDefault();
        }
    }
}
