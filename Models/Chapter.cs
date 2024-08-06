using System;
using System.Collections.Generic;

namespace training_stuff_api.Models
{
    public partial class Chapter
    {
        public Chapter()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public int SectionId { get; set; }

        public virtual Section Section { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
