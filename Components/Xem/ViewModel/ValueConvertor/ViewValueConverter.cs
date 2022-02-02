#region Namespaces
using System;
using System.Diagnostics;
using System.Globalization;
#endregion

namespace Xem
{
    class ViewValueConverter : ValueConverter<ViewValueConverter>
    {
        /// <summary>
        /// Converts the window page <see cref="PageEnum"/> to an actual page or view
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Gets the page according the value in enum
            switch ((PageEnum)value)
            {
                case PageEnum.EditExportSettingsPage:
                    return new EditExportSettingsPage();

                case PageEnum.ExportSettingsListPage:
                    return new ExportSettingsListPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
