using RaceAPI.Data;
using System;
using System.ComponentModel.DataAnnotations;

namespace RaceAPI.Models
{
    public class Result
    {
        [Key]
        public int ID { get; set; }
        public Status Status { get; set; }
        public TimeSpan Time {get; set;}
    }
}
