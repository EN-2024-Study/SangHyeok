using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class UserDto
    {
        private string id, password;

        public UserDto(string id, string password)
        {
            this.id = id;
            this.password = password;
        }

        public string Id
        { get { return id; } }

        public string Password
        { get { return password; } }
    }
}
