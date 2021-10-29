using Microsoft.AspNetCore.Mvc;
using RaceAPI.Models;
using RaceAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceParticipantController : Controller
    {
        [HttpPost]
        public ActionResult AddParticipantToRace(Guid raceID, Participant participant)
        {
            using (var context = new RaceDBContext())
            {
                var race = context.Races.FirstOrDefault(r => r.ID == raceID);
                if (race == null || participant == null)
                {
                    return NotFound();
                }
                race.Participants.Add(participant);
                context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Get all participants of race.
        /// </summary>
        /// <param name="id">Id of the race.</param>
        /// <returns></returns>
        [HttpGet]
        public Participant[] GetRaceParticipants(Guid id)
        {
            using (var context = new RaceDBContext())
            {
                var race = context.Races.FirstOrDefault(r => r.ID == id);
                if (race == null)
                {
                    throw new KeyNotFoundException("Invalid ID.");
                }
                return race.Participants.ToArray();
            }
        }

        /// <summary>
        /// Deleate participant from the race
        /// </summary>
        /// <param name="raceID">Id of race.</param>
        /// <param name="participantID">Id of participant that need to be removed.</param>
        [HttpDelete]
        public ActionResult DeleateRaceParticipant(Guid raceID, Guid participantID)
        {
            using (var context = new RaceDBContext())
            {
                var race = context.Races.FirstOrDefault(o => o.ID == raceID);
                var toBeRemoved = race.Participants.FirstOrDefault(p=>p.ID == participantID);
                if (race == null || toBeRemoved == null)
                {
                    return NotFound();
                }
                race.Participants.Remove(toBeRemoved);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
