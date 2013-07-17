using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Umc.Core.Tools.VSGesture
{
	public static class FileUtil
	{
		#region PerformLoad
		/// <summary>
		/// 개체를 deserializatoin 한다.
		/// </summary>
		/// <typeparam name="T">저장할 개체의 타입입니다.</typeparam>
		/// <param name="filename">로드할 파일명입니다.</param>
		/// <returns>저장된 개체를 리턴합니다.</returns>
		public static T PerformLoad<T>(string filename)
		{
			return PerformLoad<T>(filename, true);
		} 

		/// <summary>
		/// 개체를 deserializatoin 한다.
		/// </summary>
		/// <typeparam name="T">저장할 개체의 타입입니다.</typeparam>
		/// <param name="filename">로드할 파일명입니다.</param>
		/// <param name="throwThenCreate">Exception 발생시 파일을 생성할지 여부입니다.</param>
		/// <returns>저장된 개체를 리턴합니다.</returns>
		public static T PerformLoad<T>(string filename, bool throwThenCreate)
		{
			return PerformLoad<T>(filename, throwThenCreate, false, false);
		} 

		/// <summary>
		/// 개체를 deserializatoin 한다.
		/// </summary>
		/// <typeparam name="T">저장할 개체의 타입입니다.</typeparam>
		/// <param name="filename">로드할 파일명입니다.</param>
		/// <param name="throwThenCreate">Exception 발생시 파일을 생성할지 여부입니다.</param>
		/// <returns>저장된 개체를 리턴합니다.</returns>
		public static T PerformLoad<T>(string filename, bool throwThenCreate, bool createFolder, bool createHiddenFolder)
		{
			XmlTextReader reader = null;

			try
			{
				reader = new XmlTextReader(filename);

				XmlSerializer serializer = new XmlSerializer(typeof(T));
				return (T)serializer.Deserialize(reader);

			}
			catch (Exception ex)
			{
				if( throwThenCreate == false)
					throw ex;

				if( reader != null )
					reader.Close();

				T obj = Activator.CreateInstance<T>();
				// CHANGE : PerformSave<T>(filename, obj, createFolder, createHiddenFolder);
				File.WriteAllText(filename, @"<?xml version=""1.0"" encoding=""utf-8""?>
<VSGestureInfo xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns=""http://tempuri.org/VSGestureInfo.xsd"">
  <UserSettings>
    <LineColor>255,0,0</LineColor>
    <LineThickness>Thickness5</LineThickness>
    <EnableVSGesture>true</EnableVSGesture>
	<EnableVSGestureAlram>true</EnableVSGestureAlram>
  </UserSettings>
  <GestureActionMapper>
    <Gesture GestureActionType=""DownRight"" ActionType=""Command"" GestureItemName=""File.Close"" />
    <Gesture GestureActionType=""ScratchOut"" ActionType=""Command"" GestureItemName=""Window.CloseAllDocuments"" />
    <Gesture GestureActionType=""Up"" ActionType=""Command"" GestureItemName=""Goto.First.Line"" />
    <Gesture GestureActionType=""Down"" ActionType=""Command"" GestureItemName=""Goto.Last.Line"" />
    <Gesture GestureActionType=""Circle"" ActionType=""Command"" GestureItemName=""Build.BuildSelection"" />
    <Gesture GestureActionType=""DoubleCircle"" ActionType=""Command"" GestureItemName=""Build.BuildSolution"" />
    <Gesture GestureActionType=""Right"" ActionType=""Action"" GestureItemName=""RightGestureExecuteCommand"" />
    <Gesture GestureActionType=""UpRight"" ActionType=""Command"" GestureItemName=""Debug.Startnewinstance"" />
    <Gesture GestureActionType=""UpRightLong"" ActionType=""Command"" GestureItemName=""Debug.Startnewinstance"" />
    <Gesture GestureActionType=""Left"" ActionType=""Action"" GestureItemName=""LeftGestureExecuteCommand"" />
  </GestureActionMapper>
</VSGestureInfo>");

				obj = PerformLoad<T>(filename, throwThenCreate, createFolder, createHiddenFolder);

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

		#region PerformSave
		/// <summary>
		/// 개체를 serialization 하여 파일로 저장합니다.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="filename"></param>
		/// <param name="argument"></param>
		public static void PerformSave<T>(string filename, object argument)
		{
			PerformSave<T>(filename, argument, false, false);
		}

		/// <summary>
		/// 개체를 serialization 하여 파일로 저장합니다.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="filename"></param>
		/// <param name="argument"></param>
		/// <param name="createFolder"></param>
		/// <param name="createHiddenFolder"></param>
		public static void PerformSave<T>(string filename, object argument, bool createFolder, bool createHiddenFolder)
		{
			XmlTextWriter writer = null;
			bool doActionHidden = false;

			try
			{
				// 폴더명이 존재하지 않으면 만든다
				if (Directory.Exists(Path.GetDirectoryName(filename)) == false)
				{
					if (createFolder)
					{
						DirectoryInfo di = Directory.CreateDirectory(Path.GetDirectoryName(filename));
						if (createHiddenFolder)
						{
							di.Attributes = di.Attributes | FileAttributes.Hidden;
							doActionHidden = true;
						}
					}
					else
					{
						throw new DirectoryNotFoundException(filename + " 생성하기 위해 폴더를 만들 수 없습니다");
					}
				}

				if (File.Exists(filename))
				{
					FileInfo fi = new FileInfo(filename);
					if ((fi.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
					{
						fi.Attributes = fi.Attributes ^ FileAttributes.Hidden;
						doActionHidden = true;
					}
				}

				writer = new XmlTextWriter(filename, Encoding.UTF8);
				writer.Formatting = Formatting.Indented;

				XmlSerializer serializer = new XmlSerializer(typeof(T));
				serializer.Serialize(writer, argument);

				if (doActionHidden)
				{
					FileInfo file = new FileInfo(filename);
					file.Attributes = file.Attributes | FileAttributes.Hidden;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				if (writer != null)
					writer.Close();

				writer = null;
			}
		}
		#endregion

		//public static string Sha1Crypt(string cryptString)
		//{
		//    System.Security.Cryptography.SHA1 sha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
		//    byte[] b = sha1.ComputeHash( System.Text.Encoding.Default.GetBytes( cryptString ));
				
		//    string str = "";
		//    b.ToList().ForEach( o => str+=o.ToString("x2"));

		//    return str;
		//}
	}
}
