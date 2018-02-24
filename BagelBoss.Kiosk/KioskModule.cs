using Ninject.Modules;

using BagelBoss.DAL;
using BagelBoss.Service;

namespace BagelBoss.Kiosk
{
    public class KioskModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IBagelService>().To<BagelService>();
            Bind<IBagelDAL>().To<BagelDAL>();
            Bind<IDbConnectionProvider>().To<VistaDbDbConnectionProvider>();
        }
    }
}
