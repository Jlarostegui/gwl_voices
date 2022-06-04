using System;
using System.Collections.Generic;

namespace gwl_voices.DataAccess.gwl_Context
{
    public partial class TbiUserEvent
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int EventsId { get; set; }

        public virtual Event Events { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
