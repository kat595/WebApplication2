﻿using Microsoft.AspNetCore.Mvc;
using WebApplication2.Entities;

namespace WebApplication2.Controllers
{
    [Route("api/league")]
    public class LeagueController : ControllerBase
    {
        private readonly TiproomDbContext _dbContext;

        public LeagueController(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<League>> GetAll()
        {
            var leagues = _dbContext
                .Leagues
                .ToList();

            return Ok(leagues);
        }

        [HttpGet("{id}")]
        public ActionResult<League> Get([FromRoute] int id)
        {
            var league = _dbContext
                .Leagues
                .FirstOrDefault(u => u.Id == id);

            if (league is null) return NotFound();

            return Ok(league);

        }

    }
}