using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssigmentController : ControllerBase
    {
        private readonly ClassCorner_DbContext _context;

        public AssigmentController(ClassCorner_DbContext context)
        {
            _context = context;
        }

        //Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Assigment assigment)
        {
            if (assigment.Id == 0)
            {
                _context.Assigments.Add(assigment);
            }
            else
            {
                var assigmentInDb = _context.Assigments.Find(assigment.Id);
                if (assigmentInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                assigmentInDb = assigment;
            }
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
        //Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Assigments.ToList();

            return new JsonResult(Ok(result));
        }
    }
}
