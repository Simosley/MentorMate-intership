using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOApi.Data.Models
{
    public class Status
    {
        public enum status
        {
            Pending = 0,
            inProgress = 1,
            Complete = 2,
        }
    }
}
