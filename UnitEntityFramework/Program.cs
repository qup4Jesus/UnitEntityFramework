
using UnitEntityFramework.BLL.Management;
using UnitEntityFramework.DAL.Model;

var managerUser = new ManagerUser();
var managerUserCredentials = new ManagerUserCredentials();
var managerCompany = new ManagerCompany();

managerCompany.Add(
    new List<Company>
        {
            new Company { Name = "Google" },
            new Company { Name = "Mail" },
            new Company { Name = "Yandex" },
            new Company { Name = "Yahoo" },
        }
    );

managerUser.Add(
    new List<User>
        {
            new User { Name = "Arthur", Email = "arthur@gmail.com", Role = "Admin", CompanyId = 1 },
            new User { Name = "Bob", Email = "bobus@mail.ru", Role = "Admin", CompanyId = 2 },
            new User { Name = "Clark", Email = "clara@yandex.ru", Role = "User", CompanyId = 3 },
            new User { Name = "Dan", Email = "dany@yahoo.com", Role = "User", CompanyId = 4 }
        }
    );

managerUserCredentials.Add(
    new List<UserCredentials>
        {
            new UserCredentials { Login = "Arthur", Password = "qwerty123", UserId = 1},
            new UserCredentials { Login = "BobJ", Password = "asdfgh585", UserId = 2 },
            new UserCredentials { Login = "ClarkK", Password = "111zlt777", UserId = 3 },
            new UserCredentials { Login = "DanE", Password = "zxc33vbn", UserId = 4 }
        }
    );


