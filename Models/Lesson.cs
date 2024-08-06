using System;
using System.Collections.Generic;

namespace training_stuff_api.Models
{
    public partial class Lesson
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? EditedBy { get; set; }
        public int Chapter { get; set; }
        public string LessonText { get; set; }

        public virtual Chapter ChapterNavigation { get; set; }
        public virtual User EditedByNavigation { get; set; }
    }
}
