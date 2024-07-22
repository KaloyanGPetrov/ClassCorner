using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssigmentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AssigmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post
        // /homeworks (POST)
        [HttpPost]
        public JsonResult Create(Assigment assigment)
        {
            _context.Assigments.Add(assigment);
            _context.SaveChanges();

            return new JsonResult(Ok(assigment));
        }

        //Get
        // /homeworks/{id} (GET)
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _context.Assigments.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Assigments.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        // /homeworks/{id} (DELETE)
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            var result = _context.Assigments.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            foreach(var item in _context.Homework.ToList().Where(x => x.AssigmentId == id))
                _context.Homework.Remove(item);

            foreach (var item in _context.StudentAssigments.ToList().Where(x => x.AssigmentId == id))
                _context.StudentAssigments.Remove(item);

            _context.Assigments.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent()); 
        }

        //Patch
        // /homeworks/{id} (PUT)
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, Assigment newAssigment)
        {
            var result = _context.Assigments.Find(id);

            if (result == null)
                return new JsonResult(NotFound());;

            result.Name = newAssigment.Name;
            result.Description = newAssigment.Description;
            result.Deadline = newAssigment.Deadline;
            result.SubjectId = newAssigment.SubjectId;
            result.TeacherId = newAssigment.TeacherId;

            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
