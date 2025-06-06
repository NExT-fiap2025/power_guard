using Microsoft.AspNetCore.Mvc;
using PowerGuard.Data;
using PowerGuard.Models;
using PowerGuard.Services;

namespace PowerGuard.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AnalyticsController : ControllerBase
{
    private readonly AppDbContext _db;

    public AnalyticsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpPost("event")]
    public async Task<IActionResult> PostEvent([FromBody] EnergyEvent e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(e.Location) || e.DurationMinutes <= 0)
                return BadRequest("Dados inválidos.");

            _db.EnergyEvents.Add(e);
            await _db.SaveChangesAsync();

            var recommendation = RulesEngine.GetRecommendation(e);
            return Ok(new { message = "Evento registrado", recommendation });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

    [HttpGet("summary")]
    public IActionResult GetSummary()
    {
        var grouped = _db.EnergyEvents
            .GroupBy(e => e.Location)
            .Select(g => new { Location = g.Key, Count = g.Count() });

        return Ok(grouped);
    }
}
