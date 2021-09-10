using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestOSKI.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        //public string Name { get; set; }
        public string TextOfQuestion { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string WrightAnswer { get; set; }

        
        
        public int QuizId { get; set; } 
        public Quiz Quiz { get; set; }
    }
}
