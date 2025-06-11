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
    }
}
