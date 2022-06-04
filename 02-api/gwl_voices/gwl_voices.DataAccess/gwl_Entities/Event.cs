using System;
using System.Collections.Generic;

namespace gwl_voices.DataAccess.gwl_Context
{
    public partial class Event
    {
        public Event()
        {
            TbiUserEvents = new HashSet<TbiUserEvent>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateOnly Start { get; set; }
        public DateOnly End { get; set; }
        public string Place { get; set; } = null!;

        public virtual ICollection<TbiUserEvent> TbiUserEvents { get; set; }
    }
}
