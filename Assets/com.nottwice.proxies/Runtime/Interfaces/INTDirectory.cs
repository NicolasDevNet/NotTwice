using System;
using System.Collections.Generic;
using System.IO;

namespace NotTwice.Proxies.Runtime.Interfaces
{
    /// <summary>
    /// Interface contract outlining methods to be defined for directory operations
    /// </summary>
    public interface INTDirectory
    {
        public DirectoryInfo CreateDirectory(string path);
        public void Delete(string path);
        public void Delete(string path, bool recursive);
        public IEnumerable<string> EnumerateDirectories(string path);
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern);
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public IEnumerable<string> EnumerateDirectories(string path, string searchPattern, SearchOption searchOption);
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, SearchOption searchOption);
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public IEnumerable<string> EnumerateFiles(string path);
        public IEnumerable<string> EnumerateFiles(string path, string searchPattern);
        public IEnumerable<string> EnumerateFileSystemEntries(string path);
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern);
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public IEnumerable<string> EnumerateFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        public bool Exists(string path);
        public DateTime GetCreationTime(string path);
        public DateTime GetCreationTimeUtc(string path);
        public string GetCurrentDirectory();
        public string[] GetDirectories(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
        public string[] GetDirectories(string path);
        public string[] GetDirectories(string path, string searchPattern);
        public string GetDirectoryRoot(string path);
        public string[] GetFiles(string path);
        public string[] GetFiles(string path, string searchPattern);
        public string[] GetFiles(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public string[] GetFiles(string path, string searchPattern, SearchOption searchOption);
        public string[] GetFileSystemEntries(string path);
        public string[] GetFileSystemEntries(string path, string searchPattern);
        public string[] GetFileSystemEntries(string path, string searchPattern, EnumerationOptions enumerationOptions);
        public string[] GetFileSystemEntries(string path, string searchPattern, SearchOption searchOption);
        public DateTime GetLastAccessTime(string path);
        public DateTime GetLastAccessTimeUtc(string path);
        public DateTime GetLastWriteTime(string path);
        public DateTime GetLastWriteTimeUtc(string path);
        public string[] GetLogicalDrives();
        public DirectoryInfo GetParent(string path);
        public void Move(string sourceDirName, string destDirName);
        public void SetCreationTime(string path, DateTime creationTime);
        public void SetCreationTimeUtc(string path, DateTime creationTimeUtc);
        public void SetCurrentDirectory(string path);
        public void SetLastAccessTime(string path, DateTime lastAccessTime);
        public void SetLastAccessTimeUtc(string path, DateTime lastAccessTimeUtc);
        public void SetLastWriteTime(string path, DateTime lastWriteTime);
        public void SetLastWriteTimeUtc(string path, DateTime lastWriteTimeUtc);
    }
}
