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
        static List<Participant> participantsDataBase = new List<Participant>();

        /// <summary>
        /// Update data details of particiapnt.
        /// </summary>
        /// <param name="id">Id of participant.</param>
        /// <param name="name">New name of participant.</param>
        /// <param name="surname">New surname of participant.</param>
        /// <param name="result">New result of participant.</param>
        /// <param name="payed">New payment status of participant.</param>
        [HttpPost]
        public void UpdateParticipant(Participant participant)
        {
            var toBeUpdated = participantsDataBase.Find(o => o.ParticipantId == participant.ParticipantId);
            toBeUpdated.Name = participant.Name;
            toBeUpdated.Surname = participant.Surname;
            toBeUpdated.Result = participant.Result;
            toBeUpdated.Payed = participant.Payed;
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
        public void UpdateResultOfParticipant(Participant participant)
        {
            var toBeUpdated = participantsDataBase.Find(o => o.ParticipantId == participant.ParticipantId);
            toBeUpdated.Payed = participant.Payed;
        }
    }
}
