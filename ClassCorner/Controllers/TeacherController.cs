using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public JsonResult Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return new JsonResult(Ok(teacher));
        }
        //Get
        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public JsonResult GetAll()
        {
            var result = _context.Teachers.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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
