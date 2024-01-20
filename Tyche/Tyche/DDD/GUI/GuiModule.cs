using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyche.DDD.GUI;

namespace Tyche.DDD.GUI
{
    public class GuiModule : NinjectModule
    {
        public override void Load()
        {
            Bind<MainForm>().ToSelf();
            Bind<SettingsForm>().ToSelf();
        }
    }
}
