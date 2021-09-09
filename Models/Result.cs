using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestOSKI.Models
{
    public class Result
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int TotalPoint { get; set; } = 0;
        //public int QuizId { get; set; }
        public User User { get; set; }
        //public Quiz Quiz { get; set; }
    }
}
