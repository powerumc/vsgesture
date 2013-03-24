using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Text.Editor;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;

namespace Umc.Core.Tools.VSGesture.Shell
{
    public class GestureWpfWindow : MouseProcessorBase, IDisposable
    {
        private VSGestureAnalyzer _analyzer = new VSGestureAnalyzer();
        private bool _isMouseDown;
        private double _preX, _preY;

        readonly IWpfTextView _view;
        IAdornmentLayer _layer;
        Image _image;

		static bool _isMouseDownIsCreatedHookObject = false;

        public GestureWpfWindow(IWpfTextView view)
        {
            this._view = view;
        }

        public override void PreprocessMouseRightButtonUp(System.Windows.Input.MouseButtonEventArgs e)
        {
            _isMouseDownIsCreatedHookObject = false;
            if (this._isMouseDown)
            {
                e.Handled = this._analyzer.Count > 10;
                this._analyzer.Analyzer();
            }
            this._isMouseDown = false;
            this._layer = this._view.GetAdornmentLayer("VSGestureWindow");
            this._layer.RemoveAllAdornments();
        }
    
        public override void PostprocessMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
			try
			{
				if (Umc.Core.Tools.VSGesture.Services.VSGestureService.Current.VSGestureInfo.UserSettings.EnableVSGesture && (e.RightButton == System.Windows.Input.MouseButtonState.Pressed))
				{
					this._isMouseDown = true;
					Point position = e.GetPosition(this._view.VisualElement);
					this._preX = position.X + this._view.ViewportLeft;
					this._preY = position.Y + this._view.ViewportTop;
					
                    if (!_isMouseDownIsCreatedHookObject)
					{
						_isMouseDownIsCreatedHookObject = true;
					}
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}

        }

        public override void PostprocessMouseMove(System.Windows.Input.MouseEventArgs e)
        {
			try
			{
				if (this._isMouseDown && (e.RightButton == System.Windows.Input.MouseButtonState.Pressed))
				{
					string lineColor = Umc.Core.Tools.VSGesture.Services.VSGestureService.Current.VSGestureInfo.UserSettings.LineColor;
					string lineThickness = Umc.Core.Tools.VSGesture.Services.VSGestureService.Current.VSGestureInfo.UserSettings.LineThickness;
					string[] strArray = lineColor.Split(new char[] { ',' });
					Point position = e.GetPosition(this._view.VisualElement);
					Brush brush = new SolidColorBrush(Color.FromRgb(byte.Parse(strArray[0]), byte.Parse(strArray[1]), byte.Parse(strArray[2])));
					this._analyzer.Add(new System.Windows.Input.StylusPoint(position.X, position.Y));
					this._layer = this._view.GetAdornmentLayer("VSGestureWindow");
					var adornment = new System.Windows.Shapes.Line
					{
						X1 = this._preX,
						Y1 = this._preY,
						X2 = position.X + this._view.ViewportLeft,
						Y2 = position.Y + this._view.ViewportTop,
						StrokeThickness = (float)((Umc.Core.Tools.VSGesture.Controls.LineThicknessStyle)Enum.Parse(typeof(Umc.Core.Tools.VSGesture.Controls.LineThicknessStyle), lineThickness)),
						Stroke = brush
					};
					this._layer.AddAdornment(AdornmentPositioningBehavior.ViewportRelative, null, null, adornment, null);
					this._preX = position.X + this._view.ViewportLeft;
					this._preY = position.Y + this._view.ViewportTop;
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show(exception.Message);
			}
			base.PostprocessMouseMove(e);

        }



        public void Dispose()
        {
            _analyzer = null;
            //pen = null;
        }
    }
}
