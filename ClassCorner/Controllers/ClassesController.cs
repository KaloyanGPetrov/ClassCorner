using ClassCorner.Data;
using ClassCorner.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ClassesController(ApplicationDbContext context) : ControllerBase
{
    private readonly ApplicationDbContext _context = context;

    // GET: api/classes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Class>>> GetClasses()
    {
        return await _context.Classes.ToListAsync();
    }

    // GET: api/classes/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Class>> GetClass(int id)
    {
        var classItem = await _context.Classes.FindAsync(id);

        if (classItem == null)
        {
            return NotFound();
        }

        return classItem;
    }

    // GET: api/classes/{id}/students
    [HttpGet("{id}/students")]
    public async Task<ActionResult<IEnumerable<Student>>> GetClassStudents(int id)
    {
        var classItem = await _context.Classes.Include(c => c.Student).FirstOrDefaultAsync(c => c.Id == id);

        if (classItem == null)
        {
            return NotFound();
        }

        return (ActionResult<IEnumerable<Student>>)classItem.Student;
    }

    // GET: api/classes/{id}/teachers
    [HttpGet("{id}/teachers")]
    public async Task<ActionResult<IEnumerable<Teacher>>> GetClassTeachers(int id)
    {
        var classItem = await _context.Classes.Include(c => c.Teacher).FirstOrDefaultAsync(c => c.Id == id);

        if (classItem == null)
        {
            return NotFound();
        }

        return (ActionResult<IEnumerable<Teacher>>)classItem.Teacher;
    }

    // POST: api/classes/{id}/assign-student
    [HttpPost("{id}/assign-student")]
    public async Task<IActionResult> AssignStudentToClass(int id, Student student)
    {
        var classItem = await _context.Classes.FindAsync(id);
        if (classItem == null)
        {
            return NotFound();
        }

        classItem.Student.Add(student);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/classes/{id}/assign-teacher
    [HttpPost("{id}/assign-teacher")]
    public async Task<IActionResult> AssignTeacherToClass(int id, Teacher teacher)
    {
        var classItem = await _context.Classes.FindAsync(id);
        if (classItem == null)
        {
            return NotFound();
        }

        classItem.Teacher.Add(teacher);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/classes/{id}/remove-student
    [HttpPost("{id}/remove-student")]
    public async Task<IActionResult> RemoveStudentFromClass(int id, Student student)
    {
        var classItem = await _context.Classes.Include(c => c.Student).FirstOrDefaultAsync(c => c.Id == id);
        if (classItem == null)
        {
            return NotFound();
        }

        var studentToRemove = classItem.Students.FirstOrDefault(s => s.Id == student.Id);
        if (studentToRemove == null)
        {
            return NotFound();
        }

        classItem.Students.Remove(studentToRemove);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/classes/{id}/remove-teacher
    [HttpPost("{id}/remove-teacher")]
    public async Task<IActionResult> RemoveTeacherFromClass(int id, Teacher teacher)
    {
        var classItem = await _context.Classes.Include(c => c.Teacher).FirstOrDefaultAsync(c => c.Id == id);
        if (classItem == null)
        {
            return NotFound();
        }

        var teacherToRemove = classItem.Teachers.FirstOrDefault(t => t.Id == teacher.Id);
        if (teacherToRemove == null)
        {
            return NotFound();
        }

        classItem.Teachers.Remove(teacherToRemove);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}