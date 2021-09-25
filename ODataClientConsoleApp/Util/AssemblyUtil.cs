using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ODataClientConsoleApp.Util
{
    public static class AssemblyUtil
    {
        public static IEnumerable<Type> GetTypes(string nameSpace, string includeClassPostfix,
            params string[] excludeNameSubstrings)
        {
            var types = from type in Assembly.GetExecutingAssembly().GetTypes()
                where type.IsClass && type.Namespace == nameSpace
                                   && type.Name.EndsWith(includeClassPostfix)
                                   && !excludeNameSubstrings.Any(ex => type.Name.Contains(ex))
                select type;
            return types;
        }
    }
}