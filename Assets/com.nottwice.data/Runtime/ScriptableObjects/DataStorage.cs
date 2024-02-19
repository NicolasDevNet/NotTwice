using Assets.com.nottwice.application.Runtime.Proxies;
using Assets.com.nottwice.data.Runtime.Proxies;
using Assets.com.nottwice.data.Runtime.Serializables;
using Assets.com.nottwice.events.Runtime.ScriptableObjects.Variables;
using Assets.com.nottwice.lifetime.Runtime;
using Assets.com.nottwice.scriptableobjects.Runtime.Variables.Typed;
using NaughtyAttributes;
using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Assets.com.nottwice.data.Runtime.ScriptableObjects
{
	public abstract class DataStore<T, U> : ScriptableObject
		where T : DataItem
		where U : ReactiveDataItemStore<T>
	{
		#region Fields

		[Required]
		public StringVariable FileExtention;

		[Required]
		public U Collection;

		public ReactiveBoolVariableEvent IsLoadingEvent;

		public ReactiveBoolVariableEvent IsSavingEvent;

		#endregion

		#region Properties

		private IApplication _applicationInternal;

		private IApplication _application
		{ 
			get 
			{
				if(_applicationInternal == null)
				{
					_applicationInternal = AppContainer.Get<IApplication>();
				}

				return _applicationInternal;
			}
		}

		private IFileProxy _fileProxyInternal;

		private IFileProxy _fileProxy
		{
			get
			{
				if (_fileProxyInternal == null)
				{
					_fileProxyInternal = AppContainer.Get<IFileProxy>();
				}

				return _fileProxyInternal;
			}
		}

		private ILogger _loggerInternal;

		private ILogger _logger
		{
			get
			{
				if (_loggerInternal == null)
				{
					_loggerInternal = AppContainer.Get<ILogger>();
				}

				return _loggerInternal;
			}
		}

		#endregion

		public void Initialize()
		{
			Collection.SubscribeAdd((id) => Save(id));
			Collection.SubscribeRemove((id) => Save(id));
		}

		public void Save(int id)
		{
			IsSavingEvent.SetValue(true);

			T item = Collection.DataSet.FirstOrDefault(p => p.Id == id);

			if(item == null)
			{
				_logger.LogError("data" ,$"L'objet a sauvegarder n'a pas été retrouvé dans la collection de: {typeof(T).Name} avec l'ID: {id}");
				return;
			}

			string filePath = ConstructFilePath(id);

			BinaryFormatter Formatter = new BinaryFormatter();

			try
			{
				using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
				{
					Formatter.Serialize(fileStream, item);
				}
			}
			catch(Exception ex)
			{
				_logger.LogException(ex);
				_logger.LogError("data", $"L'objet a sauvegarder n'a pas pu être enregistré");
			}
			finally
			{
				IsSavingEvent.SetValue(false);
			}
			
		}

		public void Load()
		{
			IsLoadingEvent.SetValue(true);

			string folderPath = ConstructFolderPath();

			if(!_fileProxy.DirectoryExists(folderPath))
			{
				return;
			}

			string[] files = _fileProxy.GetFiles(folderPath, $"{typeof(T).Name}*");

			try
			{
				foreach (string file in files)
				{
					BinaryFormatter Formatter = new BinaryFormatter();

					using (FileStream fileStream = new FileStream(file, FileMode.Open))
					{
						object obj = Formatter.Deserialize(fileStream);
						Collection.Add(obj as T);
					}
				}
			}
			catch (Exception ex)
			{
				_logger.LogException(ex);
				_logger.LogError("data", $"L'objet a charger n'a pas pu être retrouvé");
			}
			finally
			{
				IsLoadingEvent.SetValue(false);
			}
		}

		private string ConstructFilePath(int id)
		{
			return string.Format("{0}/{1}_{2}_{3}.{4}", ConstructFolderPath(), typeof(T).Name, DateTime.Now.ToString("yyyy-MM-dd"), id, FileExtention.Value);
		}

		private string ConstructFolderPath()
		{
			return string.Format("{0}/{1}", _application.GetPersistentDataPath(), typeof(T).Name);
		}
	}
}
