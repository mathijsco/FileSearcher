using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity.InterceptionExtension;
using ReflectionHelper = WhiteChamber.PowerShellExtension.Helpers.ReflectionHelper;

namespace WhiteChamber.PowerShellExtension
{
    /// <summary>
    /// The PowerShell interception behavior to redirect the function calls.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal class PowerShellInterception<T> : IInterceptionBehavior, IDisposable
    {
        private readonly string _filePath;
        private PowerShellConnection _connection;
        private bool _disposed;

        internal PowerShellInterception(string filePath)
        {
            _filePath = filePath;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var methodInfo = (MethodInfo)input.MethodBase;

            // Catch the Dispose() function
            if (ReflectionHelper.IsExplicitMethod(methodInfo, typeof(IDisposable), "Dispose"))
            {
                Dispose();
                return input.CreateMethodReturn(null);
            }

            if (_connection == null)
                _connection = new PowerShellConnection(_filePath);

            try
            {
                object result = null;
                var arguments = input.Arguments.Cast<object>().ToArray();

                // Handle GET property
                if (ReflectionHelper.IsGetProperty(methodInfo))
                    result = _connection.ReadGlobalVariable(ReflectionHelper.GetPropertyName(methodInfo), methodInfo.ReturnType);
                // Handle SET property
                else if (ReflectionHelper.IsSetProperty(methodInfo))
                    _connection.AssignGlobalVariable(ReflectionHelper.GetPropertyName(methodInfo), arguments[0]);
                // Run the function
                else
                    result = _connection.Run(input.MethodBase.Name, methodInfo.ReturnType, arguments);
                
                // Return the results from the script
                return input.CreateMethodReturn(result, arguments);
            }
            catch (Exception ex)
            {
                return input.CreateExceptionMethodReturn(ex);
            }
        }

        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return new[] { typeof(IDisposable), typeof(T) };
        }

        public bool WillExecute
        {
            get { return true; }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _connection.Dispose();
                _connection = null;
                _disposed = true;
            }
        }
    }
}
