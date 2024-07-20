using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAssigmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentAssigmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(StudentAssigment studentAssigment)
        {
            _context.StudentAssigments.Add(studentAssigment);
            _context.SaveChanges();

            return new JsonResult(Ok(studentAssigment));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.StudentAssigments.Find(id);

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
            var result = _context.StudentAssigments.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.StudentAssigments.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.StudentAssigments.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, StudentAssigment newStudentAssigment)
        {
            var result = _context.StudentAssigments.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            if (newStudentAssigment.Id == 0)
                return new JsonResult(BadRequest());

            _context.StudentAssigments.Remove(result);
            _context.StudentAssigments.Add(newStudentAssigment);
            _context.SaveChanges();
            result = _context.StudentAssigments.Find(id);
            return new JsonResult(Ok(result));
        }
    }
}
