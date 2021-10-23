using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RaceAPI.Models;
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
        /// Base of all created races
        /// </summary>
        static List<Race> racesDataBase = new List<Race>()
                                    { 
                                        new Race("Race of Colombia", "Colombia",new List<Participant>() 
                                        { 
                                            new Participant("Bob", "Smith", new Result(Data.Status.COMPLETED, new TimeSpan(3,40,34)), true),
                                            new Participant("Will", "Brown", new Result(Data.Status.COMPLETED, new TimeSpan(2,50,14)), true),
                                            new Participant("Andrew", "White", new Result(Data.Status.COMPLETED, new TimeSpan(3,12,58)), true)
                                        })
                                    };

        /// <summary>
        /// Method used to create new Race.
        /// </summary>
        /// <param name="name">Set name of the race.</param>
        /// <param name="location">Set location of the race.</param>
        /// <param name="participants">Set participants of the race.</param>
        [HttpPut]
        [Route("add")]
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
        [Route("update")]
        public void UpdateRace(Race race)
        {
            Race raceToUpdate = FindRace(race.Id);
            raceToUpdate.Name = race.Name;
            raceToUpdate.Location = race.Location;
            raceToUpdate.Participants = race.Participants;
        }

        /// <summary>
        /// Method that return all races.
        /// </summary>
        /// <returns>Return array of all races.</returns>
        [HttpGet]
        [Route("get")]
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
        [Route("add/participant")]
        public void AddParticipantToRace(Guid raceID, Participant participant)
        {
            Race race = FindRace(raceID);
            race.Participants.Add(participant);
        }

        /// <summary>
        /// Get all participants of race.
        /// </summary>
        /// <param name="id">Id of the race.</param>
        /// <returns></returns>
        [HttpGet]
        [Route("get/participant")]
        public Participant[] GetRaceParticipants(Guid id)
        {
            Race r = FindRace(id);
            return r.Participants.ToArray();
        }

        /// <summary>
        /// Deleate participant from the race
        /// </summary>
        /// <param name="raceID">Id of race.</param>
        /// <param name="participantID">Id of participant that need to be removed.</param>
        [HttpDelete]
        [Route("delete/participant")]
        public void DeleateRaceParticipant(Guid raceID, Guid participantID)
        {
            Race race = FindRace(raceID);
            var toBeRemoved = race.Participants.Find(o=> o.ParticipantId == participantID);
            race.Participants.Remove(toBeRemoved);
        }

        /// <summary>
        /// Get times of participants of the race.
        /// </summary>
        /// <param name="id">Id od the race</param>
        [Route("get/time")]
        [HttpGet]
        public IEnumerable<Participant> GetRaceTime(Guid id)
        {
            Race race = FindRace(id);
            return race.Participants.OrderBy(o => o.Result.Time);
        }
        [Route("get")]
        private Race FindRace(Guid raceId)
        {
            return racesDataBase.Find(o => o.Id == raceId);
        }
    }
}
