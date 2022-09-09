using MediatR;
using Microsoft.AspNetCore.Mvc;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.Add;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.Get;
using NetCoreProject.Services.Contact.Model.Exchange.Contact.GetById;

namespace NetCoreProject.Services.Contact.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddContactRequestModel newContact)
        {
            return Ok(await _mediator.Send(newContact));
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetContactsRequestModel request)
        {
            return Ok(await _mediator.Send(request));
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(string Id)
        {
            return Ok(await _mediator.Send(new GetContactByIdRequestModel() { Id = Guid.Parse(Id) }));
        }
    }
}
