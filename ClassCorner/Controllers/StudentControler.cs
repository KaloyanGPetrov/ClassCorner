﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassCorner.Models;
using ClassCorner.Data;
using Microsoft.AspNetCore.Identity;



namespace ClassCorner.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentControler(ApplicationDbContext context)
        {
            _context = context;
        }


        //Post        

        [HttpPost]
        public JsonResult Create(Student student)
        {
            if (student.Id == null || student.Id == string.Empty)
                return new JsonResult(BadRequest(new { Error = "Id must be filled" }));

            _context.Students.Add(student);
            _context.SaveChanges();

            return new JsonResult(Ok(student));
        }

        //Get
        [HttpGet("{id}")]
        public JsonResult GetStudent(string id)
        {
            var result = _context.Students.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            return new JsonResult(Ok(result));
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Students.ToList();

            return new JsonResult(Ok(result));
        }

        //Delete
        [HttpDelete("{id}")]
        public JsonResult Delete(string id)
        {
            var result = _context.Students.Find(id);
            if (result == null)
            {
                return new JsonResult(NotFound());
            }

            _context.Students.Remove(result);
            _context.SaveChanges();

            return new JsonResult(NoContent());
        }

        //Patch
        [HttpPatch("{id}")]
        public JsonResult Edit(string id, Student newStudent)
        {
            var result = _context.Students.Find(id);

            if (result == null)
                return new JsonResult(NotFound());
            if (newStudent.Id == null || newStudent.Id != result.Id)
                return new JsonResult(BadRequest());
            
            _context.Students.Remove(result);
            _context.Students.Add(newStudent);
            _context.SaveChanges();
            result = _context.Students.Find(id);
            return new JsonResult(Ok(result));
        }
    }
}
