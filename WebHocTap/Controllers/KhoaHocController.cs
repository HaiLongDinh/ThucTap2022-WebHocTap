using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Models;

namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoaHocController : ControllerBase
    {
        private readonly AppDbContext _context;
        public KhoaHocController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<KhoaHoc>>> GetKhoaHocs()
        {
            if(_context.KhoaHocs == null)
            {
                return NotFound();
            }
            return await _context.KhoaHocs.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KhoaHoc>> GetKhoaHoc(int id)
        {
            if(_context.KhoaHocs == null)
            {
                return NotFound();
            }
            var khoahoc = await context.KhoaHocs.FindAsync(id);

            if(khoahoc == null)
            {
                return NotFound();
            }
            return khoahoc;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoaHoc(int id, KhoaHoc khoahoc)
        {
            if (id != khoahoc.khoahocId)
            {
                return BadRequest();
            }
            _context.Entry(khoahoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaHocExists(id))
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
        public async Task<ActionResult<KhoaHoc>> PostKhoaHoc(KhoaHoc khoahoc)
        {
            if(_context.KhoaHocs == null)
            {
                return Problem("Entity set 'Context.KhoaHoc' is null.");
            }
            _context.KhoaHocs.Add(khoahoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKhoaHoc", new { id = khoahoc.khoahocId }, khoahoc);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteKhoaHoc(int id)
        {
            if(_context.KhoaHocs == null)
            {
                return NotFound();
            }
            var khoahoc = await _context.KhoaHocs.FindAsync(id);
            if (khoahoc == null)
            {
                return NotFound();
            }

            _context.KhoaHocs.Remove(khoahoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaHocExists(int id)
        {
            return (_context.KhoaHocs?.Any(e => e.khoahocId == id)).GetValueOrDefault();
        }
    }
}
