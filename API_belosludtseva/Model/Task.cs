namespace API_belosludtseva.Model
{
    public class Task
    {
        /// <summary>
        /// Задачи
        /// </summary>
        public class Tasks
        {
            /// <summary>
            /// Код
            /// </summary>
            public int Id { get; set; }
            /// <summary> Наименование
            public string Name { get; set; }
            /// <summary> Приоритет
            public string Priority { get; set; }
            /// <summary> Дата выполнения
            public DateTime DateTimeExecute { get; set; }
            /// <summary> Комментарий
            public string Comment { get; set; }
            /// <summary> Выполнено
            public bool Done { get; set; }
        }
    }
}
