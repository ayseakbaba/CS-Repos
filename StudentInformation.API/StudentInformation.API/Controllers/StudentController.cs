using Microsoft.AspNetCore.Mvc;
using StudentInformation.Bussiness.Services;
using StudentInformation.Data.Models;
using StudentInformation.DataAccess.Concrete;

namespace StudentInformation.API.Controllers
{
    [ApiController]
    [Route("studentInformation/v1/Student")]
    [Consumes("application/json")]
    public class StudentController : ControllerBase
    {
        StudentManager studentManager;
        

        [HttpPost(template:nameof(CreateStudent))]
        public IActionResult CreateStudent([FromBody]StudentModel student)
        {
            StudentService studentService = new StudentService();
            var result = studentService.CreateStudent(student);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
       }

        [HttpGet(template:nameof(GetAllStudent))]
        public IActionResult GetAllStudent()
        {
            studentManager = new StudentManager();
            var student = studentManager.GetAll();
            if (student.Count>0)
            {
                return Ok(student);
            }
            return BadRequest(student);
        }

        [HttpPut(template:nameof(UpdateStudent))]
        public IActionResult UpdateStudent([FromBody]StudentModel student)
        {
            studentManager = new StudentManager();
            var update = studentManager.Update(student);
            if (update != null)
            {
                return Ok(student);
            }
            return BadRequest(student);
        }

        [HttpDelete(template:nameof(DeleteStudent))]
        public IActionResult DeleteStudent(int id)
        {

            studentManager = new StudentManager();
            var student = studentManager.Delete(id);
            if (student != null)
            {
                return Ok(student);
            }
            return BadRequest(student);
        }

        [HttpGet(template: nameof(GetStudent))]
        public IActionResult GetStudent(int id)
        {
            studentManager = new StudentManager();
            var student = studentManager.Get(id);
            if(student != null)
                return Ok(student);
            return BadRequest(student);
        }

    }
}
