using System;
using Windows.UI.Xaml.Data;

namespace App.AgendaEscolar.Converters
{
    public class NullableDateTimeToNullableDateTimeOffsetConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value == null)
                {
                    return new DateTimeOffset?();
                }

                var dateTime = (DateTime)value;

                var dateTimeOffset = new DateTimeOffset(dateTime, TimeZoneInfo.Local.GetUtcOffset(dateTime));

                return dateTimeOffset;
            }
            catch (Exception)
            {
                return DateTimeOffset.MinValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                if (value == null)
                {
                    return new DateTime?();
                }

                var dateTimeOffset = (DateTimeOffset)value;

                return dateTimeOffset.DateTime;
            }
            catch (Exception)
            {
                return DateTimeOffset.MinValue;
            }
        }
    }
}
