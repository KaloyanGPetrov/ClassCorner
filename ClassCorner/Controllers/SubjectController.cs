using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(Subject subject)
        {
            _context.Subjects.Add(subject);
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

        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Subjects.ToList();

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

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, Subject newSubject)
        {
            var result = _context.Subjects.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
  
            result.Name = newSubject.Name;
            _context.SaveChanges();
 
            return new JsonResult(Ok(result));
        }
    }
}
