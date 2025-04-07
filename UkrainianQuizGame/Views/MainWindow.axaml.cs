using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using Avalonia.Threading;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using UkrainianQuizGame.ViewModels;

namespace UkrainianQuizGame.Views;

public partial class MainWindow : Window
{
    private readonly ObservableCollection<ParticleViewModel> _particles = new();
    private readonly Random _random = new();
    private readonly Timer _particleTimer = new(50); // 50ms for smooth animation
    private readonly DispatcherTimer _titleAnimationTimer;

    public MainWindow()
    {
        InitializeComponent();

        this.Opened += MainWindow_Opened;
        this.Closing += MainWindow_Closing;

        // Setup title animation
        _titleAnimationTimer = new DispatcherTimer
        {
            Interval = TimeSpan.FromSeconds(2)
        };
        _titleAnimationTimer.Tick += TitleAnimation_Tick;
        _titleAnimationTimer.Start();

        // Setup background particles
        if (this.FindControl<ItemsControl>("BackgroundParticles") is ItemsControl particlesControl)
        {
            particlesControl.ItemsSource = _particles;
            
            // Initialize particles
            for (int i = 0; i < 50; i++)
            {
                _particles.Add(CreateRandomParticle());
            }
            
            _particleTimer.Elapsed += ParticleTimer_Elapsed;
            _particleTimer.AutoReset = true;
        }
    }

    private void MainWindow_Opened(object? sender, EventArgs e)
    {
        _particleTimer.Start();
    }

    private void MainWindow_Closing(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        _particleTimer.Stop();
        _titleAnimationTimer.Stop();
        
        // Dispose any resources if needed
        if (DataContext is MainWindowViewModel viewModel)
        {
            viewModel.Dispose();
        }
    }

    private ParticleViewModel CreateRandomParticle()
    {
        double speedFactor = _random.NextDouble() * 2 + 0.5;
        double sizeFactor = _random.NextDouble() * 3 + 2;
        
        Color[] particleColors = new[] 
        { 
            Color.Parse("#4B6EAF"), 
            Color.Parse("#3A579A"), 
            Color.Parse("#5E7EC1"),
            Color.Parse("#7290D5"),
            Color.Parse("#2A4A8C")
        };
        
        return new ParticleViewModel
        {
            X = _random.Next(0, (int)(this.Width > 0 ? this.Width : 800)),
            Y = _random.Next(0, (int)(this.Height > 0 ? this.Height : 600)),
            Size = sizeFactor,
            Speed = speedFactor,
            Direction = _random.NextDouble() * Math.PI * 2,
            Color = new SolidColorBrush(particleColors[_random.Next(particleColors.Length)]),
            Opacity = _random.NextDouble() * 0.5 + 0.1
        };
    }

    private void TitleAnimation_Tick(object? sender, EventArgs e)
    {
        if (this.FindControl<TextBlock>("TitleText") is TextBlock title)
        {
            // Get current scale or default to 1
            double currentScale = 1.0;
            
            if (title.RenderTransform is ScaleTransform scaleTransform)
            {
                currentScale = scaleTransform.ScaleX;
            }
            else if (title.RenderTransform is TransformGroup transformGroup)
            {
                var existingScaleTransform = transformGroup.Children.OfType<ScaleTransform>().FirstOrDefault();
                if (existingScaleTransform != null)
                {
                    currentScale = existingScaleTransform.ScaleX;
                }
            }
            
            // Toggle between 0.95 and 1.05
            double targetScale = currentScale >= 1.0 ? 0.95 : 1.05;
            
            // Apply new transform
            title.RenderTransform = new ScaleTransform(targetScale, targetScale);
        }
    }

    private void ParticleTimer_Elapsed(object? sender, ElapsedEventArgs e)
    {
        Dispatcher.UIThread.Post(() =>
        {
            double width = this.Width > 0 ? this.Width : 800;
            double height = this.Height > 0 ? this.Height : 600;
            
            foreach (var particle in _particles)
            {
                // Move particle based on direction and speed
                particle.X += Math.Cos(particle.Direction) * particle.Speed;
                particle.Y += Math.Sin(particle.Direction) * particle.Speed;
                
                // Handle edge cases - wrap around
                if (particle.X < -particle.Size) particle.X = width + particle.Size;
                if (particle.X > width + particle.Size) particle.X = -particle.Size;
                if (particle.Y < -particle.Size) particle.Y = height + particle.Size;
                if (particle.Y > height + particle.Size) particle.Y = -particle.Size;
            }
            
            // Occasionally add new particles or remove old ones
            if (_random.NextDouble() < 0.05)
            {
                _particles.Add(CreateRandomParticle());
                
                // Keep particle count reasonable
                if (_particles.Count > 60 && _random.NextDouble() < 0.5)
                {
                    _particles.RemoveAt(0);
                }
            }
        });
    }
}