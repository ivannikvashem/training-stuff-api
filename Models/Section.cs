using System.Collections.Generic;

namespace training_stuff_api.Models
{
    public partial class Section
    {
        public Section()
        {
            Chapter = new HashSet<Chapter>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Chapter> Chapter { get; set; }
    }
}
