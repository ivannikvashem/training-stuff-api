using System;
using System.Collections.Generic;

namespace training_stuff_api.Models
{
    public partial class User
    {
        public User()
        {
            Lesson = new HashSet<Lesson>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public int? RoleId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Lesson> Lesson { get; set; }
    }
}
