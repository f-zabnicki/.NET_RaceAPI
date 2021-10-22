using RaceAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Models
{
    public class Result
    {
        public Status Status { get; set; }
        public TimeSpan Time {get; set;} // The result of the race
        public Result(Status status, TimeSpan time)
        {
            Status = status;
            Time = time;
        }
    }
}
