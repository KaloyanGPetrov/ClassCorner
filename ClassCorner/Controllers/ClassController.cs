using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(Class @class)
        {
            _context.Classes.Add(@class);
            _context.SaveChanges();

            return new JsonResult(Ok(@class));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Classes.Find(id);

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
            var result = _context.Classes.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Classes.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Classes.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, Class newClass)
        {
            var result = _context.Classes.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            if (newClass.Id == 0)
                return new JsonResult(BadRequest());

            _context.Classes.Remove(result);
            _context.Classes.Add(newClass);
            _context.SaveChanges();
            result = _context.Classes.Find(id);
            return new JsonResult(Ok(result));
        }
    }
}
