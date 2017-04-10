namespace Aegis.Api
{
    using System.Web.Http;
    using Aegis.Data;
    using Owin;
    using SimpleInjector;
    using SimpleInjector.Integration.WebApi;
    using SimpleInjector.Lifestyles;
    using Newtonsoft.Json;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle =
                new AsyncScopedLifestyle();

            container.Register<DataContext>(Lifestyle.Scoped);

            app.Map("/hello", cfg =>
            {
                cfg.Use(async (context, next) =>
                {
                    using (AsyncScopedLifestyle.BeginScope(container))
                    {
                        var repo = container.GetInstance<WorkspaceRepository>();
                        var workspaces = repo.All();
                        var json = JsonConvert.SerializeObject(workspaces);
                        await context.Response.WriteAsync(json);
                    }
                });
            });

            var config = new HttpConfiguration();
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);

            app.UseWebApi(config);
        }
    }
}