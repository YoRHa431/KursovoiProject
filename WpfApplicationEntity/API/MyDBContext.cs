using System.Data.Entity;
using WpfApplicationEntity.API;

namespace WpfApplicationEntity.API
{
    class MyDBContext : DbContext
    {
        public MyDBContext() : base("DbConnectString")
        {
        }
        public DbSet<Volunteer> Volunteers { get; set; }
        public DbSet<Action_for_the_needy> Action_for_the_needys { get; set; }
        public DbSet<Needy> Needys { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<Type_Action> Type_Actions { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Type_Service> Type_Services { get; set; }
        public DbSet<Registration_for_a_volunteer> Registration_for_a_volunteers { get; set; }
        public DbSet<Registration_for_a_needs> Registration_for_a_needss { get; set; }
        public static MyDBContext DBContext = new WpfApplicationEntity.API.MyDBContext();
    }
}
