using Quiz;


// powołanie obiektów BC
var backened = new Backend();

// stworzenie listy wszystkich pytań => w konstruktorze
// ustawienie kategorii na najniższą  => w konstruktorze

// wyświetlanie ekranu powitalnego
Frontend.DisplayWelcomeScreen();

while(true)
{
    // losowanie pytania z aktualnej kategorii
    backened.GetQuestion();

    // wyświetlanie pytania
    var playerChoice = Frontend.DisplayQuestionAndGetAnswer(backened.CurrentQuestion);

    // walidacja odpowiedzi gracza
    var isCorrect = backened.CheckAnswer(playerChoice);

    if (isCorrect)
    {
        if (backened.CheckIfLastCategory())
        {
            Frontend.QuizSuccess();
            break;
        }
        else
        {
            Frontend.AnswerCorrect(backened.CurrentGameCategory);
            backened.IncreaseCategory();
        }
    }
    else
    {
        Frontend.GameOver();
        break;
    }
}




Console.ReadLine();

