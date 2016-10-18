using System;
using System.IO;

namespace FileSearcher.Plugin.PsExecutable
{
    public interface IScript : IDisposable
    {
        bool SupportFiles { get; }

        bool SupportDirectories { get; }

        bool IsMatch(string path);
    }
}
