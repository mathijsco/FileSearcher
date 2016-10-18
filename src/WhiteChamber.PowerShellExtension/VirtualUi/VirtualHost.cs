using System;
using System.Globalization;
using System.Management.Automation.Host;
using System.Threading;

namespace WhiteChamber.PowerShellExtension.VirtualUi
{
    internal class VirtualHost : PSHost
    {
        private readonly Guid _instanceId = Guid.NewGuid();

        public override void SetShouldExit(int exitCode)
        {
            
        }

        public override void EnterNestedPrompt()
        {
            throw new NotImplementedException();
        }

        public override void ExitNestedPrompt()
        {
            
        }

        public override void NotifyBeginApplication()
        {
            throw new NotImplementedException();
        }

        public override void NotifyEndApplication()
        {
            throw new NotImplementedException();
        }

        public override string Name
        {
            get { return ".NET Virtual Host"; }
        }

        public override Version Version
        {
            get { return typeof(VirtualHost).Assembly.GetName().Version; }
        }

        public override Guid InstanceId
        {
            get { return this._instanceId; }
        }

        public override PSHostUserInterface UI
        {
            get { return new VirtualUserInterface(); }
        }

        public override CultureInfo CurrentCulture
        {
            get { return Thread.CurrentThread.CurrentCulture; }
        }

        public override CultureInfo CurrentUICulture
        {
            get { return Thread.CurrentThread.CurrentUICulture; }
        }
    }
}
