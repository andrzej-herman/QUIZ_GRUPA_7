using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Quiz
{
    public class Backend
    {
        Random random;

        public Backend()
        {
            random = new Random();
            CreateAllQuestions();
            Categories = AllQuestions.Select(x => x.Category).Distinct().OrderBy(a => a).ToList();
            CurrentGameCategory = Categories[CurrentIndex];
        }

        public int CurrentIndex { get; set; }
        public List<int> Categories { get; set; }
        public List<Question> AllQuestions { get; set; }
        public int CurrentGameCategory { get; set; }
        public Question CurrentQuestion { get; set; }

        public void CreateAllQuestions()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\questions.json";
            var json = File.ReadAllText(path);
            AllQuestions = JsonSerializer.Deserialize<List<Question>>(json)!;
        }
        
        public void GetQuestion()
        {
            var questionsFromCategory = AllQuestions.Where(q => q.Category == CurrentGameCategory).ToList();
            var number = random.Next(0, questionsFromCategory.Count);
            var selectedQuestion = questionsFromCategory[number];
            selectedQuestion.Answers = selectedQuestion.Answers.OrderBy(a => random.Next()).ToList();
            var id = 1;
            selectedQuestion.Answers.ForEach(a => a.Id = id++);
            CurrentQuestion = selectedQuestion;
        }

        public bool CheckAnswer(int playerNumber)
        {
            bool result = false;
            foreach (var answer in CurrentQuestion.Answers)
            {
                if (answer.Id == playerNumber)
                {
                    result = answer.IsCorrect;
                    break;
                }
            }

            return result;
        }

        public bool CheckIfLastCategory()
        {
            var maximumCategoryIndex = Categories.Count - 1;
            return CurrentIndex == maximumCategoryIndex;
        }

        public void IncreaseCategory()
        {
            CurrentIndex++;
            CurrentGameCategory = Categories[CurrentIndex];
        }
    }
}
