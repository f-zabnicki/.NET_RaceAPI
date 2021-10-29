using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RaceAPI.Models
{
    public class Race
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public List<Participant> Participants { get; set; }
        public Race()
        {
            ID = Guid.NewGuid();
        }
    }
}
