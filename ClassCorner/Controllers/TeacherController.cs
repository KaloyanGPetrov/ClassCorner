using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
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

        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Teachers.ToList();

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

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, Teacher newTeacher)
        {
            var result = _context.Teachers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            
            result.Email = newTeacher.Email;
            result.FirstName = newTeacher.FirstName;
            result.LastName = newTeacher.LastName;
            result.PhoneNumber = newTeacher.PhoneNumber;
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
