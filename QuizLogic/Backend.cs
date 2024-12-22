using Quiz;
using System.Text.Json;

namespace QuizLogic
{
    public class Backend
    {
        Random _random;
        int _currentIndex;
        List<Question> _allQuestions;
        List<int> _categories;

        public Backend()
        {
            _random = new Random();
            CreateAllQuestions();
            _categories = _allQuestions.Select(x => x.Category).Distinct().OrderBy(a => a).ToList();
            CurrentGameCategory = _categories[_currentIndex];
        }

       
        public int CurrentGameCategory { get; set; }
        public Question CurrentQuestion { get; set; }
        
        public void GetQuestion()
        {
            var questionsFromCategory = _allQuestions.Where(q => q.Category == CurrentGameCategory).ToList();
            var number = _random.Next(0, questionsFromCategory.Count);
            var selectedQuestion = questionsFromCategory[number];
            selectedQuestion.Answers = selectedQuestion.Answers.OrderBy(a => _random.Next()).ToList();
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
            var maximumCategoryIndex = _categories.Count - 1;
            return _currentIndex == maximumCategoryIndex;
        }

        public void IncreaseCategory()
        {
            _currentIndex++;
            CurrentGameCategory = _categories[_currentIndex];
        }

        private void CreateAllQuestions()
        {
            var path = $"{Directory.GetCurrentDirectory()}\\questions.json";
            var json = File.ReadAllText(path);
            _allQuestions = JsonSerializer.Deserialize<List<Question>>(json)!;
        }
    }
}
