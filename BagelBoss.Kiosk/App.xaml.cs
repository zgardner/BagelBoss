using System;
using System.Reflection;
using System.Windows;

using Ninject;

using BagelBoss.Service;

namespace BagelBoss.Kiosk
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IBagelService _bagelService { get; set; }

        public static IBagelService bagelService
        {
            get
            {
                return _bagelService;
            }
        }

        [STAThread]
        public static void Main()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            _bagelService = kernel.Get<IBagelService>();

            var app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}
