using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using UkrainianQuizGame.Models;

namespace UkrainianQuizGame.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? _currentScene;

    [ObservableProperty]
    private bool _isMenuVisible = true;

    [ObservableProperty]
    private bool _isQuizVisible;

    [ObservableProperty]
    private bool _isEndVisible;

    [ObservableProperty]
    private bool _isInstructionsOpen;

    private QuizGame _quizGame = new();

    public MainWindowViewModel()
    {
        
    }

    [RelayCommand]
    public void StartGame()
    {
        NavigateToQuiz();
    }
    
    [RelayCommand]
    public void ShowInstructions()
    {
        IsInstructionsOpen = true;
    }
    
    [RelayCommand]
    public void CloseInstructions()
    {
        IsInstructionsOpen = false;
    }
    
    [RelayCommand]
    public void Exit()
    {
        Environment.Exit(0);
    }

    private void QuizViewModel_QuizCompleted(object? sender, QuizCompletedEventArgs e)
    {
        NavigateToEnd(e.Score, e.TotalQuestions);
    }

    private void EndViewModel_RestartRequested(object? sender, EventArgs e)
    {
        NavigateToQuiz();
    }

    private void EndViewModel_MainMenuRequested(object? sender, EventArgs e)
    {
        NavigateToMenu();
    }

    public void NavigateToMenu()
    {
        IsMenuVisible = true;
        IsQuizVisible = false;
        IsEndVisible = false;
        CurrentScene = null;
    }

    public void NavigateToQuiz()
    {
        QuizViewModel quizViewModel = new();
        quizViewModel.QuizCompleted += QuizViewModel_QuizCompleted;
        
        CurrentScene = quizViewModel;
        IsMenuVisible = false;
        IsQuizVisible = true;
        IsEndVisible = false;
    }

    public void NavigateToEnd(int score, int totalQuestions)
    {
        EndViewModel endViewModel = new(score, totalQuestions);
        endViewModel.RestartRequested += EndViewModel_RestartRequested;
        endViewModel.MainMenuRequested += EndViewModel_MainMenuRequested;
        
        CurrentScene = endViewModel;
        IsMenuVisible = false;
        IsQuizVisible = false;
        IsEndVisible = true;
    }

    public void Dispose()
    {
        if (CurrentScene is QuizViewModel quizViewModel)
        {
            quizViewModel.Dispose();
        }
    }
}
