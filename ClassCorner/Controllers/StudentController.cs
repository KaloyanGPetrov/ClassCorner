using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public StudentController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Student student)
        {
            if (student.Id == 0)
            {
                _context.Students.Add(student);
            }
            else
            {
                var studentInDb = _context.Students.Find(student.Id);
                if (studentInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                studentInDb = student;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(student));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Students.Find(id);

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
            var result = _context.Students.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Students.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Students.ToList();

            return new JsonResult(Ok(result));
        }

    }
}

