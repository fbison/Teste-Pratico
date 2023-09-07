using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TestePratico.Infra.CrossCutting
{
	public static class ResolvedorDeDependencias
    {
		public static void AddResolvedorDeDependencias(this IServiceCollection services)
		{
			RegistrarApplications(services);
			RegistrarInfrastructures(services);
		}

		private static void RegistrarApplications(IServiceCollection services)
		{
			var applicationInterfaces = AssemblyUteis.GetApplicationInterfaces();
			var applicationClasses = AssemblyUteis.GetApplicationClasses();

			foreach (var @interface in applicationInterfaces)
			{
				var type = AssemblyUteis.FindType(@interface, applicationClasses);

				if (type != null)
					services.AddScoped(@interface, type);
			}
		}

		private static void RegistrarInfrastructures(IServiceCollection services)
		{
			var domainInterfaces = AssemblyUteis.GetInfrastructureInterfaces();
			var repositories = AssemblyUteis.GetInfrastructureClasses();

			foreach (var repo in repositories)
			{
				var @interface = AssemblyUteis.FindInterface(repo, domainInterfaces);

				if (@interface != null)
					services.AddScoped(@interface, repo);
			}
		}
	}
}
