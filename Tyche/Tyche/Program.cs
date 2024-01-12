using Ninject;
using Tyche.Domain.Application;

namespace Tyche;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        IKernel kernel = new StandardKernel(new EngineModule(), new GuiModule());
        var engine = kernel.Get<Engine>();
            Application.Run(kernel.Get<MainForm>());
    }
}