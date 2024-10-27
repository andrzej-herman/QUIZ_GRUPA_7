using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        public void CreateAllQuestions()
        {
            var q1 = new Question();
            q1.Id = 1;
            q1.Category = 100;
            q1.Content = "Jak miał na imię Einstein?";
            q1.Answer_01 = "Albert";
            q1.Answer_02 = "Adam";
            q1.Answer_03 = "Aaron";
            q1.Answer_04 = "Kazik";

            var q2 = new Question();
            q2.Id = 2;
            q2.Category = 200;
            q2.Content = "Jakiego koloru jest niebo?";
            q2.Answer_01 = "niebieskie";
            q2.Answer_02 = "czerwone";
            q2.Answer_03 = "zielone";
            q2.Answer_04 = "czarne";
        }
    }
}
