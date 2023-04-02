using FormulaOneApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOneApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TeamsController : ControllerBase
{
    private static List<Team> teams = new List<Team>()
    {
        new Team() { Id = 1, Name = "the BGs", Country = "Germany", TeamPrinciple = "mercedes"},
        new Team() { Id = 2, Name = "the tops", Country = "Italy", TeamPrinciple = "Ferrari"},
        new Team() { Id = 3, Name = "the magificents", Country = "France", TeamPrinciple = "Renault"},
    };

    [HttpGet]
    [Route("teams")]
    public IActionResult Get()
    {
        return Ok(teams);
    }

    [HttpGet("team/{id}")]
    public IActionResult Get(int id)
    {
        var team = teams.FirstOrDefault(t => t.Id == id);
        if (team == null) return BadRequest("invalid id");
        return Ok(team);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Team team)
    {
        teams.Add(team);
        return CreatedAtAction("Get", team.Id, team);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Team team)
    {
        Team teamToModify = teams.FirstOrDefault(t => t.Id == id);
        if (teamToModify == null) return BadRequest("invalid id");
        teamToModify.Country = team.Country;
        teamToModify.TeamPrinciple = team.TeamPrinciple;
        teamToModify.Name = team.Name;
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        Team team = teams.FirstOrDefault(t => t.Id == id);
        if (team == null) return BadRequest("invalid id");
        teams.Remove(team);
        return NoContent();
    }
}
