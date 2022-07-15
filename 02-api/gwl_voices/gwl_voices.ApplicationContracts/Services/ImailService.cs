using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gwl_voices.Application.Contracts.Services
{
    public interface ImailService
    {
        public void Send(string from, string to, string subject, string html);

    }
}
