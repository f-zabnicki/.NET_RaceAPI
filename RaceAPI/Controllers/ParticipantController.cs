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
    public class ParticipantController : Controller
    {
        /// <summary>
        /// Update data details of particiapnt.
        /// </summary>
        [HttpPost]
        public ActionResult UpdateParticipant(Participant participant)
        {
            using(var context = new RaceDBContext())
            {
                var toBeUpdated = context.Participants.FirstOrDefault(p => p.ID == participant.ID);
                if (toBeUpdated == null)
                {
                    return NotFound();
                }
                toBeUpdated.Name = participant.Name;
                toBeUpdated.Surname = participant.Surname;
                toBeUpdated.Result = participant.Result;
                context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Add participant.
        /// </summary>
        [HttpPut]
        public ActionResult AddParticipant(Participant participant)
        {
            using (var context = new RaceDBContext())
            {
                if (participant == null)
                {
                    return NotFound();
                }
                participant.Number = NumberAssigner();
                context.Participants.Add(participant);
                context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Change payment status of participant.
        /// </summary>
        /// <param name="id">Id of participant.</param>
        [HttpPost]
        [Route("payment")]
        public ActionResult ChangePaymentStatus(Guid id)
        {
            using (var context = new RaceDBContext())
            {
                var toBeUpdated = context.Participants.FirstOrDefault(p => p.ID == id);
                if (toBeUpdated == null)
                {
                    return NotFound();
                }
                toBeUpdated.Payed = !toBeUpdated.Payed;
                context.SaveChanges();
                return Ok();
            }
        }

        /// <summary>
        /// Update result of participant
        /// </summary>
        [HttpPost]
        [Route("result")]
        public ActionResult UpdateResultOfParticipant(Participant participant)
        {
            using (var context = new RaceDBContext())
            {
                var toBeUpdated = context.Participants.FirstOrDefault(p => p.ID == participant.ID);
                if (toBeUpdated == null)
                {
                    return NotFound();
                }
                toBeUpdated.Result = participant.Result;
                context.SaveChanges();
                return Ok();
            }
        }
        private int NumberAssigner()
        {
            HashSet<int> numbers = new HashSet<int>();
            using (var context = new RaceDBContext())
            {
                foreach (var item in context.Participants)
                {
                    numbers.Add(item.Number);
                }
                var rng = new Random();
                var range = Enumerable.Range(1, 1000).Where(n => !numbers.Contains(n));
                int index = rng.Next(0, 1000 - context.Participants.Count());
                int givenNumber = range.ElementAt(index);
                return givenNumber;
            }
        }
    }
}
