using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;

namespace UkrainianQuizGame.ViewModels;

public partial class MenuViewModel : ViewModelBase
{
    [ObservableProperty]
    private bool _isInstructionsOpen;

    [ObservableProperty]
    private bool _isFadingOut;

    public event EventHandler? StartGameRequested;
    public event EventHandler? ExitRequested;

    [RelayCommand]
    public async Task StartGame()
    {
        IsFadingOut = true;
        await Task.Delay(500); // Delay for animation
        StartGameRequested?.Invoke(this, EventArgs.Empty);
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
        ExitRequested?.Invoke(this, EventArgs.Empty);
    }
} 