using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Umc.Core.Tools.VSGesture
{
	public static class ResourceUtil
	{
		#region PerformLoad
		/// <summary>
		/// 개체를 deserializatoin 한다.
		/// </summary>
		/// <typeparam name="T">저장할 개체의 타입입니다.</typeparam>
		/// <param name="filename">로드할 파일명입니다.</param>
		/// <param name="throwThenCreate">Exception 발생시 개체를 생성할지 여부입니다.</param>
		/// <returns>개체를 리턴합니다.</returns>
		public static T PerformLoad<T>(Assembly assembly, string resourceName, bool throwThenEmptyEntity)
		{
			XmlTextReader reader = null;

			try
			{
				Stream stream = assembly.GetManifestResourceStream(resourceName);

				using (stream)
				{
					reader = new XmlTextReader(stream);

					XmlSerializer serializer = new XmlSerializer(typeof(T));
					return (T)serializer.Deserialize(reader);
				}
			}
			catch (Exception ex)
			{
				if( throwThenEmptyEntity == false)
					throw ex;

				if( reader != null )
					reader.Close();

				T obj = Activator.CreateInstance<T>();

				return obj;
			}
			finally
			{
				if (reader != null)
					reader.Close();

				reader = null;
			}
		} 
		#endregion
	}
}
