using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(Admin admin)
        {
            _context.Admins.Add(admin);
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

        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Admins.ToList();

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

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, Admin newAdmin)
        {
            var result = _context.Admins.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            if (newAdmin.Id == 0)
                return new JsonResult(BadRequest());

            _context.Admins.Remove(result);
            _context.Admins.Add(newAdmin);
            _context.SaveChanges();
            result = _context.Admins.Find(id);
            return new JsonResult(Ok(result));
        }
    }
}
