using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using System.Windows.Ink;
using System.Windows.Controls;
using System.Windows.Input;
using Umc.Core.Tools.VSGesture.Actions;
using Umc.Core.Tools.VSGesture.Services;

namespace Umc.Core.Tools.VSGesture
{
	public class VSGestureAnalyzer : ICollection<StylusPoint>
	{
		private InkCanvas canvas					= new InkCanvas();
		private StylusPointCollection pointCollection	= new StylusPointCollection();

		public VSGestureAnalyzer()
		{
			this.canvas.Width	= Screen.PrimaryScreen.Bounds.Width;
			this.canvas.Height	= Screen.PrimaryScreen.Bounds.Height;

			canvas.EditingMode = InkCanvasEditingMode.GestureOnly;
		}

		public void Analyzer()
		{
			StrokeCollection collection = null;
			try
			{
				if (this.Count < 10) return;

				GestureRecognizer gestureRecognizer = new GestureRecognizer();

				canvas.SetEnabledGestures(new ApplicationGesture[] { ApplicationGesture.AllGestures });
				gestureRecognizer.SetEnabledGestures(new ApplicationGesture[] { ApplicationGesture.AllGestures });

				Stroke stroke = new Stroke(pointCollection);
				collection = new StrokeCollection();
				collection.Add(stroke);

				var result = gestureRecognizer.Recognize(collection);

				if (result[0].ApplicationGesture != null)
				{
					if (result[0].ApplicationGesture != ApplicationGesture.NoGesture)
					{
						var resultGesture = VSGestureService.Current.VSGestureInfo.GestureActionMapper.Find(
						o => o.GestureActionType.ToString() == result[0].ApplicationGesture.ToString());

						if (resultGesture != null)
						{
							//MessageBox.Show(resultGesture.Value);
							var action = VSGestureService.Current.GestureActionList.GestureItem.Find( o => o.Name == resultGesture.GestureItemName );
							if (action == null ) return;

							if (resultGesture.ActionType == ActionType.Command)
							{

								var cmd = new ActionCommand(new ExecuteCommand(action.Value, action.Argument));
								cmd.Execute();
							}
							else if (resultGesture.ActionType == ActionType.Action)
							{
								var cmd = new ActionCommand(new ExecuteCustomCommand(action.Value));
								cmd.Execute();
							}
						}
					}
				}
			}
			catch (System.Runtime.InteropServices.COMException exCom)
			{
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			finally
			{
				pointCollection = null;
				pointCollection = new StylusPointCollection();
			}
		}

		#region ICollection<StylusPoint> 멤버

		public void Add(StylusPoint item)
		{
			pointCollection.Add(item);
		}

		public void Clear()
		{
			pointCollection.Clear();
		}

		public bool Contains(StylusPoint item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(StylusPoint[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public int Count
		{
			get { return pointCollection.Count; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		public bool Remove(StylusPoint item)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IEnumerable<StylusPoint> 멤버

		public IEnumerator<StylusPoint> GetEnumerator()
		{
			return pointCollection.GetEnumerator();
		}

		#endregion

		#region IEnumerable 멤버

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return pointCollection.GetEnumerator();
		}

		#endregion
	}
}
