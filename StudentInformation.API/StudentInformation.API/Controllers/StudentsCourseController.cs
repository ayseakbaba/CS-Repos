using Microsoft.AspNetCore.Mvc;
using StudentInformation.Bussiness.Services;
using StudentInformation.Data.Models;
using StudentInformation.DataAccess.Concrete;

namespace StudentInformation.API.Controllers
{
    [ApiController]
    [Route("studentInformation/v1/StudentsCourse")]
    public class StudentsCourseController : ControllerBase
    {
        StudentsCourseManagement SCManagement;



        [HttpGet(template:nameof(GetAllRelation))]
        public IActionResult GetAllRelation()
        {
            SCManagement = new StudentsCourseManagement();
            var result = SCManagement.GetAll();
            if (result.Count > 0) 
            { 
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost(template:nameof(CreateRelation))]
        public IActionResult CreateRelation(StudentsCourseModel model)
        {
            StudentsCourseService service = new StudentsCourseService();
            var result = service.CreateStudentsCourse(model);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        //[HttpPost(template: nameof(UpdateRelation))]
        //public IActionResult UpdateRelation(StudentsCourseModel model)
        //{
        //    SCManagement = new StudentsCourseManagement();
        //    var result = SCManagement.Update(model);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest();
        //}

        [HttpDelete(template:nameof(DeleteRelation))]
        public IActionResult DeleteRelation(int id)
        {
            SCManagement = new StudentsCourseManagement();
            var result = SCManagement.Delete(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet(template:nameof(GetRelation))]
        public IActionResult GetRelation(int id)
        {
            SCManagement = new StudentsCourseManagement();
            var result = SCManagement.Get(id);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
