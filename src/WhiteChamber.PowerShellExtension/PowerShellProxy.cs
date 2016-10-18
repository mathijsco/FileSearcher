using System.Diagnostics;
using System;
using System.IO;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace WhiteChamber.PowerShellExtension
{
    /// <summary>
    /// Proxy to create a wrapper for executing PowerShell scripts.
    /// </summary>
    [DebuggerStepThrough]
    public static class PowerShellProxy
    {
        /// <summary>
        /// Creates a new PowerShell instance and open the specified path.
        /// </summary>
        /// <typeparam name="T">The interface that contains the matching function signatures of the script.</typeparam>
        /// <param name="filePath">The file path to the PS1 script.</param>
        /// <returns></returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the specified script interface is not IDisposable.</exception>
        public static T Create<T>(string filePath)
        {
            if (!typeof(IDisposable).IsAssignableFrom(typeof(T)))
                throw new InvalidOperationException("The type '" + typeof(T) + "' must inherit the IDisposable class.");

            if (!File.Exists(filePath))
                throw new FileNotFoundException("Cannot find the specified PS1 script.", filePath);

            return (T)Intercept.NewInstance<object>(new VirtualMethodInterceptor(), new IInterceptionBehavior[] { new PowerShellInterception<T>(filePath) });
        }
    }
}
