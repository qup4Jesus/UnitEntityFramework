
using UnitEntityFramework.BLL.Management;
using UnitEntityFramework.DAL.Model;

namespace UnitEntityFramework.PLL.Contents
{
    internal class Content
    {
        private ManagerCompany _managerCompany;
        private ManagerUser _managerUser;
        private ManagerUserCredentials _managerUserCredentials;

        public Content(ManagerCompany managerCompany, ManagerUser managerUser, ManagerUserCredentials managerUserCredentials)
        {
            _managerCompany = managerCompany;
            _managerUser = managerUser;
            _managerUserCredentials = managerUserCredentials;
        }

        public void GetContent()
        {
            _managerCompany.Add(
                new List<Company>
                    {
                        new Company { Name = "Google", City = "Петропавловск" },
                        new Company { Name = "Mail", City = "Майами" },
                        new Company { Name = "Yandex", City = "Нигерия" },
                        new Company { Name = "Yahoo", City = "Яху" },
                    });

            _managerUser.Add(
                new List<User>
                    {
                        new User { Name = "Arthur", Email = "arthur@gmail.com", Role = "Admin", CompanyId = 1 },
                        new User { Name = "Bob", Email = "bobus@mail.ru", Role = "Admin", CompanyId = 2 },
                        new User { Name = "Clark", Email = "clara@yandex.ru", Role = "User", CompanyId = 3 },
                        new User { Name = "Dan", Email = "dany@yahoo.com", Role = "User", CompanyId = 4 }
                    });

            _managerUserCredentials.Add(
                new List<UserCredentials>
                    {
                        new UserCredentials { Login = "Arthur", Password = "qwerty123", UserId = 1},
                        new UserCredentials { Login = "BobJ", Password = "asdfgh585", UserId = 2 },
                        new UserCredentials { Login = "ClarkK", Password = "111zlt777", UserId = 3 },
                        new UserCredentials { Login = "DanE", Password = "zxc33vbn", UserId = 4 }
                    });
        }
    }
}
