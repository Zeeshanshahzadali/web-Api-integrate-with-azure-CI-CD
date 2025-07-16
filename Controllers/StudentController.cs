using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Models.DTOs;
using MyFirstApi.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public readonly StudentRepository _studentRepository;
        public StudentController(StudentRepository studentRepository) {
            _studentRepository = studentRepository;
        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return _studentRepository.Getll();
        }


        // POST api/<StudentController>
        [HttpPost]
        public IActionResult Post([FromBody] StudentDTO studentdto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Student student = new Student()
            {
                Name = studentdto.Name,
                Email = studentdto.Email,
            };
            _studentRepository.AddStudent(student);
            return Ok("Student added successfully shaniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student student)
        {
            _studentRepository.UpdateStudent(id,student);
            return Ok("Student updated successfully");
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _studentRepository.DeleteStudent(id);
            return Ok("Student updated successfully shaniiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
        }
    }
}
