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
        // /submit-homework (POST)
        [HttpPost]
        public JsonResult Create(Homework homework)
        {
            _context.Homework.Add(homework);
            _context.SaveChanges();

            return new JsonResult(Ok(homework));
        }

        //Get
        // /submitted-homeworks/{id} (GET)
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            var result = _context.Homework.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Homework.ToList();

            return new JsonResult(Ok(result));
        }

        // /grades/{id} (GET)
        [HttpGet("{id}")]
        public JsonResult GetGrade(int id)
        {
            var result = _context.Homework.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result.Grade));
        }

        [HttpGet("{id}")]
        public JsonResult IsGreaded(int id)
        {
            var result = _context.Homework.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result.IsGraded));
        }

        //Delete
        [HttpDelete("{id}")]
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
            result.AssigmentId = newHomework.AssigmentId;
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }

        // /grades/{id} (PUT)
        [HttpPatch("{id}")]
        public JsonResult GradeHomework(int id, int grade)
        {
            var result = _context.Homework.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            result.Grade = grade;
            result.IsGraded = true;
            _context.SaveChanges();

            return new JsonResult(Ok(result));
        }
    }
}
