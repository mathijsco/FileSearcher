using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation.Host;
using System.Text;
using System.Threading.Tasks;

namespace WhiteChamber.PowerShellExtension.VirtualUi
{
    public interface IVirtualUiEvents
    {
        event Func<KeyInfo> SingleKeyRequest;
    }
}
