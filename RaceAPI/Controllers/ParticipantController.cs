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
        [HttpPost]
        public void UpdateParticipant()
        {

        }
    }
}
