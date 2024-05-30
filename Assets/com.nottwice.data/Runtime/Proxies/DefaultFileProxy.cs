using System.IO;

namespace Assets.com.nottwice.data.Runtime.Proxies
{
	public class DefaultFileProxy : IFileProxy
	{
		public bool FileExists(string path)
		{
			return File.Exists(path);
		}

		public bool DirectoryExists(string path)
		{
			return Directory.Exists(path);
		}

		public string[] GetFiles(string path, string searchPattern)
		{
			return Directory.GetFiles(path, searchPattern);
		}
	}
}
