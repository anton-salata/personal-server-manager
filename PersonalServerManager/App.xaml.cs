using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonalServerManager.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalServerManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; }
        public AppDbContext DbContext { get; }

        public App()
        {
            var services = new ServiceCollection();

            // Register your services            
            services.AddDbContext<AppDbContext>();// Register DbContext as a singleton service       

            services.AddSingleton<AddServerPopup>();
            services.AddSingleton<AddProjectPopup>();
            services.AddSingleton<DashboardPage>();
            services.AddSingleton<ServersPage>();
            services.AddSingleton<ProjectsPage>();
            services.AddSingleton<DashboardPage>();
            services.AddSingleton<DeploymentsPage>();
            services.AddSingleton<ServerDetailsWindow>();
            services.AddSingleton<MainWindow>();

            services.AddScoped<ServersViewModel>();
            services.AddScoped<ServerDetailsViewModel>();
            services.AddScoped<DeplymentsViewModel>();
            services.AddScoped<MainDashboardViewModel>();
            services.AddScoped<ProjectsViewModel>();

            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();

            // Initialize the database
            using (var scope = ServiceProvider.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                //dbContext.Database.Migrate();
                dbContext.Database.EnsureCreated();

                DbContext = dbContext;
            }
        }


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var mainWindow = ServiceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);

            var dbContext = ServiceProvider?.GetService<AppDbContext>();
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        {
            // Dispose the database context if it has been initialized
            if (DbContext != null)

                DbContext.Dispose();
        }
    }
}