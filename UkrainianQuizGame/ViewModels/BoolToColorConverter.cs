using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace UkrainianQuizGame.ViewModels;

public class BoolToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is bool boolValue && parameter is string colorParams)
        {
            string[] colors = colorParams.Split(',');
            string trueColor = colors[0];
            string falseColor = colors.Length > 1 ? colors[1] : "#808080"; // Серый по умолчанию, если второй цвет не указан
            
            return boolValue 
                ? SolidColorBrush.Parse(trueColor) 
                : SolidColorBrush.Parse(falseColor);
        }
        
        return new SolidColorBrush(Colors.Gray);
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
} 