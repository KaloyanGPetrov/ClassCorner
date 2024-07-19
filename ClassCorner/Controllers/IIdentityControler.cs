using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClassCorner.Controllers
{
    public interface IIdentityControler
    {


        [HttpGet]
        public void logout();



        // Get

        [HttpGet]
        public JsonResult GetAll();


        [HttpGet("{id}")]
        public JsonResult GetById(string id);

        [HttpGet("{name}")]
        public JsonResult GetByName(string name);

        [HttpGet("{email}")]
        public JsonResult GetByEmail(string email);

        [HttpGet("{id}")]
        public JsonResult GetRoleById(string id);

        [HttpGet("{name}")]
        public JsonResult GetRoleByName(string name);

        [HttpGet("{email}")]
        public JsonResult GetRoleByEmail(string email);

        [HttpGet]
        public JsonResult GetAllStudents();

        [HttpGet]
        public JsonResult GetAllTeachers();

        [HttpGet]
        public JsonResult GetAllAdmins();



        // Delete

        [HttpDelete("{id}")]
        public JsonResult DeleteById(string id);

        [HttpDelete("{name}")]
        public JsonResult DeleteByName(string name);


        [HttpDelete("{email}")]
        public JsonResult DeleteByEmail(string email);

        [HttpDelete("{id}")]
        public JsonResult DeleteRoleById(string id, string role);

        [HttpDelete("{name}")]
        public JsonResult DeleteRoleByName(string name, string role);

        [HttpDelete("{email}")]
        public JsonResult DeleteRoleByEmail(string email, string role);





        // Patch

        [HttpPatch("{id}")]
        public JsonResult AssignRoleById(string id, string role);

        [HttpPatch("{name}")]
        public JsonResult AssignRoleByName(string name, string role);

        [HttpPatch("{email}")]
        public JsonResult AssignRoleByEmail(string email, string role);

        [HttpPatch("{id}")]
        public JsonResult EditEmailById(string id, string newEmail);

        [HttpPatch("{email}")]
        public JsonResult EditEmailByEmail(string email, string newEmail);

        [HttpPatch("{name}")]
        public JsonResult EditEmailByName(string name, string newEmail);

        [HttpPatch("{id}")]
        public JsonResult EditPasswordById(string id, string oldPassoword, string newPassword);

        [HttpPatch("{name}")]
        public JsonResult EditPasswordByName(string name, string oldPassoword, string newPassword);

        [HttpPatch("{email}")]
        public JsonResult EditPasswordByEmail(string email, string oldPassoword, string newPassword);


        [HttpPatch("{id}")]
        public JsonResult EditNameById(string id, string newName);

        [HttpPatch("{name}")]
        public JsonResult EditNameByName(string name, string newName);

        [HttpPatch("{email}")]
        public JsonResult EditNameByEmail(string email, string newName);

        [HttpPatch]
        public JsonResult ReplaceUser(IdentityUser user);
    }
}
