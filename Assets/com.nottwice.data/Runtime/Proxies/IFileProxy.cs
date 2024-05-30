namespace Assets.com.nottwice.data.Runtime.Proxies
{
	public interface IFileProxy
	{
		bool DirectoryExists(string path);
		string[] GetFiles(string path, string searchPattern);
		bool FileExists(string path);
	}
}