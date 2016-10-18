using System;
using System.Reflection;

namespace WhiteChamber.PowerShellExtension.Helpers
{
    internal static class ReflectionHelper
    {
        public static bool IsGetProperty(MethodInfo methodInfo)
        {
            return methodInfo.Name.StartsWith("get_", StringComparison.Ordinal);
        }

        public static bool IsSetProperty(MethodInfo methodInfo)
        {
            return methodInfo.Name.StartsWith("set_", StringComparison.Ordinal);
        }

        public static string GetPropertyName(MethodInfo methodInfo)
        {
            return methodInfo.Name.Remove(0, 4);
        }

        public static bool IsExplicitMethod(MethodInfo memberInfo, Type interfaceType, string methodName)
        {
            // Catch the Dispose() function
            if (memberInfo.DeclaringType == interfaceType)
            {
                if (memberInfo.Name.Equals(methodName, StringComparison.Ordinal))
                    return true;
            }
            return false;
        }

        public static bool IsNumber(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                    case TypeCode.Decimal:
                    case TypeCode.Double:
                    case TypeCode.Int16:
                    case TypeCode.Int32:
                    case TypeCode.Int64:
                    case TypeCode.SByte:
                    case TypeCode.Single:
                    case TypeCode.UInt16:
                    case TypeCode.UInt32:
                    case TypeCode.UInt64:
                    return true;
                default:
                    return false;
            }
        }
    }
}
