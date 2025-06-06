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

    [HttpGet("health")]
    public IActionResult HealthCheck()
    {
        return Ok(new { status = "OK", timestamp = DateTime.Now });
    }
    
    [HttpGet("avg-duration")]
    public IActionResult GetAverageDurationByLocation()
    {
        var result = _db.EnergyEvents
            .GroupBy(e => e.Location)
            .Select(g => new
            {
                location = g.Key,
                averageDuration = Math.Round(g.Average(e => e.DurationMinutes), 2)
            })
            .ToList();

        return Ok(result);
    }

    [HttpPost("event")]
    public async Task<IActionResult> PostEvent([FromBody] EnergyEvent e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(e.Location) || e.DurationMinutes <= 0 || string.IsNullOrWhiteSpace(e.Cause))
                return BadRequest("Dados inválidos.");

            if (e.Timestamp > DateTime.Now)
                return BadRequest("Data futura não é permitida.");

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

        return Ok(new
        {
            totalEvents = _db.EnergyEvents.Count(),
            eventsByLocation = grouped
        });
    }

    [HttpGet("events")]
    public IActionResult GetAllEvents()
    {
        var events = _db.EnergyEvents
            .OrderByDescending(e => e.Timestamp)
            .ToList();

        return Ok(events);
    }

    [HttpPost("recommendations")]
    public IActionResult SimulateRecommendation([FromBody] EnergyEvent e)
    {
        try
        {
            var recommendation = RulesEngine.GetRecommendation(e);
            return Ok(new { recommendation });
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao processar recomendação: {ex.Message}");
        }
    }
}
