using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace BibliotecaAdoNet
{
    public partial class App : Application
    {
        public static string DbPath;
        public App()
        {
            InitializeComponent();
            DbPath = Path.Combine(FileSystem.AppDataDirectory, "biblioteca.db3");
            CrearBaseDeDatos();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }

        private void CrearBaseDeDatos()
        {
            using (var connection = new SqliteConnection($"Data Source={DbPath}"))
            {
                connection.Open();

                string sql = @"
                CREATE TABLE IF NOT EXISTS Libros (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Titulo TEXT NOT NULL,
                    Autor TEXT NOT NULL,
                    Editorial TEXT NOT NULL,
                    Portada TEXT
                );
            ";

                var cmd = new SqliteCommand(sql, connection);
                cmd.ExecuteNonQuery();
            }
        }
    }
}