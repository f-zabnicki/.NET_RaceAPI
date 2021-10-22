using RaceAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceAPI.Models
{
    public class Result
    {
        Status Status { get; set; }
        TimeSpan Time {get; set;} // The result of the race
    }
}
