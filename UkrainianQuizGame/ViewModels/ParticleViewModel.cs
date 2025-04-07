using Avalonia.Media;
using System;

namespace UkrainianQuizGame.ViewModels;

public class ParticleViewModel : ViewModelBase
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Size { get; set; }
    public double Speed { get; set; }
    public double Direction { get; set; }
    public IBrush Color { get; set; } = new SolidColorBrush(Colors.White);
    public double Opacity { get; set; } = 1.0;
} 