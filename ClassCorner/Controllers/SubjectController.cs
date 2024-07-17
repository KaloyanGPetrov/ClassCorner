using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public SubjectController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Subject subject)
        {
            if (subject.Id == 0)
            {
                _context.Subjects.Add(subject);
            }
            else
            {
                var subjectInDb = _context.Subjects.Find(subject.Id);
                if (subjectInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                subjectInDb = subject;
            }
            _context.SaveChanges();

            return new JsonResult(Ok(subject));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Subjects.Find(id);

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
            var result = _context.Subjects.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Subjects.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Subjects.ToList();

            return new JsonResult(Ok(result));
        }

    }
}

