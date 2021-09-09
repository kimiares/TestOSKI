using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestOSKI.Models;

namespace TestOSKI.ViewModels
{
    public class QuizViewModel
    {
        public IEnumerable<Quiz> Quizzes { get; set; }
    }
}
