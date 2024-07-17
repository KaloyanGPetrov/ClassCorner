using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public AdminController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Admin admin)
        {
            if (admin.Id == 0)
            {
                _context.Admins.Add(admin);
            }
            else
            {
                var adminInDb= _context.Admins.Find(admin.Id);
                if (adminInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                adminInDb = admin;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(admin));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id) 
        { 
            var result = _context.Admins.Find(id);

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
            var result = _context.Admins.Find(id);
            if (result == null) 
            {  
                return new JsonResult(NotFound());
            }

            _context.Admins.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result=_context.Admins.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
