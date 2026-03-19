using API_belosludtseva.Context;
using API_belosludtseva.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API_belosludtseva.Controllers
{
    /// <summary>
    /// Контроллер для работы с задачами
    /// </summary>
    [Route("api/TasksController")]
    [ApiExplorerSettings(GroupName = "v1")] // Версия документа
    public class TasksController : Controller
    {
        private readonly TaskContext _context;

        // Добавьте конструктор для создания контекста один раз
        public TasksController()
        {
            _context = new TaskContext();
        }

        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <remarks>Данный метод получает список задач, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [HttpGet("List")]
        public IActionResult List()
        {
            try
            {
                // получаем список задач из базы данных
                var tasks = _context.Tasks.ToList();
                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получение задачи по ID
        /// </summary>
        /// <remarks>Данный метод получает задачу по ID</remarks>
        /// <param name="id">Идентификатор задачи</param>
        /// <response code="200">Задача успешно получена</response>
        /// <response code="404">Задача не найдена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [HttpGet("Item")]
        public IActionResult GetById([FromQuery] int id)
        {
            try
            {
                // Получаем задачу по коду
                var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
                if (task == null)
                    return NotFound();

                return Ok(task);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Получение задачи по ID (альтернативный маршрут)
        /// </summary>
        /// <remarks>Данный метод получает задачу по ID из маршрута</remarks>
        /// <param name="id">Идентификатор задачи</param>
        /// <response code="200">Задача успешно получена</response>
        /// <response code="404">Задача не найдена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [HttpGet("{id}")]
        public IActionResult GetByIdFromRoute(int id)
        {
            try
            {
                // Получаем задачу по коду
                var task = _context.Tasks.FirstOrDefault(x => x.Id == id);
                if (task == null)
                    return NotFound();

                return Ok(task);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        /// <summary>
        /// Поиск задач по наименованию
        /// </summary>
        /// <remarks>Данный метод выполняет поиск задач по части наименования</remarks>
        /// <param name="search">Строка поиска</param>
        /// <response code="200">Список найденных задач</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [HttpGet("search")]
        public IActionResult Search([FromQuery] string search)
        {
            try
            {
                // Выполняем поиск задач по наименованию
                var tasks = _context.Tasks
                    .Where(x => x.Name.Contains(search))
                    .ToList();

                return Ok(tasks);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        ///<summary>
        ///Метод добавления задачи
        /// </summary>
        /// <param name="task">Данные о задаче</param>
        /// <return>Статус выполнения запроса</return>
        /// <remarks>Данный метод дбавляет задачу в базу данных</remarks>
        [Route("Add")]
        [HttpPut]
        [ApiExplorerSettings(GroupName ="v3")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]

        public ActionResult Add([FromForm]Tasks task)
        {
            try
            {
                TaskContext tasksContext = new TaskContext();
                tasksContext.Tasks.Add(task);
                tasksContext.SaveChanges();
                return StatusCode(200);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}