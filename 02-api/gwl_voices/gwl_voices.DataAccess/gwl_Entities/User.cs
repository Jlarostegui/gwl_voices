using System;
using System.Collections.Generic;

namespace gwl_voices.DataAccess.gwl_Context
{
    public partial class User
    {
        public User()
        {
            TbiUserEvents = new HashSet<TbiUserEvent>();
            TbiUserWgroups = new HashSet<TbiUserWgroup>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Img { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Adress { get; set; } = null!;
        public string UrlGwl { get; set; } = null!;

        public virtual ICollection<TbiUserEvent> TbiUserEvents { get; set; }
        public virtual ICollection<TbiUserWgroup> TbiUserWgroups { get; set; }
    }
}
