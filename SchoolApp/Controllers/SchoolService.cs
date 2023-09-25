using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApp.Data;
using SchoolApp.Entities;

namespace SchoolApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolService : ControllerBase
    {
        private readonly DataContext _dataContext;

        public SchoolService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [Route("GetTeachers")]
        public Teacher[] GetAllTeachersByStudent(string studentName)
        {
            return _dataContext.Teachers.Where(t => t.TeacherPupils.Any(tp => tp.Pupil.FirstName == studentName)).ToArray();
        }
    }
}
