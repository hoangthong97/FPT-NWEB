using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using FA.JustBlog.Core;
using FA.JustBlog.Repository.Implement;
using FA.JustBlog.Repository.Interface;
using Microsoft.Owin;
using Owin;

using System;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(FA.JustBlog.App_Start.AutofacConfig))]

namespace FA.JustBlog.App_Start
{
	public class AutofacConfig
	{
		public void Configuration(IAppBuilder app)
		{
			// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
			ConfigAutofac(app);
		}
		private void ConfigAutofac(IAppBuilder app)
		{
			// Khởi tạo 1 đối tượng containerbuilder
			var builder = new ContainerBuilder();
			var assembly = Assembly.GetExecutingAssembly();

			// register controller
			builder.RegisterControllers(assembly);
			// register WebApi controller
			builder.RegisterApiControllers(assembly);
			//register DbContext
			builder.RegisterType<JustBlogContext>().AsSelf().InstancePerRequest();
			//register UnitOfWork
			builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
			//register Repository (c1)
			builder.RegisterAssemblyTypes(typeof(PostRepository).Assembly)
				.Where(m => m.Name.EndsWith("Repository"))
				.AsImplementedInterfaces().InstancePerRequest();
			//register Repository (c2)
			builder.RegisterAssemblyTypes(assembly)
			.Where(t => t.Name.EndsWith("Repository"))
			.AsImplementedInterfaces().InstancePerRequest();

			var container = builder.Build();
			DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
			GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container);

		}
	}
}
