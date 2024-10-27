using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Question
    {
        public int Id { get; set; }
        public int Category { get; set; }
        public string Content { get; set; }
        public string Answer_01 { get; set; }
        public string Answer_02 { get; set; }
        public string Answer_03 { get; set; }
        public string Answer_04 { get; set; }
    }
}
