using MahApps.Metro.IconPacks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace PersonalServerManager.Entities
{
    public class HistoryRecordTypeToFontAwesomeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HistoryRecordType recordType)
            {
                switch (recordType)
                {
                    case HistoryRecordType.None:
                        return PackIconFontAwesomeKind.CircleRegular;
                    case HistoryRecordType.Success:
                        return PackIconFontAwesomeKind.CheckCircleSolid;
                    case HistoryRecordType.Warning:
                        return PackIconFontAwesomeKind.ExclamationTriangleSolid;
                    case HistoryRecordType.Error:
                        return PackIconFontAwesomeKind.TimesCircleSolid;
                    case HistoryRecordType.Info:
                        return PackIconFontAwesomeKind.InfoCircleSolid;
                    default:
                        return PackIconFontAwesomeKind.None;
                }
            }
            return PackIconFontAwesomeKind.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class HistoryRecordTypeToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is HistoryRecordType recordType)
            {
                switch (recordType)
                {
                    case HistoryRecordType.None:
                        return Brushes.Gray; // or any other color
                    case HistoryRecordType.Success:
                        return Brushes.Green;
                    case HistoryRecordType.Warning:
                        return Brushes.Orange;
                    case HistoryRecordType.Error:
                        return Brushes.Red;
                    case HistoryRecordType.Info:
                        return Brushes.Blue;
                    default:
                        return Brushes.Gray;
                }
            }
            return Brushes.Gray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
