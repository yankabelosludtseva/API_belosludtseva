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
    [Route("api/[controller]")]
    public class TasksController : Controller
    {
        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <remarks>Данный метод получает список задач, находящийся в базе данных</remarks>
        /// <response code="200">Список успешно получен</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("list")]
        public IActionResult List()
        {
            try
            {
                // получаем список задач из базы данных
                IEnumerable<Tasks> tasks = new TaskContext().Tasks.ToList();
                return Json(tasks); // возвращаем ответ в виде JSON
            }
            catch (Exception)
            {
                return StatusCode(500); // если возникли неполадки, выдаём 500 ошибку (ошибку сервера)
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
        public IActionResult GetById(int id)
        {
            try
            {
                // Получаем задачу по коду
                Tasks? task = new TaskContext().Tasks.Where(x => x.Id == id).FirstOrDefault();
                if (task == null)
                    return NotFound();

                return Json(task); // возвращаем ответ в виде Json
            }
            catch (Exception)
            {
                return StatusCode(500); // если возникли неполадки, выдаём 500 ошибку (ошибку сервера)
            }
        }

        /// <summary>
        /// Получение задачи
        /// </summary>
        /// <remarks>Данный метод получает задачу, находящуюся в базе данных</remarks>
        /// <param name="Id">Идентификатор задачи</param>
        /// <response code="200">Задача успешно получена</response>
        /// <response code="404">Задача не найдена</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("item")]
        public IActionResult Item(int Id)
        {
            try
            {
                // Получаем задачу по коду
                Tasks? task = new TaskContext().Tasks.Where(x => x.Id == Id).FirstOrDefault();
                if (task == null)
                    return NotFound();

                return Json(task); // возвращаем ответ в виде Json
            }
            catch (Exception)
            {
                return StatusCode(500); // если возникли неполадки, выдаём 500 ошибку (ошибку сервера)
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
                IEnumerable<Tasks> tasks = new TaskContext().Tasks
                    .Where(x => x.Name.Contains(search))
                    .ToList();

                return Json(tasks); // возвращаем ответ в виде JSON
            }
            catch (Exception)
            {
                return StatusCode(500); // если возникли неполадки, выдаём 500 ошибку (ошибку сервера)
            }
        }
    }
}