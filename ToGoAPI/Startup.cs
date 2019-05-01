using System;
using System.Threading.Tasks;
using System.Web.Cors;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;

[assembly: OwinStartup(typeof(ToGoAPI.Startup))]

namespace ToGoAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
            // app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var policy = new CorsPolicy()
            {
                AllowAnyHeader = true,
                AllowAnyMethod = true,
                SupportsCredentials = true
            };

            // list of domains that are allowed can be added here
            policy.Origins.Add("https://localhost:44326/");
            policy.Origins.Add("https://localhost:44348");

            //be sure to include the port:
            //example: "http://localhost:8081"

            app.UseCors(new CorsOptions
            {
                PolicyProvider = new CorsPolicyProvider
                {
                    PolicyResolver = context => Task.FromResult(policy)
                }
            });

        }
    }
}
