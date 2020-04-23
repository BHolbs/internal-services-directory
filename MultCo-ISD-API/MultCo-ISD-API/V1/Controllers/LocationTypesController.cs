﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultCo_ISD_API.Models;

namespace MultCo_ISD_API.V1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationTypesController : ControllerBase
    {
        private readonly InternalServicesDirectoryV1Context _context;

        public LocationTypesController(InternalServicesDirectoryV1Context context)
        {
            _context = context;
        }

        // GET: api/LocationTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationTypeV1DTOValidator>>> GetLocationType()
        {
            return await _context.LocationType.ToListAsync();
        }

        // GET: api/LocationTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationTypeV1DTOValidator>> GetLocationType(int id)
        {
            var locationType = await _context.LocationType.FindAsync(id);

            if (locationType == null)
            {
                return NotFound();
            }

            return locationType;
        }

        // PUT: api/LocationTypes/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationType(int id, LocationTypeV1DTOValidator locationType)
        {
            if (id != locationType.LocationTypeId)
            {
                return BadRequest();
            }

            _context.Entry(locationType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocationTypeExists(id))
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

        // POST: api/LocationTypes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<LocationTypeV1DTOValidator>> PostLocationType(LocationTypeV1DTOValidator locationType)
        {
            _context.LocationType.Add(locationType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocationType", new { id = locationType.LocationTypeId }, locationType);
        }

        // DELETE: api/LocationTypes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LocationTypeV1DTOValidator>> DeleteLocationType(int id)
        {
            var locationType = await _context.LocationType.FindAsync(id);
            if (locationType == null)
            {
                return NotFound();
            }

            _context.LocationType.Remove(locationType);
            await _context.SaveChangesAsync();

            return locationType;
        }

        private bool LocationTypeExists(int id)
        {
            return _context.LocationType.Any(e => e.LocationTypeId == id);
        }
    }
}
