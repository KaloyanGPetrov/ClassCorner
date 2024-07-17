using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClassController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public ClassController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Class @class)
        {
            if (@class.Id == 0)
            {
                _context.Classes.Add(@class);
            }
            else
            {
                var classInDb = _context.Classes.Find(@class.Id);
                if (classInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                classInDb = @class;
            }
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
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Classes.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
