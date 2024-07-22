using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;



namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentControler(ApplicationDbContext context)
        {
            _context = context;
        }


        //Post        

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult Create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();

            return new JsonResult(Ok(student));
        }

        //Get
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public JsonResult GetStudent(int id)
        {
            var result = _context.Students.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public JsonResult GetAll()
        {
            var result = _context.Students.ToList();

            return new JsonResult(Ok(result));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public JsonResult GetAllByClass(int id)
        {
            if (_context.Classes.Find(id) == null)
                return new JsonResult(BadRequest());

            var result = _context.Students.ToList().Where(x => x.ClassId == id);

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
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

        //Patch
        [HttpPatch("{id}")]
        [Authorize(Roles = "Admin")]
        public JsonResult Edit(int id, Student newStudent)
        {
            var result = _context.Students.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            
            result.Email = newStudent.Email;
            result.FirstName = newStudent.FirstName;
            result.LastName = newStudent.LastName;
            result.PhoneNumber = newStudent.PhoneNumber;
            result.ClassId = newStudent.ClassId;

            _context.SaveChanges();
            return new JsonResult(Ok(result));
        }
    }
}
