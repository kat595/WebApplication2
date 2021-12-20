using WebApplication2.Entities;

namespace WebApplication2
{
    public class UserSeeder
    {
        private readonly TiproomDbContext _dbContext;

        public UserSeeder(TiproomDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if(!_dbContext.Users.Any())
                {
                    var users = GetUsers();
                    _dbContext.Users.AddRange(users);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var users = new List<User>()
            {
                new User()
                {
                    Name = "Jan",
                    Lastname = "Adminowanie",
                    Nick = "JanAdmin",
                    Password = "Admin1",
                    Ifadmin = 1,

                },
                new User()
                {
                    Name = "Jan",
                    Lastname = "Uzytkowanie",
                    Nick = "JanUzytkownik",
                    Password = "Uzytkownik1",
                    Ifadmin = 0,
                }
            };

            return users;
        }
    }
}
