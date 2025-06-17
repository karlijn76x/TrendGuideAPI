using FunnelTrendRadarAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TrendGuideAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TrendsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TrendsController(AppDbContext context)
        {
            _context = context;
        }

        private bool TrendExists(long id)
        {
            return _context.Trend.Any(e => e.Id == id);
        }

        [HttpGet(Name = "GetTrends")]
        public async Task<IActionResult> GetTrends()
        {
            var trends = await _context.Trend.ToListAsync();
            if (trends == null || trends.Count == 0)
            {
                return NotFound("No trends found in the database");
            }
            return Ok(trends);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Trend>> GetTrend(int id)
        {
            var trend = await _context.Trend.FindAsync(id);

            if (trend == null)
            {
                return NotFound();
            }

            return trend;
        }

        [HttpPost]
        public async Task<ActionResult<Trend>> PostTrend(Trend trend)
        {
            _context.Trend.Add(trend);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrends), new { id = trend.Id }, trend);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrend(long id, Trend trend)
        {
            if (id != trend.Id)
            {
                return BadRequest();
            }

            _context.Entry(trend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrendExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrend(int id)
        {
            var trend = await _context.Trend.FindAsync(id);
            if (trend == null)
            {
                return NotFound();
            }

            _context.Trend.Remove(trend);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
