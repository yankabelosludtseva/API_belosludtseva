using Microsoft.EntityFrameworkCore;
using System;
using static API_belosludtseva.Model.Task;

namespace API_belosludtseva.Context
{
    public class TaskContext : DbContext
    {
        /// <summary> Данные из базы данных
        public DbSet<Tasks> Tasks { get; set; }

        /// <summary> Конструктор контекста
        public TaskContext()
        {
            Database.EnsureCreated(); // Проверяем создано ли подключение
            Tasks.Load(); // Выполняем загрузку данных
        }

        /// <summary> Переопределяем метод конфигурации
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        // подключаемся к серверу MySQL, со следующими настройками
        optionsBuilder.UseMySql("server=127.0.0.1;" +
        "uid=root;" +
        "pwd=" +
        "database=TaskManager",
        new MySqlServerVersion(new Version(8, 0, 11)));
    }
}