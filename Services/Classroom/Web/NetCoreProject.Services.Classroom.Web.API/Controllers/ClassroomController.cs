using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Add;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.AddStudent;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Get;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.GetById;

namespace NetCoreProject.Services.Classroom.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassroomController : Controller
    {
        private readonly IMediator _mediator;

        public ClassroomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("{lessonId}")]
        public async Task<IActionResult> AddStudent(string lessonId, AddStudentRequestModel newRelation)
        {
            if (lessonId.Equals(newRelation.LessonId.ToString()))
                return Ok(await _mediator.Send(newRelation));
            else
                return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddLessonRequestModel newLesson)
        {
            return Ok(await _mediator.Send(newLesson));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetLessonsRequestModel request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return Ok(await _mediator.Send(new GetLessonByIdRequestModel() { Id = Guid.Parse(Id) }));
        }
    }
}
