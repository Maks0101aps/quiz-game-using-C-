using Avalonia.Controls;
using Avalonia.Input;
using UkrainianQuizGame.ViewModels;

namespace UkrainianQuizGame.Views;

public partial class QuizView : UserControl
{
    public QuizView()
    {
        InitializeComponent();
        // Handle keyboard input for number keys
        KeyDown += QuizView_KeyDown;
    }

    private void QuizView_KeyDown(object? sender, KeyEventArgs e)
    {
        if (DataContext is QuizViewModel viewModel && !viewModel.ShowFeedback)
        {
            if (e.Key >= Key.D1 && e.Key <= Key.D9)
            {
                int keyNumber = (int)e.Key - (int)Key.D1;
                if (keyNumber < viewModel.CurrentQuestion.Options.Count)
                {
                    viewModel.SelectAnswerCommand.Execute(keyNumber.ToString());
                }
            }
            else if (e.Key >= Key.NumPad1 && e.Key <= Key.NumPad9)
            {
                int keyNumber = (int)e.Key - (int)Key.NumPad1;
                if (keyNumber < viewModel.CurrentQuestion.Options.Count)
                {
                    viewModel.SelectAnswerCommand.Execute(keyNumber.ToString());
                }
            }
        }
    }

    protected override void OnAttachedToVisualTree(Avalonia.VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        // Ensure control can receive focus for keyboard events
        this.Focus();
    }
} 