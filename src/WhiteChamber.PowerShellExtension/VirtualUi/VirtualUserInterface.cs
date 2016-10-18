using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Host;
using System.Security;

namespace WhiteChamber.PowerShellExtension.VirtualUi
{
    internal class VirtualUserInterface : PSHostUserInterface
    {
        public event Func<string> InvokingReadLine;

        public override string ReadLine()
        {
            if (this.InvokingReadLine != null)
                return this.InvokingReadLine();

            throw new OperationCanceledException("Cannot read the line because there is no listener to the event.");
        }

        public override SecureString ReadLineAsSecureString()
        {
            throw new NotSupportedException();
        }

        public override void Write(string value)
        {
            Trace.Write(value);
        }

        public override void Write(ConsoleColor foregroundColor, ConsoleColor backgroundColor, string value)
        {
            Trace.Write(value);
        }

        public override void WriteLine(string value)
        {
            Trace.WriteLine(value);
        }

        public override void WriteErrorLine(string value)
        {
            Trace.WriteLine(value, "Error");
        }

        public override void WriteDebugLine(string message)
        {
            Debug.WriteLine(message);
        }

        public override void WriteProgress(long sourceId, ProgressRecord record)
        {
            throw new NotSupportedException();
        }

        public override void WriteVerboseLine(string message)
        {
            Trace.WriteLine(message, "Verbose");
        }

        public override void WriteWarningLine(string message)
        {
            Trace.WriteLine(message, "Warning");
        }

        public override Dictionary<string, PSObject> Prompt(string caption, string message, Collection<FieldDescription> descriptions)
        {
            throw new NotSupportedException();
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName)
        {
            throw new NotSupportedException();
        }

        public override PSCredential PromptForCredential(string caption, string message, string userName, string targetName,
                                                         PSCredentialTypes allowedCredentialTypes, PSCredentialUIOptions options)
        {
            throw new NotSupportedException();
        }

        public override int PromptForChoice(string caption, string message, Collection<ChoiceDescription> choices, int defaultChoice)
        {
            throw new NotSupportedException();
        }

        public override PSHostRawUserInterface RawUI
        {
            get { return new VirtualRawUserInterface(); }
        }
    }
}
