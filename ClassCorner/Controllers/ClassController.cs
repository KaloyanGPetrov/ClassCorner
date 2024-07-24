using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

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

        // /classes/{id}/assign-student (POST)
        [HttpPost("{id}")]
        public JsonResult AssignStudent(int id, int studentId)
        {
            var student = _context.Students.Find(studentId);

            if (student == null || _context.Classes.Find(id) == null)
            {
                return new JsonResult(NotFound());
            }

            student.ClassId = id;
            _context.SaveChanges();

            return new JsonResult(Ok(student));
        }

        // /classes/{id}/assign-teacher (POST)
        [HttpPost("{id}")]
        public JsonResult AssignTeacher(int id, int teacherId)
        {
            if (_context.Teachers.Find(teacherId) == null || _context.Classes.Find(id) == null)
                return new JsonResult(NotFound());

            TeacherClass teacherClass = new TeacherClass();
            teacherClass.ClassId = id;
            teacherClass.TeacherId = teacherId;

            _context.TeacherClasses.Add(teacherClass);
            _context.SaveChanges();

            return new JsonResult(Ok(_context.Classes.Find(id)));
        }

        
        // /classes/{id}/remove-teacher (POST)
        [HttpPost("{id}")]
        public JsonResult RemoveTeacher(int id, int teacherId)
        {
            if (_context.Teachers.Find(teacherId) == null || _context.Classes.Find(id) == null)
                return new JsonResult(NotFound());

            var result = _context.TeacherClasses.ToList().Where(x => x.ClassId == id && x.TeacherId == teacherId);

            _context.Remove(result.First());
            _context.SaveChanges();
          
            return new JsonResult(Ok(NoContent()));
        }

        //Get
        // /classes/{id} (GET)
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _context.Classes.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        // /classes (GET)
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Classes.ToList();

            return new JsonResult(Ok(result));
        }



        // /classes/{id}/students (GET)
        [HttpGet("{id}")]
        public JsonResult GetStudentsInClass(int id)
        {
            var result = _context.Students.ToList().Where(x => x.ClassId == id);
            

            return new JsonResult(Ok(result));
        }

        // /classes/{id}/teachers (GET)
        [HttpGet("{id}")]
        public JsonResult GetTeachersInClass(int id)
        {
            var connection = _context.TeacherClasses.ToList().Where(x => x.ClassId == id);
            List<Teacher> teachers = new List<Teacher>();
            foreach (var x in connection)
            {
                teachers.Add(_context.Teachers.Find(x.TeacherId));
            }

            return new JsonResult(Ok(teachers)); 
        }

        

        //Delete
        [HttpDelete("{id}")]
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


            result.Name = newClass.Name;
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
