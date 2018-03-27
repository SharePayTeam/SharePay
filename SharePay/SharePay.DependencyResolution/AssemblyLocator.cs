using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;

namespace SharePay.DependencyResolution
{
    public static class AssemblyLocator
    {
        private static readonly ReadOnlyCollection<Assembly> allAssemblies;
        private static readonly ReadOnlyCollection<Assembly> binDirectoryAssemblies;

        static AssemblyLocator()
        {
            allAssemblies = new ReadOnlyCollection<Assembly>(BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList());

            var binDirectoryAssembliesTemp = new List<Assembly>();
            var binDirectoryAssemblyFiles = Directory.GetFiles(string.Concat(HttpRuntime.AppDomainAppPath, "bin\\"), "*.dll", SearchOption.TopDirectoryOnly).ToList();

            foreach (string binDirectoryAssemblyFile in binDirectoryAssemblyFiles)
            {
                var assemblyName = AssemblyName.GetAssemblyName(binDirectoryAssemblyFile);
                var assembly = allAssemblies.FirstOrDefault(x => AssemblyName.ReferenceMatchesDefinition(x.GetName(), assemblyName));

                if (assembly != null)
                {
                    binDirectoryAssembliesTemp.Add(assembly);
                }
            }

            binDirectoryAssemblies = new ReadOnlyCollection<Assembly>(binDirectoryAssembliesTemp);
        }

        public static ReadOnlyCollection<Assembly> GetAllAssemblies()
        {
            return allAssemblies;
        }

        public static IEnumerable<Assembly> GetAllAssemblies(string assemblyPreffix)
        {
            return allAssemblies.Where(name => name.FullName.StartsWith(assemblyPreffix));
        }

        public static ReadOnlyCollection<Assembly> GetBinDirectoryAssemblies()
        {
            return binDirectoryAssemblies;
        }

        public static IEnumerable<Assembly> GetBinDirectoryAssemblies(string assemblyPreffix)
        {
            return binDirectoryAssemblies.Where(name => name.FullName.StartsWith(assemblyPreffix));
        }
    }
}
