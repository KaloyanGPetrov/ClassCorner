using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Post        

        [HttpPost]
        public JsonResult Create(Admin admin)
        {
            if (admin.Id == null || admin.Id == string.Empty)
                return new JsonResult(BadRequest(new { Error = "Id must be filled" }));

            _context.Admins.Add(admin);
            _context.SaveChanges();

            return new JsonResult(Ok(admin));
        }
        //Get
        [HttpGet]
        public JsonResult Get(string id)
        {
            var result = _context.Admins.Find(id);

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
            var result = _context.Admins.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        public JsonResult Delete(string id)
        {
            var result = _context.Admins.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Admins.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(string id, Admin newAdmin)
        {
            var result = _context.Admins.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            if (newAdmin.Id == null || newAdmin.Id != result.Id)
                return new JsonResult(BadRequest());

            _context.Admins.Remove(result);
            _context.Admins.Add(newAdmin);
            _context.SaveChanges();
            result = _context.Admins.Find(id);
            return new JsonResult(Ok(result));
        }
    }
}
