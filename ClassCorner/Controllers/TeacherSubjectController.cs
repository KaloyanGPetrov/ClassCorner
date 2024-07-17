using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherSubjectController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public TeacherSubjectController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(TeacherSubject teacherSubject)
        {
            if (teacherSubject.Id == 0)
            {
                _context.TeacherSubjects.Add(teacherSubject);
            }
            else
            {
                var teacherSubjectInDb = _context.TeacherSubjects.Find(teacherSubject.Id);
                if (teacherSubjectInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                teacherSubjectInDb = teacherSubject;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(teacherSubject));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.TeacherSubjects.Find(id);

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
            var result = _context.TeacherSubjects.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.TeacherSubjects.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.TeacherSubjects.ToList();

            return new JsonResult(Ok(result));
        }

    }
}

