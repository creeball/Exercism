using System.Collections.Immutable;
using System.Reactive.Subjects;

public class GameState
{
    public string MaskedWord { get; }
    public ImmutableHashSet<char> GuessedChars { get; }
    public int RemainingGuesses { get; }

    public GameState(string maskedWord, ImmutableHashSet<char> guessedChars, int remainingGuesses)
    {
        MaskedWord = maskedWord;
        GuessedChars = guessedChars;
        RemainingGuesses = remainingGuesses;
    }
}

public class TooManyGuessesException : Exception { }

public class SaveTheCow
{
    private readonly BehaviorSubject<GameState> _stateSubject;
    private readonly Subject<char> _guessSubject;
    public IObservable<GameState> StateObservable => _stateSubject;
    public IObserver<char> GuessObserver => _guessSubject;
    public SaveTheCow(string word)
    {
        _guessSubject = new Subject<char>();
        _stateSubject = new BehaviorSubject<GameState>(
            new GameState(new string('_', word.Length), [], 9));
        _guessSubject.Subscribe(guess =>
        {
            var current = _stateSubject.Value;
            var remainingGuesses = current.RemainingGuesses;
            if (remainingGuesses == 0)
            {
                _stateSubject.OnError(new TooManyGuessesException());
                return;
            }
            var guessedChars = current.GuessedChars;
            if (!word.Contains(guess) || guessedChars.Contains(guess)) remainingGuesses--;
            guessedChars = guessedChars.Add(guess);
            var maskedWord = string.Concat(
                word.Select(c => guessedChars.Contains(c) ? c : '_'));
            if (maskedWord == word) _stateSubject.OnCompleted();
            _stateSubject.OnNext(new GameState(maskedWord, guessedChars, remainingGuesses));
        });
    }
}
