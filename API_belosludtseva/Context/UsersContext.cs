using API_belosludtseva.Model;
using Microsoft.EntityFrameworkCore;

namespace API_belosludtseva.Context
{
    public class UsersContext: DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Users> Users { get; set; }

        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public UsersContext()
        {
            // Проверяем создана ли база данных
            Database.EnsureCreated();
            Users.Load();
        }

        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder">Построитель параметров контекста</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            // подключаемся к серверу MySQL, со следующими настройками
            optionsBuilder.UseMySql("server=192.168.0.111;" +
                                  "uid=root;" +
                                  "pwd=root" +
                                  "database=TaskManager",
            new MySqlServerVersion(new Version(8, 0, 11)));
    }
}
