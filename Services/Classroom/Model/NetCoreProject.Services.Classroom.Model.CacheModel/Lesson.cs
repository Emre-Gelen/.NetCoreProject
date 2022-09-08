using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreProject.Services.Classroom.Model.CacheModel
{
    public class Lesson
    {
        public string LessonName { get; set; }
        public List<string> ContactIds { get; set; }
    }
}
