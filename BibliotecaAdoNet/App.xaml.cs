using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaAdoNet
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        protected override void OnStart()
        {
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }
        }
    }
}