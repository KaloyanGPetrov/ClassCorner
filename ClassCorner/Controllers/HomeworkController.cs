using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeworkController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HomeworkController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(Homework homework)
        {
            _context.Homework.Add(homework);
            _context.SaveChanges();

            return new JsonResult(Ok(homework));
        }
        //Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Homework.Find(id);

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
            var result = _context.Homework.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Homework.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Homework.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(int id, Homework newHomework)
        {
            var result = _context.Homework.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            result.Solution = newHomework.Solution;
            result.Grade = newHomework.Grade;
            result.IsGraded = newHomework.IsGraded;
            result.StudentId = newHomework.StudentId;
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
