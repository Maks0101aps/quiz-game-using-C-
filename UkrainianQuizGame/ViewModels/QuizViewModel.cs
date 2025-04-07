using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Timers;
using UkrainianQuizGame.Models;

namespace UkrainianQuizGame.ViewModels;

public partial class QuizViewModel : ViewModelBase
{
    private readonly QuizGame _quizGame = new();
    private Timer _countdownTimer;
    private const int QuestionTime = 10; // 10 seconds per question

    [ObservableProperty]
    private Question _currentQuestion;

    [ObservableProperty]
    private bool _showFeedback;

    [ObservableProperty]
    private string _feedbackMessage = string.Empty;

    [ObservableProperty]
    private bool _isCorrectAnswer;

    [ObservableProperty]
    private bool _isFadingIn = true;

    [ObservableProperty]
    private bool _isFadingOut;

    [ObservableProperty]
    private int _timeLeft = QuestionTime;

    [ObservableProperty]
    private string _scoreText = string.Empty;

    public event EventHandler<QuizCompletedEventArgs>? QuizCompleted;

    public QuizViewModel()
    {
        CurrentQuestion = _quizGame.CurrentQuestion;
        UpdateScoreText();
        
        // Countdown timer setup
        _countdownTimer = new Timer(1000); // 1 second interval
        _countdownTimer.Elapsed += CountdownTick;
        _countdownTimer.AutoReset = true;
        
        // Simulate loading animation
        Task.Run(async () =>
        {
            await Task.Delay(500);
            IsFadingIn = false;
            StartTimer();
        });
    }

    private void UpdateScoreText()
    {
        ScoreText = $"Рахунок: {_quizGame.Score} з {_quizGame.Questions.Count}";
    }

    private void StartTimer()
    {
        TimeLeft = QuestionTime;
        _countdownTimer.Start();
    }

    private void StopTimer()
    {
        _countdownTimer.Stop();
    }

    private async void CountdownTick(object? sender, ElapsedEventArgs e)
    {
        await OnUIThread(async () => 
        {
            if (TimeLeft > 0 && !ShowFeedback)
            {
                TimeLeft--;
                
                if (TimeLeft == 0)
                {
                    HandleTimeout();
                }
            }
            await Task.CompletedTask;
        });
    }

    private async void HandleTimeout()
    {
        if (ShowFeedback)
            return;
            
        ShowFeedback = true;
        IsCorrectAnswer = false;
        FeedbackMessage = "Пропущено!";
        
        _quizGame.AnswerQuestion(-1); // -1 to indicate timeout/no answer

        await Task.Delay(1200);
        
        ShowFeedback = false;
        
        if (_quizGame.IsLastQuestion)
        {
            await MoveToResultsScreen();
        }
        else
        {
            _quizGame.MoveToNextQuestion();
            CurrentQuestion = _quizGame.CurrentQuestion;
            StartTimer();
        }
    }

    private async Task MoveToResultsScreen()
    {
        StopTimer();
        IsFadingOut = true;
        await Task.Delay(500); // Transition delay
        
        QuizCompleted?.Invoke(this, new QuizCompletedEventArgs
        {
            Score = _quizGame.Score,
            TotalQuestions = _quizGame.Questions.Count
        });
    }

    private async Task OnUIThread(Func<Task> action)
    {
        try
        {
            await action();
        }
        catch (Exception ex)
        {
            // Handle or log exception if needed
            Console.WriteLine($"Error in UI thread action: {ex.Message}");
        }
    }

    [RelayCommand]
    public async Task SelectAnswer(string answerIndexStr)
    {
        if (!int.TryParse(answerIndexStr, out int answerIndex))
        {
            return;
        }
        
        // Skip clicks on empty options or when feedback is shown
        if (ShowFeedback || answerIndex >= CurrentQuestion.Options.Count || 
            string.IsNullOrEmpty(CurrentQuestion.Options[answerIndex]))
        {
            return;
        }
        
        StopTimer(); // Stop countdown when answer is selected
        
        bool isCorrect = answerIndex == CurrentQuestion.CorrectAnswerIndex;
        IsCorrectAnswer = isCorrect;
        ShowFeedback = true;
        FeedbackMessage = isCorrect ? "✓ Правильно!" : "❌ Неправильно!";

        _quizGame.AnswerQuestion(answerIndex);
        UpdateScoreText();

        await Task.Delay(1200); // Slightly longer delay for animation

        ShowFeedback = false;

        if (_quizGame.IsLastQuestion)
        {
            await MoveToResultsScreen();
        }
        else
        {
            _quizGame.MoveToNextQuestion();
            CurrentQuestion = _quizGame.CurrentQuestion;
            StartTimer(); // Restart timer for the next question
        }
    }
    
    // Clean up resources
    public void Dispose()
    {
        _countdownTimer?.Stop();
        _countdownTimer?.Dispose();
    }
}

public class QuizCompletedEventArgs : EventArgs
{
    public int Score { get; set; }
    public int TotalQuestions { get; set; }
} 