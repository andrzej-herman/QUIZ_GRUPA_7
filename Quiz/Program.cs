using Quiz;


// powołanie obiektów BC
var backened = new Backend();


// stworzenie listy wszystkich pytań => w konstruktorze
// ustawienie kategorii na najniższą  => w konstruktorze

// wyświetlanie ekranu powitalnego
Frontend.DisplayWelcomeScreen();

// losowanie pytania z aktualnej kategorii
backened.GetQuestion();

// wyświetlanie pytania
var playerChoice = Frontend.DisplayQuestion(backened.CurrentQuestion);

// walidacja odpowiedzi gracza
var isCorrect = backened.CheckAnswer(playerChoice);

if (isCorrect)
{
    Console.WriteLine();
    Console.WriteLine(" HURRA !!!!!");
}
else
{
    Console.WriteLine();
    Console.WriteLine(" GAME OVER !!!!");
}

Console.ReadLine();

