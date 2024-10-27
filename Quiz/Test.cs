using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Test
    {
        // zwraca wartosc
        public int AddTwoNumbers(int a, int b)
        {
            return a + b;
        }

        public string ChangeTextToUpperLetters(string text)
        {
            return text.ToUpper();
        }

        // nie zwraca wartości
        public void DisplaySomething()
        {
            Console.WriteLine("SOMETHING");
        }
    }
}
