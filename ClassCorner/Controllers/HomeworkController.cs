using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public HomeworkController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Homework homework)
        {
            if (homework.Id == 0)
            {
                _context.Homework.Add(homework);
            }
            else
            {
                var homeworkInDb = _context.Homework.Find(homework.Id);
                if (homeworkInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                homeworkInDb = homework;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(homework));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Homework.Find(id);

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
            var result = _context.Homework.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Homework.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Homework.ToList();

            return new JsonResult(Ok(result));
        }

    }
}
