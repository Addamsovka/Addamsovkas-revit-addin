#region Namespaces
using System;
using System.Windows.Markup;
using System.Windows.Data;
using System.Globalization;
#endregion

namespace Xem
{
    /// <summary>
    /// Direct Value convertor that alllows to use XAML
    /// </summary>
    /// <typeparam name="T">The type of this value convertor</typeparam>
    public abstract class ValueConverter<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        private static T mConvertor = null;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return mConvertor ?? (mConvertor = new T());
        }

        #region Value Convertor Methods
        /// <summary>
        /// Method to conver onr type to another
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

        /// <summary>
        /// Method to convert value back to it's source type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);

        #endregion
    }
}
