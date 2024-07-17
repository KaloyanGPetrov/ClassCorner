using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public AppUserController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(AppUser appUser)
        {
            if (appUser.Id == 0)
            {
                _context.AppUsers.Add(appUser);
            }
            else
            {
                var appUserInDb = _context.AppUsers.Find(appUser.Id);
                if (appUserInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                appUserInDb = appUser;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(appUser));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.AppUsers.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }
        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.AppUsers.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.AppUsers.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.AppUsers.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
