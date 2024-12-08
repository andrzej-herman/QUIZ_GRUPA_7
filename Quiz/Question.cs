using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Question : Base
    {
        public int Category { get; set; }     
        public List<Answer> Answers { get; set; }
    }
}
