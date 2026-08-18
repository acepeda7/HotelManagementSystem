using HotelManagementSystem.Data;

namespace HotelManagementSystem
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            using (AppDbContext db = new AppDbContext())
            {
                db.Database.EnsureCreated();
                DatabaseSeeder.Seed(db);
            }

            Application.Run(new LoginForm());
        }
    }
}