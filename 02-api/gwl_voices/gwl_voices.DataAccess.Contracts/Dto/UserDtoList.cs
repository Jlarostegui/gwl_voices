using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gwl_voices.DataAccess.Contracts.Dto
{
    public class UserDtoList
    {

        public List<loginResponse> Results { get; set; }
        public int Total { get; set; }

        public UserDtoList()
        {
            Results = new List<loginResponse>();
        }
    }
}
