using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using TaskTuner.Models;

namespace TaskTuner.Converters
{
    public class ImportanceToBrushConverter
    {
        public object Convert(TaskImportance importance)
        {
            return importance switch
            {
                TaskImportance.Low => Application.Current.FindResource("Importance-Low"),
                TaskImportance.Medium => Application.Current.FindResource("Importance-Medium"),
                TaskImportance.High => Application.Current.FindResource("Importance-High"),
                TaskImportance.Critical => Application.Current.FindResource("Importance-Critical"),
                _ => Brushes.Transparent
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}
