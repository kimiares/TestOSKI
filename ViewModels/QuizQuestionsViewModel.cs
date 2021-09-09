using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestOSKI.Models;

namespace TestOSKI.ViewModels
{
    public class QuizQuestionsViewModel
    {
        public Quiz Quiz { get; set; }
        public List<Question> Questions { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
