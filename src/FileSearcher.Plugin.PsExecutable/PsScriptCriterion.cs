using System;
using System.IO;
using FileSearcher.Model.Engine;
using WhiteChamber.PowerShellExtension;

namespace FileSearcher.Plugin.PsExecutable
{
    internal class PsScriptCriterion : CriterionBase, ICriterionPlugin, IDisposable
    {
        private IScript _script;

        public PsScriptCriterion(string scriptFile)
        {
            if (scriptFile == null) throw new ArgumentNullException("scriptFile");
            if (!File.Exists(scriptFile))
                throw new FileNotFoundException("Cannot find the specified PowerShells script.", scriptFile);

            // TODO: Load PS1 script and assign variables
            _script = PowerShellProxy.Create<IScript>(scriptFile);
            this.DirectorySupport = _script.SupportDirectories;
            this.FileSupport = _script.SupportFiles;
        }

        public string Name { get { return "Execute PowerShell script"; } }

        public CriterionWeight Weight { get { return CriterionWeight.Heavy;} }

        public bool DirectorySupport { get; private set; }

        public bool FileSupport { get; private set; }

        public bool IsMatch(FileSystemInfo fileSystemInfo, ICriterionContext context)
        {
            return _script.IsMatch(fileSystemInfo.FullName);
        }

        public void Dispose()
        {
            if (_script != null)
                _script.Dispose();
        }
    }
}
