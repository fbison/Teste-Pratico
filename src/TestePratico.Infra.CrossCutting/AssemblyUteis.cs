using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace TestePratico.Infra.CrossCutting
{
	[ExcludeFromCodeCoverage]
    public static class AssemblyUteis
    {
		private static string ProjectName(string camada) => typeof(AssemblyUteis).Namespace.Replace("Infra.CrossCutting", camada);


		public static IEnumerable<Type> GetApplicationInterfaces()
		{
			return GetTiposDefinidos("Domain").Where(
				type => type.IsInterface
				&& NamespaceMath(type, "Domain.Interfaces"));
		}

		public static IEnumerable<Type> GetApplicationClasses()
		{
			return GetTiposDefinidos("Service").Where(
				type => type.IsClass
				&& !type.IsAbstract
				&& NamespaceMath(type, "Service.Services")
				&& type.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
		}

		public static IEnumerable<Type> GetInfrastructureInterfaces()
		{
			return GetTiposDefinidos("Domain").Where(
				type => type.IsInterface
				&& type.Namespace != null
				&& (NamespaceMath(type, "Domain.Interfaces")
				|| NamespaceMath(type, "Domain.Repositories")
				|| NamespaceMath(type, "Domain.Servicebus")));
		}

		public static IEnumerable<Type> GetInfrastructureClasses()
		{
			return GetTiposDefinidos("Infra.Data").Where(
				type => type.IsClass
				&& !type.IsAbstract
				&& (NamespaceMath(type, "Infra.Data.Gateways")
					|| NamespaceMath(type, "Infra.Data.Repository")
					|| NamespaceMath(type, "Infra.Data.Servicebus"))
				&& type.GetCustomAttribute<CompilerGeneratedAttribute>() == null);
		}
		private static bool NamespaceMath(Type type, string nomeCamada)
		{
			return type.Namespace?.EndsWith(ProjectName(nomeCamada)) ?? false;
		}

		private static Type[] GetTiposDefinidos(string nomeCamada)
		{
			return Assembly.Load(ProjectName(nomeCamada)).GetTypes();
		}
		public static IEnumerable<Assembly> GetCurrentAssemblies()
		{
			return new Assembly[]
			{
				Assembly.Load(ProjectName("Application")),
				Assembly.Load(ProjectName("Domain")),
				Assembly.Load(ProjectName("Infra.Data")),
				Assembly.Load(ProjectName("Service")),
				Assembly.Load(ProjectName("Infra.CrossCutting"))
			};
		}
		public static Type FindType(Type @interface, IEnumerable<Type> types)
		{
			return types.FirstOrDefault(t => t.GetInterfaces().Contains(@interface));
		}

		public static Type FindInterface(Type type, IEnumerable<Type> interfaces)
		{
			return interfaces.FirstOrDefault(i => type.GetInterfaces().Contains(i));
		}
	}
}
