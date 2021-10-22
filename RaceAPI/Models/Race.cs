using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Models
{
    public class Race
    {
        Guid Id { get; set; }
        string Name { get; set; }
        String Location { get; set; }
        Participant[] Participants { get; set; }
    }

}
