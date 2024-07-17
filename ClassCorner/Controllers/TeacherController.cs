using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public TeacherController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Teacher teacher)
        {
            if (teacher.Id == 0)
            {
                _context.Teachers.Add(teacher);
            }
            else
            {
                var teacherInDb = _context.Teachers.Find(teacher.Id);
                if (teacherInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                teacherInDb = teacher;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(teacher));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Teachers.Find(id);

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
            var result = _context.Teachers.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Teachers.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Teachers.ToList();

            return new JsonResult(Ok(result));
        }

    }
}

