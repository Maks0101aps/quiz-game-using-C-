using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace UkrainianQuizGame.Converters;

public class StringNotNullOrEmptyConverter : IValueConverter
{
    public static readonly StringNotNullOrEmptyConverter Instance = new();

    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return !string.IsNullOrEmpty(value as string);
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
} 