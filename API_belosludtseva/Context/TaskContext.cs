using API_belosludtseva.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace API_belosludtseva.Context
{
    public class TaskContext : DbContext
    {
        /// <summary>
        /// Данные из базы данных
        /// </summary>
        public DbSet<Tasks> Tasks { get; set; }

        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public TaskContext()
        {
            // Проверяем создана ли база данных
            Database.EnsureCreated();
        }

        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder">Построитель параметров контекста</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // подключаемся к серверу MySQL, со следующими настройками
            var connectionString = "server=127.0.0.1;" +
                                  "uid=root;" +
                                  "pwd=;" + // Укажите пароль если есть
                                  "database=TaskManager";

            optionsBuilder.UseMySql(connectionString,
                new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}