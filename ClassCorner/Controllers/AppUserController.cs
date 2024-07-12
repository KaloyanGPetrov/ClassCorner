using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
using Microsoft.AspNetCore.Authorization;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AppUserController(ApplicationDbContext context)
        {
            _context = context;
        }

        //Create/Edit AppUsser
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public JsonResult CreateEdit(AppUser user)
        {
            if (user.Id == string.Empty)
            {
                _context.AppUsers.Add(user);
            }
            else
            {
                var userIsDb = _context.AppUsers.Find(user.Id);

                if (userIsDb == null) 
                    return new JsonResult(NotFound());

                userIsDb = user; 
            }

            _context.SaveChanges();

            return new JsonResult(Ok(user));
        }

    }
}
