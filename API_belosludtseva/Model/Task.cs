namespace API_belosludtseva.Model
{
    /// <summary>
    /// Класс, представляющий задачу
    /// </summary>
    public class Tasks
    {
        /// <summary>
        /// Код
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Приоритет
        /// </summary>
        public string Priority { get; set; }

        /// <summary>
        /// Дата выполнения
        /// </summary>
        public DateTime DateTimeExecute { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Выполнено
        /// </summary>
        public bool Done { get; set; }
    }
}