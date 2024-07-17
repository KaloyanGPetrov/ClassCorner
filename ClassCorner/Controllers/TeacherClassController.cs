using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherClassController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public TeacherClassController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(TeacherClass teacherClass)
        {
            if (teacherClass.Id == 0)
            {
                _context.TeacherClasses.Add(teacherClass);
            }
            else
            {
                var teacherClassInDb = _context.TeacherClasses.Find(teacherClass.Id);
                if (teacherClassInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                teacherClassInDb = teacherClass;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(teacherClass));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.TeacherClasses.Find(id);

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
            var result = _context.TeacherClasses.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.TeacherClasses.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.TeacherClasses.ToList();

            return new JsonResult(Ok(result));
        }

    }
}

