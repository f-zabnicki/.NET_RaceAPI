using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceAPI.Models;
using RaceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RaceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceController : ControllerBase
    {
        /// <summary>
        /// Method used to create new Race.
        /// </summary>
        /// <param name="name">Set name of the race.</param>
        /// <param name="location">Set location of the race.</param>
        /// <param name="participants">Set participants of the race.</param>
        [HttpPut]
        public ActionResult CreateRace(string name, string location, List<Participant> participants = null )
        {
            using(var context = new RaceDBContext())
            {
                context.Races.Add(new Race() { Name = name, Location = location, Participants = participants });
                context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Update race details.
        /// </summary>
        /// <param name="id">Find race to update by id.</param>
        /// <param name="name">Set new name of the race.</param>
        /// <param name="location">Set new location of the race.</param>
        /// <param name="participants">Set new participants of the race.</param>
        [HttpPost]
        public ActionResult UpdateRace(Race race)
        {
            using (var context = new RaceDBContext())
            {
                var toBeUpdated = context.Races.FirstOrDefault(r => r.ID == race.ID);
                if (toBeUpdated == null)
                {
                    return NotFound();
                }
                toBeUpdated.Name = race.Name;
                toBeUpdated.Location = race.Location;
                toBeUpdated.Participants = race.Participants;
                context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Method that return all races.
        /// </summary>
        /// <returns>Return array of all races.</returns>
        [HttpGet]
        public Race[] GetRaces()
        {
            using (var context = new RaceDBContext())
            {
                return context.Races.ToArray();
            }
        }

        /// <summary>
        /// Get times of participants of the race.
        /// </summary>
        /// <param name="id">Id od the race</param>
        [Route("get/time")]
        [HttpGet]
        public IEnumerable<Participant> GetRaceTime(Guid id)
        {
            using (var context = new RaceDBContext())
            {
                var race = context.Races.FirstOrDefault(r=> r.ID == id);
                if (race == null)
                {
                    throw new KeyNotFoundException("Invalid ID.");
                }
                return race.Participants.OrderBy(o => o.Result.Time);
            }
        }
    }
}
