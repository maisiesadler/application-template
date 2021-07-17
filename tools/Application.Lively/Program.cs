using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Lively;
using Lively.Diagrams;
using Microsoft.Extensions.Configuration;

namespace Application.Lively
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembliesPath = "/Users/maisiesadler/repos/application-template/src/Application.Api/bin/Release/net6.0";
            var assemblies = DependencyTreeConfigExtensions.GetAllAssembliesInDirectory(assembliesPath).ToList();

            var config = new DependencyTreeConfig(assemblies, AssemblyConfiguration())
            {
                SkipTypes = new HashSet<string>
                {
                    "Microsoft.Extensions.Logging.ILogger`1",
                },
            };

            var type = typeof(Application.Api.Controllers.ValidationController);
            var tree = new DependencyTree(config);
            var nodes = new List<DependencyTreeNode>
            {
                tree.GetDependencies(type.FullName),
                tree.GetDependencies(typeof(Application.Domain.ValidationInteractor).FullName),
            };

            var diagram = PlantUml.Create(nodes);
            System.Console.WriteLine(diagram);
        }

        private static IConfiguration AssemblyConfiguration()
        {
            var assemblyConfigLocation = "/Users/maisiesadler/repos/application-template/src/Application.Api/appsettings.json";
            var cfgBuilder = new ConfigurationBuilder();
            cfgBuilder.AddJsonFile(assemblyConfigLocation, optional: false, reloadOnChange: false);
            return cfgBuilder.Build();
        }
    }
}
