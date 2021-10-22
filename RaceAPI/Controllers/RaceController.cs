using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceAPI.Models;
using System;
using System.Collections.Generic;

namespace RaceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RaceController : ControllerBase
    {
        /// <summary>
        /// Base of all created races
        /// </summary>
        List<Race> racesDataBase = new List<Race>() { new Race("Race of Colombia", "Colombia", new List<Participant>())};

        /// <summary>
        /// Method used to create new Race.
        /// </summary>
        /// <param name="name">Set name of the race.</param>
        /// <param name="location">Set location of the race.</param>
        /// <param name="participants">Set participants of the race.</param>
        [HttpPut]
        public void CreateRace(string name, string location, List<Participant> participants )
        {
            Race createdRace = new Race(name, location, participants);
            racesDataBase.Add(createdRace);
        }

        /// <summary>
        /// Update race details.
        /// </summary>
        /// <param name="id">Find race to update by id.</param>
        /// <param name="name">Set new name of the race.</param>
        /// <param name="location">Set new location of the race.</param>
        /// <param name="participants">Set new participants of the race.</param>
        [HttpPost]
        public void UpdateRace(Guid id, string name, string location, List<Participant> participants)
        {
            Race raceToUpdate = racesDataBase.Find(o => o.Id == id);
            racesDataBase.Remove(raceToUpdate);
            raceToUpdate.ChangeRaceDetails(name, location, participants);
            racesDataBase.Add(raceToUpdate);
        }

        /// <summary>
        /// Method that return all races.
        /// </summary>
        /// <returns>Return array of all races.</returns>
        [HttpGet]
        public Race[] GetRaces()
        {
            return racesDataBase.ToArray();
        }

        /// <summary>
        /// Add participant to race.
        /// </summary>
        /// <param name="id">Id od race.</param>
        /// <param name="participant">Participant that need to be added to the race.</param>
        [HttpPost]
        public void AddParticipantToRace(Guid raceID, Participant participant)
        {
            Race race = racesDataBase.Find(o => o.Id == raceID);
            race.Participants.Add(participant);
        }

        /// <summary>
        /// Get all participants of race.
        /// </summary>
        /// <param name="id">Id of the race.</param>
        /// <returns></returns>
        [HttpGet]
        public Participant[] GetRaceParticipants(Guid id)
        {
            Race r = racesDataBase.Find(o => o.Id == id);
            return r.Participants.ToArray();
        }
    }
}
