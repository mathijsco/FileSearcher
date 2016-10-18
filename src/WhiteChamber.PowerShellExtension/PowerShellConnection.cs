using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using WhiteChamber.PowerShellExtension.Helpers;

namespace WhiteChamber.PowerShellExtension
{
    /// <summary>
    /// Connection to the PowerShell runspace and the file.
    /// </summary>
    internal class PowerShellConnection : IDisposable
    {
        private readonly string _scriptPath;
        private string _scriptContent;
        private Runspace _runspace;

        public PowerShellConnection(string scriptPath)
        {
            _scriptPath = scriptPath;
        }

        private string Content
        {
            get { return _scriptContent ?? (_scriptContent = File.ReadAllText(_scriptPath)); }
        }

        

        private void CreateRunspace()
        {
            if (_runspace == null)
            {
                //_runspace = RunspaceFactory.CreateRunspace(new VirtualHost());
                _runspace = RunspaceFactory.CreateRunspace();
                _runspace.Open();
                using (var pipeline = _runspace.CreatePipeline())
                {
                    pipeline.Commands.AddScript(this.Content);
                    pipeline.Invoke();
                }
            }
        }

        /// <summary>
        /// Runs the specified function name without any return type.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="arguments">The arguments.</param>
        public void Run(string functionName, params object[] arguments)
        {
            Run(functionName, typeof(void), arguments);
        }

        /// <summary>
        /// Runs the specified function name.
        /// </summary>
        /// <param name="functionName">Name of the function.</param>
        /// <param name="returnType">Type of the return value.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">The arguments does not contain only primitives.</exception>
        public object Run(string functionName, Type returnType, params object[] arguments)
        {
            if (arguments.Any(o => !o.GetType().IsPrimitive && !(o is string)))
                throw new ArgumentException("The arguments does not contain only primitives.");

            CreateRunspace();

            Collection<PSObject> results = null;
            using (var pipeline = _runspace.CreatePipeline())
            {
                var argumentConcat = string.Empty;
                if (arguments.Length > 0)
                {
                    for (int i = 0; i < arguments.Length; i++)
                    {
                        // Check if it is a number, that do not add quotes. Otherwise always.
                        if (!ReflectionHelper.IsNumber(arguments[i].GetType()))
                            arguments[i] = arguments[i].ToString().Replace("\"", "`\"");
                    }

                    argumentConcat = " " + arguments.Select(o => o.ToString()).Aggregate((o1, o2) => o1 + " " + o2);
                }

                pipeline.Commands.Add(new Command(functionName + argumentConcat, true, false));

                try
                {
                    results = pipeline.Invoke();
                }
                catch (CmdletInvocationException)
                {
                    // An exception has been thrown in the powershell script
                    throw;
                }
                catch (RuntimeException)
                {
                    // An exception has been thrown in the powershell script
                    throw;
                }
            }

            if (returnType == typeof (void))
                return null;

            // Return array
            if (returnType.IsArray)
            {
                var elementType = returnType.GetElementType();
                var target = (object[])Activator.CreateInstance(returnType, results.Count);
                for (int i = 0; i < results.Count; i++)
                {
                    target[i] = ConvertType(results[i].ToString(), elementType);
                }

                return target;
            }

            // Return single type
            return ConvertType(results[results.Count - 1].ToString(), returnType);
        }

        public object ReadGlobalVariable(string variableName, Type returnType)
        {
            return Run("$global:" + variableName, returnType);
        }

        public void AssignGlobalVariable(string variableName, object value)
        {
            Run("$global:" + variableName + " = ", value);
        }

        public void Dispose()
        {
            if (_runspace != null)
            {
                _runspace.Close();
                _runspace = null;
            }
        }

        /// <summary>
        /// Converts an object to any type.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target.</param>
        /// <returns></returns>
        private static object ConvertType(object value, Type target)
        {
            if (target.IsEnum)
                return  Enum.Parse(target, value.ToString());

            return Convert.ChangeType(value, target);
        }
    }
}
