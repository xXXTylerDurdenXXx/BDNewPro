
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BDNewPro
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            ServiceCollection services = new ServiceCollection();
            services.AddDbContext<Data.ProductDBContext>(option =>
            {
                option.UseSqlite("Data Source=Product.db");
            });
            services.AddSingleton<MainWindow>();
            serviceProvider = services.BuildServiceProvider();

        }

        private void OnStartup(object s, StartupEventArgs e)
        {
            var mainWindow  = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
