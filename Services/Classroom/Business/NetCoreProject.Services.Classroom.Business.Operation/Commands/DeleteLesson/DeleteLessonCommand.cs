using MediatR;
using NetCoreProject.Services.Classroom.Model.Exchange.Lesson.Delete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreProject.Services.Classroom.Business.Operation.Commands.DeleteLesson
{
    public class DeleteLessonCommand : IRequestHandler<DeleteLessonRequestModel, bool>
    {
        public Task<bool> Handle(DeleteLessonRequestModel request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}
