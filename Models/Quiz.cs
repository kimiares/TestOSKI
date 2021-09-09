using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestOSKI.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

    }
}
