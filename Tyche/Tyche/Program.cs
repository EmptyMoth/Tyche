using Ninject;
using System.ComponentModel;
using Tyche.DDD.Application;
using Tyche.Domain.GUI;
using Tyche.Properties;

namespace Tyche;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    static IKernel kernel;

    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        kernel = new StandardKernel(new EngineModule(), new GuiModule());
        var engine = kernel.Get<Engine>();
        var observer = new Observer();
        var mainForm = kernel.Get<MainForm>();
        observer.SubscribeTo(mainForm);
        Application.Run(mainForm);
    }

    public class Observer : IObserver<Form>
    {
        List<Subscription<Form>> subscriptions;
        public Observer() 
        {
            subscriptions = new List<Subscription<Form>>();
        }

        public void OnCompleted() => DeleteExpiredSubscriptions();

        public void OnError(Exception error) => throw new NotImplementedException();

        public void OnNext(Form value)
        {
            if (value as MainForm != null)
            {
                var settings = kernel.Get<SettingsForm>();
                settings.Show();
                SubscribeTo(settings);
            }
            if (value as SettingsForm != null)
            {
                var engine = kernel.Get<Engine>();
                engine.ReloadRandoms();
                engine.ReloadDistributions();
            }
        }

        public void SubscribeTo(IObservable<Form> observable) =>
            subscriptions.Add((Subscription<Form>)observable.Subscribe(this));

        public void DeleteExpiredSubscriptions()
        {
            var activeSubscriptions = new List<Subscription<Form>>();
            foreach (var sub in subscriptions)
            {
                if (!sub.IsExpired)
                    activeSubscriptions.Add(sub);
            }
            subscriptions = activeSubscriptions;
        }
    }
}