using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;



namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsserControler : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsserControler(ApplicationDbContext context)
        {
            _context = context;
        }



        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Usser usser)
        {
            if (usser.Id == 0)
            {
                _context.Ussers.Add(usser);
            }
            else
            {
                var usserInDb = _context.Ussers.Find(usser.Id);

                if (usserInDb == null)
                    return new JsonResult(NotFound());

                usserInDb = usser;
            }


            _context.SaveChanges();

            return new JsonResult(Ok(usser));
        }

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Ussers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            
            return new JsonResult(Ok(result));
        }

        // Ger All
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Ussers.ToList();

            return new JsonResult(Ok(result));
        }


        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Ussers.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            _context.Ussers.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }
    }
}
