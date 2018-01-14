using App.AgendaEscolar.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace App.AgendaEscolar.Converters
{
    public class EnumToIntConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (int)(TipoCompromisso)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (TipoCompromisso)(int)value;
        }
    }
}
