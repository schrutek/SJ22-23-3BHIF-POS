using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Spg.SpengerSearch.WpfFrontEnd.Converters
{
    public class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Mit partameter steuere ich die Anzeige (text, sterne, zahl)

            if (value is null)
                return "nicht verfügbar";

            if (parameter is null)
                return "kein Param.";

            if (parameter.ToString() == "text")
            {
                switch ((int)value)
                {
                    case 1:
                        return "super";
                    case 2:
                        return "sehr gut";
                    case 3:
                        return "so lala";
                    case 4:
                        return "schlecht";
                    case 5:
                        return "echt müll";
                    default:
                        return "ungültiges Rating";
                }
            }
            else if (parameter.ToString() == "sterne")
            {
                return "TODO...";
            }
            else
            {
                return (int)value;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
