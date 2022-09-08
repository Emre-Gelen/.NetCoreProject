using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Add;

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
        [HttpPost]
        public async Task<IActionResult> Add(AddLessonRequestModel newLesson)
        {
            var res = await _mediator.Send(newLesson);
            return Ok();
        }
    }
}
