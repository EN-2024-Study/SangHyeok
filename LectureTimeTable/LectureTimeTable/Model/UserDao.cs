using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LectureTimeTable.Model
{
    public class UserDao
    {
        private UserRepository user;

        public UserDao()
        {
            this.user = UserRepository.Instance;
        }

        public bool IsLogIn(string id, string password)
        {
            return user.GetUserId().Equals(id) && user.GetUserPassword().Equals(password);
        }
    }
}
