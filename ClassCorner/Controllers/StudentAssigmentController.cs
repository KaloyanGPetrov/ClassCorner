using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentAssigmentController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public StudentAssigmentController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(StudentAssigment studentAssigment)
        {
            if (studentAssigment.Id == 0)
            {
                _context.StudentAssigments.Add(studentAssigment);
            }
            else
            {
                var studentAssigmentInDb = _context.StudentAssigments.Find(studentAssigment.Id);
                if (studentAssigmentInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                studentAssigmentInDb = studentAssigment;
            }
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
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.StudentAssigments.ToList();

            return new JsonResult(Ok(result));
        }

    }
}

