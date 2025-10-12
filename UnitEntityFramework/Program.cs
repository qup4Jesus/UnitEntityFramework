
using UnitEntityFramework.BLL.Management;
using UnitEntityFramework.DAL;
using UnitEntityFramework.PLL.Contents;

var managerUser = new ManagerUser();
var managerUserCredentials = new ManagerUserCredentials();
var managerCompany = new ManagerCompany();

// Создаем контекст для добавления данных
using (var db = new MyAppContext())
{
    // Пересоздаем базу
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();

    // Заполняем данными
    new Content(managerCompany, managerUser, managerUserCredentials).GetContent();


}


