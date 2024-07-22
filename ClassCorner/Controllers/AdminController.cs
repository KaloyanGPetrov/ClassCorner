using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize(Roles = "Admin")]
        public JsonResult Create(Admin admin)
        {
            _context.Admins.Add(admin);
            _context.SaveChanges();

            return new JsonResult(Ok(admin));
        }
        //Get
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public JsonResult Get(int id)
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
        [Authorize(Roles = "Admin")]
        public JsonResult GetAll()
        {
            var result = _context.Admins.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public JsonResult Delete(int id)
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
        [Authorize(Roles = "Admin")]
        public JsonResult Edit(int id, Admin newAdmin)
        {
            var result = _context.Admins.Find(id);

            if (result == null)
                return new JsonResult(NotFound());

            result.Email = newAdmin.Email;
            _context.SaveChanges();
            
            return new JsonResult(Ok(result));
        }
    }
}
