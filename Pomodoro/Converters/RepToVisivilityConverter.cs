using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Pomodoro.Converters
{
    public class RepToVisivilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int reps = (int)value;
            if (reps % 8 == 1)
            {
                return Visibility.Collapsed;
            }
            if(reps % 8 == 0)
            {
                return Visibility.Visible;
            }
            switch (parameter)
            {
                case "1":
                    return reps % 8 >= 2 ? Visibility.Visible : Visibility.Collapsed;
                case "2":
                    return reps % 8 >= 4 ? Visibility.Visible : Visibility.Collapsed;
                case "3":
                    return reps % 8 >= 6 ? Visibility.Visible : Visibility.Collapsed;
                default:
                    return Visibility.Collapsed;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
