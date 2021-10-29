using System;
using System.ComponentModel.DataAnnotations;

namespace RaceAPI.Models
{
    public class Participant
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Result Result { get; set; }
        public Boolean Payed { get; set; }
        public int Number { get; set; } 
        public Participant()
        {
            ID = Guid.NewGuid();
            Payed = false;
        }
    }
}
