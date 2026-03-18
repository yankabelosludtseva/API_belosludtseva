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
        public DbSet<Tasks> Tasks { get; set; } = null!;

        /// <summary>
        /// Конструктор контекста
        /// </summary>
        public TaskContext()
        {
            Database.EnsureCreated(); // Проверяем создано ли подключение
            Tasks.Load(); // Выполняем загрузку данных
        }

        /// <summary>
        /// Переопределяем метод конфигурации
        /// </summary>
        /// <param name="optionsBuilder">Построитель параметров контекста</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // подключаемся к серверу MySQL, со следующими настройками
            optionsBuilder.UseMySql("server=127.0.0.1;" +
            "uid=root;" +
            "pwd=" +
            "database=TaskManager",
            new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}