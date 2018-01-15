using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace App.AgendaEscolar.Converters
{
    public class FormatDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var dataDefault = DateTime.MinValue.ToString("dd/MM/yyyy");
            try
            {
                if (value == null)
                    return dataDefault;

                var data = (DateTimeOffset)value;
                return data.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {
                return dataDefault;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
