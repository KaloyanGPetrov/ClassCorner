using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherClassController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherClassController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(TeacherClass teacherClass)
        {
            _context.TeacherClasses.Add(teacherClass);
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

        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.TeacherClasses.ToList();

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

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, TeacherClass newTeacherClasse)
        {
            var result = _context.TeacherClasses.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            result.ClassId = newTeacherClasse.ClassId;
            result.TeacherId = newTeacherClasse.TeacherId;
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
