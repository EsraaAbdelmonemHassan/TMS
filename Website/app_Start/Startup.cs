namespace Website
{
    using BotDetect.Web;
    using Domain;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Server.Kestrel.Core;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using Olive;
    using Olive.Entities.Data;
    using Olive.Hangfire;
    using Olive.Mvc.Testing;
    using System.Globalization;
    using System.Threading.Tasks;

    public class Startup : Olive.Mvc.Startup
    {
        public Startup(IWebHostEnvironment env, IConfiguration config)
        : base(env, builder => { })
        {
        }
        protected override CultureInfo GetRequestCulture() => new CultureInfo("en-GB");

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            services.AddDataAccess(x => x.SqlServer());

            services.AddDatabaseLogger();
            services.AddScheduledTasks();

            if (Environment.IsDevelopment())
                services.AddDevCommands(x => x.AddTempDatabase<SqlServerManager, ReferenceData>());
            services.AddSession(options => options.IdleTimeout = 20.Minutes());
            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);
        }

        protected override void ConfigureRequestHandlers(IApplicationBuilder app)
        {
            app.UseSession();
            base.ConfigureRequestHandlers(app);
            app.UseCaptcha(Configuration);
        }

        protected override void ConfigureAuthentication(AuthenticationBuilder auth)
        {
            base.ConfigureAuthentication(auth);
            auth.AddSocialAuth();
        }

        public override async Task OnStartUpAsync(IApplicationBuilder app)
        {
            await base.OnStartUpAsync(app);

            // Only enable scheduled tasks when explicitly enabled in configuration
            var tasksEnabled = Configuration.GetSection("Automated.Tasks").GetValue<bool>("Enabled", true);
            if (!tasksEnabled) return;

            // Acquire the Olive database and check for domain reference data.
            // Use a domain entity (Administrator) that exists in the Domain namespace
            // instead of referencing a non-existent Olive.Entities.Data.ReferenceData type.
            var database = Olive.Context.Current.Database();
            try
            {
                if (database != null && await database.Any<Administrator>())
                {
                    // logic here
                }
            }
            catch
            {
                // ignore DB not ready yet
            }

            var dbReady = Configuration.GetValue<bool>("DatabaseReady");

            if (dbReady)
                app.UseScheduledTasks<TaskManager>();
        }

        #region Show error screen even in production?
        // Uncomment the following:
        // protected override void ConfigureExceptionPage(IApplicationBuilder app) 
        //    => app.UseDeveloperExceptionPage();
        #endregion
    }
}
//sqllocaldb info  # verify LocalDB instances exist
//sqlcmd -S "(localdb)\MSSQLLocalDB" -Q "IF DB_ID('TMSDB') IS NULL CREATE DATABASE TMSDB;"