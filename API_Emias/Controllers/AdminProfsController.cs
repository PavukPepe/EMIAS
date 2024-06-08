using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_Emias.Models;

namespace API_Emias.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminProfsController : ControllerBase
    {
        private readonly EmiasContext _context;

        public AdminProfsController(EmiasContext context)
        {
            _context = context;
        }

        // GET: api/AdminProfs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AdminProf>>> GetAdminProfs()
        {
            return await _context.AdminProfs.ToListAsync();
        }

        // GET: api/AdminProfs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AdminProf>> GetAdminProf(int? id)
        {
            var adminProf = await _context.AdminProfs.FindAsync(id);

            if (adminProf == null)
            {
                return NotFound();
            }

            return adminProf;
        }

        // PUT: api/AdminProfs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdminProf(int? id, AdminProf adminProf)
        {
            if (id != adminProf.IdAdmin)
            {
                return BadRequest();
            }

            _context.Entry(adminProf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminProfExists(id))
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

        // POST: api/AdminProfs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AdminProf>> PostAdminProf(AdminProf adminProf)
        {
            _context.AdminProfs.Add(adminProf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdminProf", new { id = adminProf.IdAdmin }, adminProf);
        }

        // DELETE: api/AdminProfs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdminProf(int? id)
        {
            var adminProf = await _context.AdminProfs.FindAsync(id);
            if (adminProf == null)
            {
                return NotFound();
            }

            _context.AdminProfs.Remove(adminProf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AdminProfExists(int? id)
        {
            return _context.AdminProfs.Any(e => e.IdAdmin == id);
        }
    }
}
