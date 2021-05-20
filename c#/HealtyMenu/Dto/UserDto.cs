using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class UserDto
    {
        public int id { get; set; }
        public string userId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string userPassword { get; set; }
        public Nullable<System.DateTime> bornDate { get; set; }
        public string phone { get; set; }
        public Nullable<int> statusCode { get; set; }
        public Nullable<double> myWeight { get; set; }
        public Nullable<double> height { get; set; }
        public Nullable<bool> vegetarian { get; set; }
        public Nullable<bool> vegan { get; set; }
    }
}
