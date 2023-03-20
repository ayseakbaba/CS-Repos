using Microsoft.AspNetCore.Mvc;
using StudentInformation.Bussiness.Services;
using StudentInformation.Data.Models;
using StudentInformation.DataAccess.Concrete;

namespace StudentInformation.API.Controllers
{
    [ApiController]
    [Route("studentInformation/v1/Course")]
    public class CourseController : ControllerBase
    {
        CourseManagement courseManagement;

        [HttpPost(template:nameof(CreateCourse))]
        public IActionResult CreateCourse(CourseModel courseModel)
        {
            CourseService courseService = new CourseService();
            var result = courseService.CreateCourse(courseModel);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
            
        }

        [HttpGet(template:nameof(GetAllCourse))]
        public ActionResult GetAllCourse()
        {
            courseManagement = new CourseManagement();
            var course = courseManagement.GetAll();
            if (course.Count > 0) 
            {
                return Ok(course);
            }
            return BadRequest();
        }

        [HttpPut(template:nameof(UpdateCourse))]
        public IActionResult UpdateCourse(CourseModel entity)
        {
            courseManagement = new CourseManagement();
            var update = courseManagement.Update(entity);
            if (update != null)
            {
                return Ok(update);
            }
            return BadRequest();
        }

        [HttpDelete(template:nameof(DeleteCourse))]
        public IActionResult DeleteCourse(string id)
        {
            courseManagement = new CourseManagement();
            var delete = courseManagement.Delete(id);
            if (delete != null)
            {
                return Ok(delete);
            }
            return BadRequest();
        }

        [HttpGet(template: nameof(GetCourse))]
        public ActionResult GetCourse(string id)
        {
            courseManagement = new CourseManagement();
            var course = courseManagement.Get(id);
            if (course !=null)
                return Ok(course);
            return BadRequest();
        }


    }
}
