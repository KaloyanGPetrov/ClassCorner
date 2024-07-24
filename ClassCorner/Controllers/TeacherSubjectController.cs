using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherSubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherSubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(TeacherSubject teacherSubject)
        {
            _context.TeacherSubjects.Add(teacherSubject);
            _context.SaveChanges();

            return new JsonResult(Ok(teacherSubject));
        }
        //Get
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _context.TeacherSubjects.Find(id);

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
            var result = _context.TeacherSubjects.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete("{id}")]
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

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, TeacherSubject newTeacherSubject)
        {
            var result = _context.TeacherSubjects.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            result.TeacherId = newTeacherSubject.TeacherId;
            result.SubjectId = newTeacherSubject.SubjectId;
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
