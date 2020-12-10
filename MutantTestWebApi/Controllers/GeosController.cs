using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MutantTestApp.Models;

namespace MutantTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeosController : ControllerBase
    {
        private readonly Context _context;

        public GeosController(Context context)
        {
            _context = context;
        }

        // GET: api/Geos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Geo>>> GetGeo()
        {
            return await _context.Geo.ToListAsync();
        }

        // GET: api/Geos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Geo>> GetGeo(int id)
        {
            var geo = await _context.Geo.FindAsync(id);

            if (geo == null)
            {
                return NotFound();
            }

            return geo;
        }

        // PUT: api/Geos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeo(int id, Geo geo)
        {
            if (id != geo.Id)
            {
                return BadRequest();
            }

            _context.Entry(geo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoExists(id))
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

        // POST: api/Geos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Geo>> PostGeo(Geo geo)
        {
            _context.Geo.Add(geo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGeo", new { id = geo.Id }, geo);
        }

        // DELETE: api/Geos/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Geo>> DeleteGeo(int id)
        {
            var geo = await _context.Geo.FindAsync(id);
            if (geo == null)
            {
                return NotFound();
            }

            _context.Geo.Remove(geo);
            await _context.SaveChangesAsync();

            return geo;
        }

        private bool GeoExists(int id)
        {
            return _context.Geo.Any(e => e.Id == id);
        }
    }
}
