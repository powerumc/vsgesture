using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Umc.Core.Tools.VSGesture.Actions;
using Umc.Core.Tools.VSGesture.Services;

namespace Umc.Core.Tools.VSGesture.OptionPages
{
	/// <summary>
	/// OptionPageMouseActionControlWPF.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class OptionPageMouseActionControlWPF : UserControl
	{
		public OptionPageMouseActionControlWPF()
		{
			InitializeComponent();
			//Umc.Core.Tools.VSGesture.Services.VSGestureService.Current.GestureActionList.GestureItem
		}
	}
}
