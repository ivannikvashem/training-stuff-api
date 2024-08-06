using System;
using System.Collections.Generic;

namespace training_stuff_api.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
