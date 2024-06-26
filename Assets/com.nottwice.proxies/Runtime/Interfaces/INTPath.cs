using System;

namespace NotTwice.Proxies.Runtime.Interfaces
{
	/// <summary>
	/// Interface contract outlining methods to be defined for path operations
	/// </summary>
	public interface INTPath
	{
		public char AltDirectorySeparatorChar { get; }
		public char DirectorySeparatorChar { get; }
		public char PathSeparator { get; }
		public char VolumeSeparatorChar { get; }

		public string ChangeExtension(string path, string extension);
		public string Combine(string path1, string path2, string path3, string path4);
		public string Combine(params string[] paths);
		public string Combine(string path1, string path2);
		public string Combine(string path1, string path2, string path3);
		public ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path);
		public string GetDirectoryName(string path);
		public ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path);
		public string GetExtension(string path);
		public ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path);
		public string GetFileName(string path);
		public string GetFileNameWithoutExtension(string path);
		public ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path);
		public string GetFullPath(string path, string basePath);
		public string GetFullPath(string path);
		public char[] GetInvalidFileNameChars();
		public char[] GetInvalidPathChars();
		public ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path);
		public string GetPathRoot(string path);
		public string GetRandomFileName();
		public string GetRelativePath(string relativeTo, string path);
		public string GetTempFileName();
		public string GetTempPath();
		public bool HasExtension(string path);
		public bool HasExtension(ReadOnlySpan<char> path);
		public bool IsPathFullyQualified(ReadOnlySpan<char> path);
		public bool IsPathFullyQualified(string path);
		public bool IsPathRooted(ReadOnlySpan<char> path);
		public bool IsPathRooted(string path);
		public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2);
		public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3);
		public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten);
		public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten);
	}
}
