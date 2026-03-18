using API_belosludtseva.Context;
using API_belosludtseva.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API_belosludtseva.Controllers
{
    [Route("api/UsersController")] // указываем раздел
    [ApiExplorerSettings(GroupName = "v2")]
    public class UsersController : Controller
    {
        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="Login">Логин пользователя</param>
        /// <param name="Password">Пароль пользователя</param>
        /// <returns>Данный метод предназначен для авторизации пользователя на сайте</returns>
        /// <response code="200">Пользователь успешно авторизован</response>
        /// <response code="403">Ошибка запроса, данные не указаны</response>
        /// <response code="500">При выполнении запроса возникли ошибки</response>
        [Route("SingIn")] // указываем какой метод вызывается
        [HttpPost] // указываем какой тип запроса используется
        [ProducesResponseType(typeof(Users), 200)]
        [ProducesResponseType(403)]
        [ProducesResponseType(500)]
        public ActionResult SingIn([FromForm] string Login, [FromForm] string Password)
        {
            if (Login == null || Password == null)
                return StatusCode(403);

            try
            {
                using (var context = new UsersContext())
                {
                    var user = context.Users.FirstOrDefault(x => x.Login == Login && x.Password == Password);
                    if (user == null)
                        return StatusCode(403);

                    return Json(user);
                }
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}