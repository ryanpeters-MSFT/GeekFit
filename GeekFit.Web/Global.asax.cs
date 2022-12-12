using System;
using Unity;

namespace GeekFit.Web
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            var container = new UnityContainer();
            //container.RegisterType<IWorkoutService, WorkoutService>();

            var unityResolver = new UnityDependencyResolver(container);
            DependencyResolver.SetResolver(unityResolver); // MVC
            GlobalConfiguration.Configuration.DependencyResolver = unityResolver; // Web API       
        }
    }
}