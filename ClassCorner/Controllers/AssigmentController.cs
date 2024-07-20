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

        [HttpPost]
        public JsonResult Create(Assigment assigment)
        {
            _context.Assigments.Add(assigment);
            _context.SaveChanges();

            return new JsonResult(Ok(assigment));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Assigments.Find(id);

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
            var result = _context.Assigments.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Assigments.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Assigments.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Patch
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
            result.HomeworkId = newAssigment.HomeworkId;

            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
