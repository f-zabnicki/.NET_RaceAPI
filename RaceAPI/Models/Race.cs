using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Models
{
    public class Race
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Participant> Participants { get; set; }
        public Race(string name, string location, List<Participant> participants = null)
        {
            Id = Guid.NewGuid();
            Name = name;
            Location = location;
            Participants = participants;
        }
    }
}
