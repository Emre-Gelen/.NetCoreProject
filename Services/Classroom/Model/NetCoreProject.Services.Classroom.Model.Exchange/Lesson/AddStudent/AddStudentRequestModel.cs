using MediatR;

namespace NetCoreProject.Services.Classroom.Model.Exchange.Lesson.AddStudent
{
    public class AddStudentRequestModel : IRequest
    {
        public Guid LessonId { get; set; }
        public Guid ContactId { get; set; }
    }
}
