using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Models
{
    public class Participant
    {
        Guid ParticipantId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Result Result { get; set; }
        public Boolean Payed { get; set; }
        int Number { get; set; } //Ranom Number from 0-1000 to be printed on the participant shirt.
        HashSet<int> numbers = new HashSet<int>();
        Random rng = new Random();
        public Participant(string name, string surname, Result result, bool payed)
        {
            ParticipantId = Guid.NewGuid();
            Name = name;
            Surname = surname;
            Result = result;
            Payed = payed;
            Number = NumberAssigner();
        }
        private int NumberAssigner()
        {
            var range = Enumerable.Range(1, 1000).Where(i => !numbers.Contains(i));
            int index = rng.Next(0, 1000 - numbers.Count);
            int givenNumber = range.ElementAt(index);
            return givenNumber;
        }
        public void UpdateDetails(Guid id, string name, string surname, Result result, bool payed)
        {

        }
    }
}
