using System;
using System.Collections.Generic;

namespace gwl_voices.DataAccess.gwl_Context
{
    public partial class WorkingGroup
    {
        public WorkingGroup()
        {
            TbiUserWgroups = new HashSet<TbiUserWgroup>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<TbiUserWgroup> TbiUserWgroups { get; set; }
    }
}
