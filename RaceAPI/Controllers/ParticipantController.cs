using Microsoft.AspNetCore.Mvc;
using RaceAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class ParticipantController : Controller
    {
        List<Participant> participantsDataBase = new List<Participant>();

        /// <summary>
        /// Update data details of particiapnt.
        /// </summary>
        /// <param name="id">Id of participant.</param>
        /// <param name="name">New name of participant.</param>
        /// <param name="surname">New surname of participant.</param>
        /// <param name="result">New result of participant.</param>
        /// <param name="payed">New payment status of participant.</param>
        [HttpPost]
        public void UpdateParticipant(Guid id, string name, string surname, Result result, bool payed)
        {
            var toBeUpdated = participantsDataBase.Find(o => o.ParticipantId == id);
            participantsDataBase.Remove(toBeUpdated);
            toBeUpdated.UpdateDetails(name, surname, result, payed);
            participantsDataBase.Add(toBeUpdated);
        }

        /// <summary>
        /// Change payment status of participant.
        /// </summary>
        /// <param name="id">Id of participant.</param>
        [HttpPost]
        public void ChangePaymentStatus(Guid id)
        {
            var p = participantsDataBase.Find(o => o.ParticipantId == id);
            p.Payed = !p.Payed;
        }

        /// <summary>
        /// Update result of participant
        /// </summary>
        /// <param name="id">Id od participant</param>
        /// <param name="result">New result</param>
        [HttpPost]
        public void UpdateResultOfParticipant(Guid id, Result result)
        {
            var toBeUpdated = participantsDataBase.Find(o => o.ParticipantId == id);
            participantsDataBase.Remove(toBeUpdated);
            toBeUpdated.UpdateResult(result);
            participantsDataBase.Add(toBeUpdated);
        }
    }
}
