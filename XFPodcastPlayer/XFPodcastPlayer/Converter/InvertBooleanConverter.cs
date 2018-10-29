﻿using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XFPodcastPlayer.Converter
{
    public class InvertBoolenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                return !(bool)value;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }
}
