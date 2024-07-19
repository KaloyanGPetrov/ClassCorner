using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Data;

namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class IdentityControler : ControllerBase, IIdentityControler
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;


        public IdentityControler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }



        [HttpGet]
        public void logout()
        {
            _signInManager.SignOutAsync();
        }



        // Get

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _userManager.Users;

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpGet("{id}")]
        public JsonResult GetById(string id)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpGet("{name}")]
        public JsonResult GetByName(string name)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpGet("{email}")]
        public JsonResult GetByEmail(string email)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(result));
        }

        [HttpGet("{id}")]
        public JsonResult GetRoleById(string id)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(_userManager.GetRolesAsync(result.Result)));
        }

        [HttpGet("{name}")]
        public JsonResult GetRoleByName(string name)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(_userManager.GetRolesAsync(result.Result)));
        }

        [HttpGet("{email}")]
        public JsonResult GetRoleByEmail(string email)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(_userManager.GetRolesAsync(result.Result)));
        }

        [HttpGet]
        public JsonResult GetAllStudents()
        {
            var result = _userManager.GetUsersInRoleAsync("Student");

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAllTeachers()
        {
            var result = _userManager.GetUsersInRoleAsync("Teacher");

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAllAdmins()
        {
            var result = _userManager.GetUsersInRoleAsync("Admin");

            return new JsonResult(Ok(result));
        }



        // Delete

        [HttpDelete("{id}")]
        public JsonResult DeleteById(string id)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());


            _userManager.DeleteAsync(result.Result);


            return new JsonResult(Ok(result));

        }

        [HttpDelete("{name}")]
        public JsonResult DeleteByName(string name)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());


            _userManager.DeleteAsync(result.Result);


            return new JsonResult(Ok(result));

        }

        [HttpDelete("{email}")]
        public JsonResult DeleteByEmail(string email)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());


            _userManager.DeleteAsync(result.Result);


            return new JsonResult(Ok(result));

        }

        [HttpDelete("{id}")]
        public JsonResult DeleteRoleById(string id, string role)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());

            if (IsRoleValid(role))
                return new JsonResult(BadRequest(new { Error = "Role doesn't exist" }));

            _userManager.RemoveFromRoleAsync(result.Result, role);

            return new JsonResult(Ok(result));
        }

        [HttpDelete("{name}")]
        public JsonResult DeleteRoleByName(string name, string role)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());

            if (IsRoleValid(role))
                return new JsonResult(BadRequest(new { Error = "Role doesn't exist" }));

            _userManager.RemoveFromRoleAsync(result.Result, role);

            return new JsonResult(Ok(result));
        }

        [HttpDelete("{email}")]
        public JsonResult DeleteRoleByEmail(string email, string role)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());

            if (IsRoleValid(role))
                return new JsonResult(BadRequest(new { Error = "Role doesn't exist" }));

            _userManager.RemoveFromRoleAsync(result.Result, role);

            return new JsonResult(Ok(result));
        }





        // Patch

        [HttpPatch("{id}")]
        public JsonResult AssignRoleById(string id, string role)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());

            if (IsRoleValid(role))
                return new JsonResult(BadRequest(new { Error = "Role doesn't exist" }));

            _userManager.AddToRoleAsync(result.Result, role);
            return new JsonResult(Ok(result));
        }

        [HttpPatch("{name}")]
        public JsonResult AssignRoleByName(string name, string role)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());

            if (IsRoleValid(role))
                return new JsonResult(BadRequest(new { Error = "Role doesn't exist" }));

            _userManager.AddToRoleAsync(result.Result, role);
            return new JsonResult(Ok(result));
        }

        [HttpPatch("{email}")]
        public JsonResult AssignRoleByEmail(string email, string role)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());

            if (IsRoleValid(role))
                return new JsonResult(BadRequest(new { Error = "Role doesn't exist" }));

            _userManager.AddToRoleAsync(result.Result, role);
            return new JsonResult(Ok(result));
        }

        [HttpPatch("{id}")]
        public JsonResult EditEmailById(string id, string newEmail)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());

            var token = _userManager.GenerateEmailConfirmationTokenAsync(result.Result);
            _userManager.ChangeEmailAsync(result.Result, newEmail, token.Result);

            result = _userManager.FindByIdAsync(id);
            return new JsonResult(Ok(result));
        }

        [HttpPatch("{email}")]
        public JsonResult EditEmailByEmail(string email, string newEmail)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());

            var token = _userManager.GenerateEmailConfirmationTokenAsync(result.Result);
            _userManager.ChangeEmailAsync(result.Result, newEmail, token.Result);

            result = _userManager.FindByEmailAsync(email);
            return new JsonResult(Ok(result));
        }

        [HttpPatch("{name}")]
        public JsonResult EditEmailByName(string name, string newEmail)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());

            var token = _userManager.GenerateEmailConfirmationTokenAsync(result.Result);
            _userManager.ChangeEmailAsync(result.Result, newEmail, token.Result);

            result = _userManager.FindByNameAsync(name);
            return new JsonResult(Ok(result));
        }


        // !!! By changing the password the new one could not be up to the standart for the password !!! 

        [HttpPatch("{id}")]
        public JsonResult EditPasswordById(string id, string oldPassoword, string newPassword)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());


            string passHash = result.Result.PasswordHash;

            _userManager.ChangePasswordAsync(result.Result, oldPassoword, newPassword);

            result = _userManager.FindByIdAsync(id);

            if (result.Result.PasswordHash == passHash)
                return new JsonResult(BadRequest(new { Error = "Password is wrong" }));

            return new JsonResult(Ok(result));
        }

        [HttpPatch("{name}")]
        public JsonResult EditPasswordByName(string name, string oldPassoword, string newPassword)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());


            string passHash = result.Result.PasswordHash;

            _userManager.ChangePasswordAsync(result.Result, oldPassoword, newPassword);

            result = _userManager.FindByNameAsync(name);

            if (result.Result.PasswordHash == passHash)
                return new JsonResult(BadRequest(new { Error = "Password is wrong" }));

            return new JsonResult(Ok(result));
        }

        [HttpPatch("{email}")]
        public JsonResult EditPasswordByEmail(string email, string oldPassoword, string newPassword)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());


            string passHash = result.Result.PasswordHash;

            _userManager.ChangePasswordAsync(result.Result, oldPassoword, newPassword);

            result = _userManager.FindByEmailAsync(email);

            if (result.Result.PasswordHash == passHash)
                return new JsonResult(BadRequest(new { Error = "Password is wrong" }));

            return new JsonResult(Ok(result));
        }


        [HttpPatch("{id}")]
        public JsonResult EditNameById(string id, string newName)
        {
            var result = _userManager.FindByIdAsync(id);

            if (result == null)
                return new JsonResult(NotFound());

            IdentityUser user = result.Result;
            user.UserName = newName;

            _userManager.DeleteAsync(result.Result);
            _userManager.CreateAsync(user);

            return new JsonResult(Ok(result));
        }

        [HttpPatch("{name}")]
        public JsonResult EditNameByName(string name, string newName)
        {
            var result = _userManager.FindByNameAsync(name);

            if (result == null)
                return new JsonResult(NotFound());

            IdentityUser user = result.Result;
            user.UserName = newName;

            _userManager.DeleteAsync(result.Result);
            _userManager.CreateAsync(user);

            return new JsonResult(Ok(result));
        }

        [HttpPatch("{email}")]
        public JsonResult EditNameByEmail(string email, string newName)
        {
            var result = _userManager.FindByEmailAsync(email);

            if (result == null)
                return new JsonResult(NotFound());

            IdentityUser user = result.Result;
            user.UserName = newName;

            _userManager.DeleteAsync(result.Result);
            _userManager.CreateAsync(user);

            return new JsonResult(Ok(result));
        }

        [HttpPatch]
        public JsonResult ReplaceUser(IdentityUser user)
        {
            var result = _userManager.FindByIdAsync(user.Id);

            if (result == null)
                return new JsonResult(NotFound());

            _userManager.DeleteAsync(result.Result);
            _userManager.CreateAsync(user);
            return new JsonResult(Ok(user));
        }


        private bool IsRoleValid(string role)
        {
            if ((role != "Admin") && (role != "Student") && (role != "Teacher"))
                return false;
            return true;
        }

        [HttpGet("{email}")]
        public Task<IdentityUser> GetUser(string email)
        {
            var result = _userManager.FindByEmailAsync(email);

            return result;
        }


    }
}
