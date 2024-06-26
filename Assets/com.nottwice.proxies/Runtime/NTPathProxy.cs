using NotTwice.Proxies.Runtime.Interfaces;
using System;
using Path = System.IO.Path;

namespace NotTwice.Proxies.Runtime
{
	/// <summary>
	/// Proxy acting as a flat pass for <see cref="Path"/> static methods.
	/// </summary>
	public class NTPathProxy : INTPath
	{
		public char AltDirectorySeparatorChar
		{
			get
			{
				return Path.AltDirectorySeparatorChar;
			}
		}

		public char DirectorySeparatorChar
		{
			get
			{
				return Path.DirectorySeparatorChar;
			}
		}

		public char PathSeparator
		{
			get
			{
				return Path.PathSeparator;
			}
		}


		public char VolumeSeparatorChar
		{
			get
			{
				return Path.VolumeSeparatorChar;
			}
		}

		public string ChangeExtension(string path, string extension)
		{
			return Path.ChangeExtension(path, extension);
		}

		public string Combine(string path1, string path2, string path3, string path4)
		{
			return Path.Combine(path1, path2, path3, path4);
		}

		public string Combine(params string[] paths)
		{
			return Path.Combine(paths);
		}

		public string Combine(string path1, string path2)
		{
			return Path.Combine(path1, path2);
		}

		public string Combine(string path1, string path2, string path3)
		{
			return Path.Combine(path1, path2, path3);
		}

		public ReadOnlySpan<char> GetDirectoryName(ReadOnlySpan<char> path)
		{
			return Path.GetDirectoryName(path);
		}

		public string GetDirectoryName(string path)
		{
			return Path.GetDirectoryName(path);
		}

		public ReadOnlySpan<char> GetExtension(ReadOnlySpan<char> path)
		{
			return Path.GetExtension(path);
		}

		public string GetExtension(string path)
		{
			return Path.GetExtension(path);
		}

		public ReadOnlySpan<char> GetFileName(ReadOnlySpan<char> path)
		{
			return Path.GetFileName(path);
		}

		public string GetFileName(string path)
		{
			return Path.GetFileName(path);
		}

		public string GetFileNameWithoutExtension(string path)
		{
			return Path.GetFileNameWithoutExtension(path);
		}

		public ReadOnlySpan<char> GetFileNameWithoutExtension(ReadOnlySpan<char> path)
		{
			return Path.GetFileNameWithoutExtension(path);
		}

		public string GetFullPath(string path, string basePath)
		{
			return Path.GetFullPath(path);
		}

		public string GetFullPath(string path)
		{
			return Path.GetFullPath(path);
		}

		public char[] GetInvalidFileNameChars()
		{
			return Path.GetInvalidFileNameChars();
		}

		public char[] GetInvalidPathChars()
		{
			return Path.GetInvalidPathChars();
		}

		public ReadOnlySpan<char> GetPathRoot(ReadOnlySpan<char> path)
		{
			return Path.GetPathRoot(path);
		}

		public string GetPathRoot(string path)
		{
			return Path.GetPathRoot(path);
		}

		public string GetRandomFileName()
		{
			return Path.GetRandomFileName();
		}

		public string GetRelativePath(string relativeTo, string path)
		{
			return Path.GetRelativePath(relativeTo, path);
		}

		public string GetTempFileName()
		{
			return Path.GetTempFileName();
		}

		public string GetTempPath()
		{
			return Path.GetTempPath();
		}

		public bool HasExtension(string path)
		{
			return Path.HasExtension(path);
		}

		public bool HasExtension(ReadOnlySpan<char> path)
		{
			return Path.HasExtension(path);
		}

		public bool IsPathFullyQualified(ReadOnlySpan<char> path)
		{
			return Path.IsPathFullyQualified(path);
		}

		public bool IsPathFullyQualified(string path)
		{
			return Path.IsPathFullyQualified(path);
		}

		public bool IsPathRooted(ReadOnlySpan<char> path)
		{
			return Path.IsPathRooted(path);
		}

		public bool IsPathRooted(string path)
		{
			return Path.IsPathRooted(path);
		}

		public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2)
		{
			return Path.Join(path1, path2);
		}

		public string Join(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3)
		{
			return Path.Join(path1, path2, path3);
		}

		public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, ReadOnlySpan<char> path3, Span<char> destination, out int charsWritten)
		{
			return Path.TryJoin(path1, path2, path3, destination, out charsWritten);
		}

		public bool TryJoin(ReadOnlySpan<char> path1, ReadOnlySpan<char> path2, Span<char> destination, out int charsWritten)
		{
			return Path.TryJoin(path1, path2, destination, out charsWritten);
		}
	}
}
