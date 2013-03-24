using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using Umc.Core.Tools.VSGesture.Actions;

namespace Umc.Core.Tools.VSGesture.OptionPages
{
	public class GestureSeleectedValueConverter : IValueConverter
	{

		#region IValueConverter 멤버

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return "File.Close";
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

		#endregion
	}
}
