using System.Collections.Generic;

namespace UkrainianQuizGame.Models;

public class Question
{
    public string Text { get; set; } = string.Empty;
    public List<string> Options { get; set; } = new List<string>();
    public int CorrectAnswerIndex { get; set; }
} 