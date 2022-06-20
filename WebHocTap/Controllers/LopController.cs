using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHocTap.Models;

namespace WebHocTap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LopController(AppDbContext context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LopHoc>>> GetLops()
        {
            if(_context.Lops == null)
            {
                return NotFound();
            }
            return await _context.Lops.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LopHoc>> GetLop(string id)
        {
            if(_context.Lops == null)
            {
                return NotFound();
            }
            var @lop = await _context.Lops.FindAsync(id);
            if(@lop = null)
            {
                return NotFound();
            }
            return @lop;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLop(string id, LopHoc @lop)
        {
            if (id != @lop.lopId)
            {
                return BadRequest();
            }
            _context.Entry(@lop).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!LopExists(id))
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
        public async Task<ActionResult<LopHoc>> PostLop(LopHoc @lop)
        {
            if(_context.Lops == null)
            {
                return Problem("Entity set 'Context.Lops' is null");
            }
            _context.Lops.Add(@lop);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LopExists(@lop.lopId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetLop", new { id = @lop.lopId}, @lop);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LopHoc>> DeleteLop (string id)
        {
            if(_context.Lops == null)
            {
                return NotFound();
            }
            var @lop = await _context.Lops.FindAsync(id);
            if (@lop == null)
            {
                return NotFound();
            }

            _context.Lops.Remove(@lop);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LopExists(string id)
        {
            return (_context.Lops?.Any(e => e.lopId == id)).GetValueOrDefault();
        }
    }
}
