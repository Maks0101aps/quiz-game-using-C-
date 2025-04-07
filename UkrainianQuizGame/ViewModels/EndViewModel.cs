using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace UkrainianQuizGame.ViewModels;

public partial class EndViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _resultMessage = string.Empty;

    [ObservableProperty]
    private bool _isFadingIn = true;
    
    [ObservableProperty]
    private bool _isFadingOut;

    public event EventHandler? RestartRequested;
    public event EventHandler? MainMenuRequested;

    public EndViewModel(int score, int totalQuestions)
    {
        ResultMessage = $"Твій результат: {score} з {totalQuestions}";
        
        // Simulate loading animation
        Task.Run(async () =>
        {
            await Task.Delay(500);
            IsFadingIn = false;
        });
    }

    [RelayCommand]
    public async Task Restart()
    {
        IsFadingOut = true;
        await Task.Delay(500); // Animation delay
        RestartRequested?.Invoke(this, EventArgs.Empty);
    }

    [RelayCommand]
    public async Task GoToMainMenu()
    {
        IsFadingOut = true;
        await Task.Delay(500); // Animation delay
        MainMenuRequested?.Invoke(this, EventArgs.Empty);
    }
} 